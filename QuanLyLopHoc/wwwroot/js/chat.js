"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("confirmSend").disabled = true;
var currentUser = document.getElementById("currentUser").value;
console.log(currentUser);
var receiver = document.getElementById("receiver").value;
console.log(receiver);

connection.on("ReceiveMessage", addMessageToChat);

connection.start().then(function () {
    document.getElementById("confirmSend").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});