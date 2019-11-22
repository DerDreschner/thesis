//@ts-check
"use strict";
var gulp = require("gulp")
var gulpConfig = require("../../build/gulp-config.js")()
var spawn = require("child_process").spawn;

var webUrl = gulpConfig.webUrl

function initBackend() {
  return spawn("PowerShell", ["-Command Invoke-WebRequest " + webUrl + "/sitecore/"], {
    shell: true
  });
}
initBackend.displayName = "03:local:sitecore:init:backend"

function initWebsite() {
  return spawn("PowerShell", ["-Command Invoke-WebRequest " + webUrl + "/"], {
    shell: true
  });
}
initWebsite.displayName = "03:local:sitecore:init:website"

function initIis() {
  return spawn("iisreset", ["/start"], {
    shell: true,
    stdio: 'inherit'
  });
}
initIis.displayName = "03:local:iis:init"

gulp.task("03:local:sitecore:init", gulp.parallel(initBackend, initWebsite));

gulp.task("03:local:env:start", gulp.series(
  initIis,
  "03:local:sitecore:init")
)

gulp.task("03:local:env:stop", function () {
  return spawn("iisreset", ["/stop"], {
    shell: true,
    stdio: 'inherit'
  })
});