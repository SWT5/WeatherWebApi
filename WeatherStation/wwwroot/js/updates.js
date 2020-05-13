"use strict";


var connection = new signalR.HubConnectionBuilder().withUrl("ws://localhost:44370/updates")
	.configureLogging(signalR.LogLevel.Debug)
	.build();
//var connection = new signalR.HubConnectionBuilder().withUrl("/updates").build();

connection.start();

var delay = 1000;
setTimeout(function() {
	connection.invoke("SendMessage");
},
    delay
);

connection.on("SendMessage",
	function(message) {
		var li = document.createElement("li");
		li.textContent = message;
		document.getElementById("messagesList").appendChild(li);
	});

// hente api behøves dette når man brguer signalR 
//document.getElementById("subscribeBtn").addEventListener("click", function (event) {
//    fetch('api/WeatherForecasts')
//        .then()
//        .catch((err) => {
//            console.log(err.toString());
//        });
//    event.preventDefault();
//});

// hvis vi vil sende på subscripe button 
//document.getElementById("subscribeBtn").addEventListener("click", function(event) {
//	var message = document.getElementById("messagesList").value; 
//	connection.invoke("sendMessage", message).catch(function(err) {
//		return console.error(err.toString());
//	})
//});


//connection.on("ReceiveMessage", function (user, message) {
//    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
//    var encodedMsg = user + " says " + msg;
//    var li = document.createElement("li");
//    li.textContent = encodedMsg;
//    document.getElementById("messagesList").appendChild(li);
//});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});