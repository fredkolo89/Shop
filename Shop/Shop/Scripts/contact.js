 
var contact_form = document.getElementById("contact_form");
        var sendMessage = document.getElementById("sendMessage");
        var sendReply = document.getElementById("sendReply");

sendMessage.addEventListener("click", function () {
    sendReply.className = "";
    contact_form.className = "hide";
});

 