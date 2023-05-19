"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
//document.getElementById("confirmSend").disabled = true;
//var currentUser = document.getElementById("currentUser").value;
//console.log(currentUser);
//var receiver = document.getElementById("receiver").value;
//console.log(receiver);

connection.on("ReceiveMessage", function (user, message, time, Avatar, AlterAvatar) {
  if (document.getElementById("messages")) {
      addMessageToChat(user, message, time, Avatar, AlterAvatar);
  }
  showToast();
});

connection.start().catch(function (err) {
  return console.error(err.toString());
});
