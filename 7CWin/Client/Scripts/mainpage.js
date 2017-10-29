const CodeMirror = require("codemirror");
const $ = require("jquery");
const AES = require("crypto-js/aes");
var randombytes = require("randombytes");

const editor = CodeMirror.fromTextArea(document.getElementById("codemirror-area"),
{
    mode: "javascript",
    theme: "lesser-dark",
    lineNumbers: true
})
editor.setSize(null, "95%");
$("#postbin").on("submit", (e) => {
    e.preventDefault();

    const encText = AES.encrypt(editor.getValue(), randombytes(32).toString());

    const Data = {
        ciphertext: encText.ciphertext.toString(),
        iv: encText.iv.toString(),
        "__RequestVerificationToken": $("input[name=\"__RequestVerificationToken\"]").val()
    };

    $.ajax({
        type: "POST",
        headers: { "Content-Type": "application/x-www-form-urlencoded" },
        url: "/createbin",
        data: $.param(Data),
        success: (res) => {
            window.location = "/" + res + "#" + encText.key.toString()
        },
        error: (err) => {
            alert("An error happened.");
            console.error(err);
        }
    });
});