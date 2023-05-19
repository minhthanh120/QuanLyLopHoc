//"use strict";

//var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

////Disable the send button until connection is established.
//document.getElementById("confirmSend").disabled = true;
//var currentUser = document.getElementById("currentUser").value;
//console.log(currentUser);
//var receiver = document.getElementById("receiver").value;
//console.log(receiver);

//connection.on("ReceiveMessage", addMessageToChat);

//connection.start().then(function () {
//    document.getElementById("confirmSend").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

function addMessageToChat(user, message, time, Avatar, AlterAvatar) {
    console.log(Avatar);
    console.log(AlterAvatar);
    var div1 = document.createElement("div");
    var div2 = document.createElement("div");
    var div3 = document.createElement("div");
    var div4 = document.createElement("div");
    var span = document.createElement("span");
    var p1 = document.createElement("p");
    p1.textContent = `${message}`;
    p1.className = "text-base break-words";
    span.textContent = `${time}`;
    avtdiv = document.createElement("div");
    img = document.createElement("img");
    avtdiv.className = "w-6 h-6 rounded-full";
    if (user == document.getElementById('currentUser').textContent) {
        div3.className = "flex flex-col space-y-2 text-xs max-w-xs mx-2 order-1 items-end";
        div4.className = "px-4 py-2 rounded-lg inline-block rounded-br-none bg-blue-600 text-white";
        div2.className = "flex items-end justify-end";
        
    }
    else {
        div3.className = "flex flex-col space-y-2 text-xs max-w-xs mx-2 order-2 items-start";
        div4.className = "px-4 py-2 rounded-lg inline-block rounded-bl-none bg-gray-300 text-gray-600";
        div2.className = "flex items-end";
        
    }
    div4.appendChild(p1);
    div4.appendChild(span);
    div3.appendChild(div4);
    div2.appendChild(div3);
    if (user == document.getElementById('currentUser').textContent) {
        if (Avatar == "") {
            var avtdiv = document.createElement("div");
            avtdiv.addClass = "bg-gray-700 rounded-full w-6 h-6 inline-flex justify-center items-center order-2";
            var namespan = document.createElement("span");
            namespan.textContent = AlterAvatar;
            namespan.className = "font-bold text-base text-white";
            avtdiv.appendChild(namespan);
            div2.appendChild(avtdiv);
        }
        else {
            var img = document.createElement("img");
            img.src = Avatar;
            img.classList = "w-6 h-6 rounded-full order-2";
            div2.appendChild(img);
        }
    }
    else {
        if (Avatar == "") {
            var avtdiv = document.createElement("div");
            avtdiv.addClass = "bg-gray-700 rounded-full w-6 h-6 inline-flex justify-center items-center order-1";
            var namespan = document.createElement("span");
            namespan.textContent = AlterAvatar;
            namespan.className = "font-bold text-base text-white";
            avtdiv.appendChild(namespan);
            div2.appendChild(avtdiv);
        }
        else {
            var img = document.createElement("img");
            img.src = Avatar;
            img.classList = "w-6 h-6 rounded-full order-1";
            div2.appendChild(img);
        }
    }
    div1.appendChild(div2);
    document.getElementById("messages").appendChild(div1);
    const el = document.getElementById('messages');
    el.scrollTop = el.scrollHeight;
}


document.getElementById("confirmSend").addEventListener("click", function (event) {
    console.log("confirm");
    var user = document.getElementById('currentUser').textContent;
    var receiver = document.getElementById('receiver').textContent;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, receiver, message).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById('messageInput').value = '';
    event.preventDefault();
});

window.onload = (even) => {
    console.log("loading message");
}
