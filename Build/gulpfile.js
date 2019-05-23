//@ts-check
"use strict";
var gulp = require("gulp")
var msbuild = require("gulp-msbuild")
var debug = require("gulp-debug")
var foreach = require("gulp-foreach")
var gulpConfig = require("../gulp-config.js")()
var nugetRestore = require("gulp-nuget-restore")
var del = require('del');
var vinylPaths = require('vinyl-paths');

var devRoot = gulpConfig.devRoot
var webRoot = gulpConfig.webRoot

module.exports.config = gulpConfig

function cleanProjectFiles(layerName) {
  const filesToDelete = [
    webRoot + "/bin/AktionMensch." + layerName + ".*",
    webRoot + "/App_Config/Include/" + layerName + "*",
    webRoot + "/App_Config/Include/Z." + layerName + "*"
  ]

  console.log("Removing " + layerName + " configs/binaries")

  return gulp.src(filesToDelete, { read: false })
    .pipe(vinylPaths(paths => del(paths, { force: true })));
}
cleanProjectFiles.displayName = "00:publish:layer:cleanup"

function cleanAllProjectFiles() {
  const filesToDelete = [
    webRoot + "/App_Config/**/*.ji2",
    webRoot + "/App_Config/**/*.exclude",
    webRoot + "/App_Config/Include/Foundation/*",
    webRoot + "/App_Config/Include/Feature/*",
    webRoot + "/App_Config/Include/Z.Feature/*",
    webRoot + "/App_Config/Include/Project/*",
    webRoot + "/App_Config/Include/Z.Project/*",
    webRoot + "/App_Config/Include/Z/*",
    webRoot + "/App_Config/Include/Z.Support/*",
    webRoot + "/App_Config/Include/Z_CMS/*",
    webRoot + "/App_Config/Include/Unicorn/*",
    webRoot + "/Areas/*",
    webRoot + "/bin/AktionMensch.*",
    webRoot + "/bin/Castle.Windsor.*",
    webRoot + "/bin/Rainbow.*",
    webRoot + "/bin/Sitecore.Support.*",
    webRoot + "/bin/Unicorn.*",
    webRoot + "/Views/*",
    "!" + webRoot + "/App_Config/Include/Foundation/Foundation.Search.ServiceAddress.config",
    "!" + webRoot + "/Views/*.config",
    "!" + webRoot + "/Views/Shared"
  ]

  console.log("Removing old configs, binaries and views")

  return gulp.src(filesToDelete, { read: false, allowEmpty: true })
    .pipe(vinylPaths(paths => del(paths, { force: true })));
}
cleanAllProjectFiles.displayName = "00:publish:solution:cleanup:configs"

function publishProjects(location, dest) {
  dest = dest || webRoot
  var targets = ["Build"]

  console.log("publish to " + dest + " folder")
  return gulp.src([location + "/**/code/*.csproj"])
    .pipe(foreach(function (stream) {
      return stream
        .pipe(debug({ title: "Building project:" }))
        // @ts-ignore
        .pipe(msbuild({
          targets: targets,
          configuration: gulpConfig.buildConfiguration,
          logCommand: false,
          verbosity: "minimal",
          stdout: true,
          errorOnFail: true,
          maxcpucount: 0,
          // @ts-ignore
          toolsVersion: gulpConfig.MSBuildToolsVersion,
          properties: {
            DeployOnBuild: "true",
            DeployDefaultTarget: "WebPublish",
            WebPublishMethod: "FileSystem",
            DeleteExistingFiles: "false",
            TransformWebConfigEnabled: "false",
            AutoParameterizationWebConfigConnectionStrings: "false",
            publishUrl: dest
          }
        }))
    }))
}

function cleanupSolution() {
  var targets = ["Clean"]

  return gulp.src("./" + gulpConfig.solutionName + ".sln")
    .pipe(debug({ title: "Cleanup solution:" }))
    // @ts-ignore
    .pipe(msbuild({
      targets: targets,
      configuration: gulpConfig.buildConfiguration,
      logCommand: false,
      verbosity: "minimal",
      stdout: true,
      errorOnFail: true,
      maxcpucount: 0,
      // @ts-ignore
      toolsVersion: gulpConfig.MSBuildToolsVersion,
      properties: {
        DeleteExistingFiles: "false",
        TransformWebConfigEnabled: "false",
        AutoParameterizationWebConfigConnectionStrings: "false",
      }
    }))
}
cleanupSolution.displayName = "00:publish:solution:cleanup:msbuild"

gulp.task("00:build:solution", function () {
  var targets = ["Build"]

  return gulp.src("./" + gulpConfig.solutionName + ".sln")
    .pipe(debug({ title: "NuGet restore:" }))
    .pipe(nugetRestore())
    .pipe(debug({ title: "Building solution:" }))
    // @ts-ignore
    .pipe(msbuild({
      targets: targets,
      configuration: gulpConfig.buildConfiguration,
      logCommand: false,
      verbosity: "minimal",
      stdout: true,
      errorOnFail: true,
      maxcpucount: 0,
      // @ts-ignore
      toolsVersion: gulpConfig.MSBuildToolsVersion
    }))
})

gulp.task("00:publish:solution", function () {
  var dest = webRoot
  var targets = ["Build"]

  console.log("publish to " + dest + " folder")
  return gulp.src("./" + gulpConfig.solutionName + ".sln")
    .pipe(debug({ title: "NuGet restore:" }))
    .pipe(nugetRestore())
    .pipe(debug({ title: "Building solution:" }))
    // @ts-ignore
    .pipe(msbuild({
      targets: targets,
      configuration: gulpConfig.buildConfiguration,
      logCommand: false,
      verbosity: "minimal",
      stdout: true,
      errorOnFail: true,
      maxcpucount: 0,
      // @ts-ignore
      toolsVersion: gulpConfig.MSBuildToolsVersion,
      properties: {
        DeployOnBuild: "true",
        DeployDefaultTarget: "WebPublish",
        WebPublishMethod: "FileSystem",
        DeleteExistingFiles: "false",
        TransformWebConfigEnabled: "false",
        AutoParameterizationWebConfigConnectionStrings: "false",
        publishUrl: dest
      }
    }))
})

gulp.task("00:publish:layer:foundation", function () {
  return cleanProjectFiles("Foundation"),
    publishProjects(devRoot + "/src/Foundation")
})

gulp.task("00:publish:layer:feature", function () {
  return cleanProjectFiles("Feature"),
    publishProjects(devRoot + "/src/Feature")
})

gulp.task("00:publish:layer:project", function () {
  return cleanProjectFiles("Project"),
    publishProjects(devRoot + "/src/Project")
})

gulp.task("00:publish:helix", gulp.series(
  gulp.parallel("00:publish:layer:foundation",
    "00:publish:layer:feature",
    "00:publish:layer:project"),
    "03:local:env:start"
));

gulp.task("00:publish:solution", gulp.series(
  cleanAllProjectFiles,
  "00:publish:solution",
  "03:local:env:start"
))

gulp.task("00:publish:solution:rebuild", gulp.series(
  cleanupSolution,
  "00:publish:solution"
))

gulp.task("00:publish:solution:with:iis-restart", gulp.series(
  "03:local:env:stop",
  cleanAllProjectFiles,
  "00:publish:solution",
  "03:local:env:start"
))