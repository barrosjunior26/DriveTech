// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function echarJanela() {
    window.close();
}

setTimeout(function () {
    $(".alert").fadeOut("slow", function () {
        $(this).alert("close");
    });
}, 5000);