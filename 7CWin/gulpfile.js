const gulp = require("gulp"),
sass = require("gulp-sass")
cssnano = require('gulp-cssnano');

gulp.task("default", ["scss"]);

gulp.task("watch", () => {
    gulp.watch("Client/Styles/**/*.scss", ["scss"]);
});

gulp.task("scss", () => {
    return gulp.src("Client/Styles/**/*.scss")
    .pipe(sass().on("error", sass.logError))
    .pipe(cssnano())
    .pipe(gulp.dest("wwwroot/css"));
});
