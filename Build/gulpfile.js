//@ts-check
"use strict";
var gulp = require("gulp")
var msbuild = require("gulp-msbuild")
var debug = require("gulp-debug")
var foreach = require("gulp-foreach")
var gulpConfig = require("./gulp-config.js")()
var nugetRestore = require("gulp-nuget-restore")
var del = require('del');
var vinylPaths = require('vinyl-paths');

var devRoot = gulpConfig.devRoot
var webRoot = gulpConfig.webRoot

module.exports.config = gulpConfig

function cleanAllProjectFiles() {
  const filesToDelete = [
    webRoot + "/bin/SitecoreUrlShorter.*",
    webRoot + "/App_Config/Include/SitecoreUrlShorter/*",
    webRoot + "/App_Config/Include/Unicorn/*",
	webRoot + "/App_Config/Include/Rainbow.config",
	webRoot + "/App_Config/Environment/Foundation/Foundation.Data.config",
    webRoot + "/bin/Rainbow.*",
    webRoot + "/bin/Unicorn.*"
  ]

  console.log("Removing old configs and binaries")

  return gulp.src(filesToDelete, { read: false, allowEmpty: true })
    .pipe(vinylPaths(paths => del(paths, { force: true })));
}
cleanAllProjectFiles.displayName = "00:publish:solution:cleanup"

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