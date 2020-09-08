﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:5000/events").build();


connection.on("getevent", function (message) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = message;
    document.getElementById("eventsList").appendChild(li);
});

connection.start().then(function () {
    //document.getElementById("sendButton").disabled = false;
    //connection.invoke("SendBroadcastEvent", message, 0).catch(function (err) {
    //    return console.error(err.toString());
    //});
}).catch(function (err) {
    return console.error(err.toString());
});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});