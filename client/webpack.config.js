module.exports = {
  resolve: {
      fallback: {
          url: require.resolve("url/"),
          path: require.resolve("path-browserify"),
          zlib: require.resolve("browserify-zlib")
      }
  }
}
