"use strict";

//var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44341/updates").build();
//var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44370/Updates").build();

var connection = new signalR.HubConnectionBuilder().withUrl("/updates").build();

connection.start();

var delay = 500;
setTimeout(function() {
	connection.invoke("SendMsg");
},
    delay
);

connection.on("SendMsg",
	function(message) {
		var li = document.createElement("li");
		li.textContent = message;
		document.getElementById("messagesList").appendChild(li);
    });

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