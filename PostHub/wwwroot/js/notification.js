window.addEventListener("DOMContentLoaded", function () {
    var messageSuccess = document.getElementById("messageSuccess");
    var messageError = document.getElementById("messageError");

    if (messageSuccess) {
        setTimeout(function () {
            console.log("Thành công")
            messageSuccess.style.visibility = "hidden";
        }, 5000);
        
    }
    if (messageError) {
        setTimeout(function () {
            console.log("Thất bại")
            messageError.style.visibility = "hidden";  
        }, 5000);
        
    }

});