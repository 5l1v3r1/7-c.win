const path = require("path");
const webpack = require("webpack");
const UglifyJSPlugin = require("uglifyjs-webpack-plugin");

module.exports = {
    entry: {
        mainpage: ["./mainpage.js"]
    },
    output: {
        path: path.join(__dirname, "../../wwwroot/js"),
        filename: "[name].min.js"
    },
    resolve: {
        extensions: [".js", ".json"]
    },
    module: {
        rules: [
            { 
                test: /\.js$/, 
                exclude: /node_modules/, 
                loader: "babel-loader",
            }
        ]
    },
    plugins: [
        new UglifyJSPlugin(),
        new webpack.BannerPlugin({banner: `
        WHAT ARE YOU DOING HERE?! REEEEEEEE
        `, raw: false, entryOnly: true}),
        new webpack.optimize.CommonsChunkPlugin({
            name: "bundle",
            filename: "bundle.min.js",
            exclude: ["bundle"],
            minChunks(module, count) {
                var context = module.context;
                return context && context.indexOf('node_modules') >= 0;
            }
        })
    ],
    externals: {
        "codemirror": "CodeMirror",
        "jquery": "$"
    }
};
