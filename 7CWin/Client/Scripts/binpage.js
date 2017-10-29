const AES = require("crypto-js/aes");
const hex = require("crypto-js/enc-hex");
const utf8 = require("crypto-js/enc-utf8");
const $ = require("jquery");
const codemirror = require("codemirror");

codemirror.modeURL = "https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.31.0/mode/%N/%N.min.js";

let val = {};
try {
    const encval = JSON.parse($("#codemirror-area").val());
    val = encval;
    const ciphertext = hex.parse(encval.ciphertext);
    const key = hex.parse(location.hash.replace("#", ""));
    const iv = hex.parse(encval.iv);
    
    const bytes = AES.decrypt({ciphertext: ciphertext},key,{iv: iv});
    
    
    $("#codemirror-area").val(bytes.toString(utf8));
} catch(e) {
    $("#codemirror-area").val("Error while decrypting the bin.");
} finally {
    const info = codemirror.findModeByExtension(val.mode);

    const editor = codemirror.fromTextArea(document.getElementById("codemirror-area"),
    {
        mode: "javascript",
        theme: "lesser-dark",
        readOnly: true,
        lineNumbers: true
    });

    editor.setSize(null, "95%");
    
    if (val.mode && info) {
        editor.setOption("mode", info.mime);
        codemirror.autoLoadMode(editor, info.mode);
    }
}