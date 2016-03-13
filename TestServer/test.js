// // include the http module
// var http = require('http');
//
// // create a webserver
// http.createServer(function (req, res) {
//
//    // respond to any incoming http request
//    res.writeHead(200, {'Content-Type': 'text/plain'});
//    res.end('Hello World\n');
//
// }).listen(1337, '127.0.0.1');
//
// // log what that we started listening on localhost:1337
// console.log('Server running at 127.0.0.1:1337');




// var express = require('express');
//
// var app = express();
// var http=require('http');
// var server=http.createServer(app);
// var io=require('socket.io').listen(server);

//   console.log("init server");
// // app.get('/', function(req, res){
// //     res.send('Hello WorldSSS');
// // });
//
// app.listen(1337);
//
// app.get('/', function (req, res) {
// 	res.sendFile(__dirname + '/index.html');
// });
// io.sockets.on('connection',function(socket)
// {
//   console.log("Someone connected");
//
// });
// app.on();



// var app = require('express')();
// var http = require('http').Server(app);
// var io = require('socket.io')(http);
//
// app.get('/', function(req, res){
//   res.sendFile(__dirname + '/index.html');
// });
//
// io.on('connection', function(socket){
//
//     console.log('Connection has been maked');
//   socket.on('chat message', function(msg){
//     io.emit('chat message', msg);
//   });
// });
//
// http.listen(1337, function(){
//   console.log('listening on *:1337');
// });




var express = require('express');
var app = express()
, http = require('http')
, server = http.createServer(app)
, io = require('socket.io').listen(server);

var port=1337;

server.listen(port);
app.get('/', function(req, res){
  res.sendFile(__dirname + '/index.html');

  console.log('Get');
});
io.sockets.on('connection', function (socket) {
  socket.on('test',function()
{
  console.log('test');
});
console.log('Start');
});
