"use strict";

var connection = new signalR
    .HubConnectionBuilder()
    .withUrl("http://localhost:5000/events")
    .configureLogging(signalR.LogLevel.Information)
    .build();


connection.on("OnEventListener", function (message) {
    var li = document.createElement("li");
    li.textContent = message;
    document.getElementById("eventsList").appendChild(li);
});

connection.start().then(function () {
    // empty
}).catch(function (err) {
    return console.error(err.toString());
});