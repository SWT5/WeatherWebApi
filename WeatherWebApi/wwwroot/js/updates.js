"use strict";


var connection = new signalR.HubConnectionBuilder()
    .withUrl("/updates")
    .configureLogging(signalR.LogLevel.Debug)
    .build();


connection.start();

var delay = 1000;
setTimeout(function () {
        connection.invoke("SendMessage");
    },
    delay
);

connection.on("SendMessage",
    function (message) {
        var li = document.createElement("li");
        li.textContent = message;
        document.getElementById("messagesList").appendChild(li);
    });