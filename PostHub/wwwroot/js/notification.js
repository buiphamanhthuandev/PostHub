window.addEventListener("DOMContentLoaded", function () {
    var messageAddSubSuccess = document.getElementById("messageAddSubSuccess");
    var messageAddSubErroe = document.getElementById("messageAddSubError");

    if (messageAddSubSuccess) {
        setTimeout(function () {
            messageAddSubSuccess.style.display = "none";
        }, 5000);
    }
    if (messageAddSubErroe) {
        setTimeout(function () {
            messageAddSubErroe.style.display = "none";
        }, 5000);
    }

});