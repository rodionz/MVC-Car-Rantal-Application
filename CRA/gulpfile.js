/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    less = require("gulp-less"),
    sass = require("gulp-sass"); 

var paths = {
    webroot: "./wwwroot/"
};

gulp.task("sass", function () {
    return gulp.src('Content/Sass/MainSass.scss')
            .pipe(sass())
            .pipe(gulp.dest(paths.webroot + '/css'))
});