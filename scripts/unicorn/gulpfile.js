//@ts-check
"use strict";
var gulp = require("gulp")
var gulpConfig = require("../../build/gulp-config.js")()
var spawn = require("child_process").spawn;

var devRoot = gulpConfig.devRoot
var webUrl = gulpConfig.webUrl

function unicorn(options) {
  options = options || ""

  return spawn("PowerShell", ["-Command \"Import-Module " + devRoot + "/Scripts/Unicorn/Unicorn.psm1; Sync-Unicorn -ControlPanelUrl '" + webUrl + "/unicorn.aspx' -SharedSecret 'NH3ErxK9Qdt9SvTht5amnZbtX59jwLdh' " + options + "\""], {
    shell: true,
    stdio: 'inherit'
  });
}

gulp.task("01:unicorn:sync:all", cb => unicorn())

gulp.task("01:unicorn:reserialize:all", cb => unicorn("-Verb 'Reserialize'"))