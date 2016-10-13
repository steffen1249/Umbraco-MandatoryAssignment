var gulp        = require('gulp');
var sass        = require('gulp-sass');

var src = {
  scss: './css/sass/**/*.scss',
  css:  './css'
};

// Static Server + watching scss/html files
gulp.task('serve', ['sass'], function() {
  gulp.watch(src.scss, ['sass']);
});

// Compile sass into CSS
gulp.task('sass', function() {
  return gulp.src(src.scss)
      .pipe(sass())
      .pipe(gulp.dest(src.css))
});

gulp.task('default', ['serve']);
