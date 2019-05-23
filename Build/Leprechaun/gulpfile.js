//@ts-check
"use strict";
var gulp = require("gulp");
var gulpConfig = require("../gulp-config.js")()
var spawn = require("child_process").spawn;
var path = require("path")

var devRoot = gulpConfig.devRoot

gulp.task("04:leprechaun:generate", function () {
    return spawn(path.join(devRoot, "/build/Leprechaun/bin/Leprechaun.console.exe"), ["/c", path.join(devRoot, "/build/Leprechaun/Leprechaun.config")], {
        stdio: 'inherit'
    });
})

gulp.task("04:leprechaun:generate:watch", function () {
    return spawn(path.join(devRoot, "/build/Leprechaun/bin/Leprechaun.console.exe"), ["/w", "/c", path.join(devRoot, "/build/Leprechaun/Leprechaun.config")], {
        stdio: 'inherit'
    });
})