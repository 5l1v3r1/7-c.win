const gulp = require("gulp"),
sass = require("gulp-sass")
cssnano = require('gulp-cssnano');

gulp.task("default", ["move_bootstrap", "move_codemirror", "scss"]);

gulp.task("move_bootstrap", () => {
    return gulp.src("node_modules/bootstrap/dist/**/*")
        .pipe(gulp.dest("wwwroot/lib/bootstrap"));
});

gulp.task("watch", () => {
    gulp.watch("Client/Styles/**/*.scss", ["scss"]);
});

gulp.task("scss", () => {
    return gulp.src("Client/Styles/**/*.scss")
    .pipe(sass().on("error", sass.logError))
    .pipe(cssnano())
    .pipe(gulp.dest("wwwroot/css"));
});
