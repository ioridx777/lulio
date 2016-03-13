var io = require('socket.io')({
	transports: ['websocket'],
});
var express=require('express');

var app = express()
, http = require('http')
, server = http.createServer(app);

var dao =require('./dao');
var utils=require('./utils');

dao.init();

var mySerFunc=function(req,res)
{
	if(req.url=='/')
	{
		  res.sendFile(__dirname + '/index.html');
	}
	else {
		var input = req.url.replace('/','');
		res.write('Hi'+input+'\n');
		res.end('footer');
	}
}
app.get(/.*/, function(req, res){

	if(req.url=='/')
	{
	  // res.sendFile(__dirname + '/index.html');
	  console.log('Get');
		dao.query('select * from account',null,function(err,result)
		{
			if(!!err)
				res.write('error\n'+err.toString());
				if(!!result)
				{

					var ret=JSON.stringify(result);

					res.write('<html><body><table border="1">');
					res.write('<tr><td>id</td><td>name</td><td>content</td></tr>');
					for (var i = 0; i < result.length; i++) {
						res.write('<tr>');
						var current=result[i];

							res.write('<td>');
						res.write(current['id'].toString()	);
						res.write('</td><td>');

						res.write(current['name']	);
						res.write('</td><td>');

					res.write(current['content']	);
					res.write('</td>');

					res.write('</tr>');

					}
					res.end('</table></body></html>');

				}
					// res.end('\nfooter');

		});
	}
	else{
		var input = req.url.replace('/','');
		res.write('Hi'+input+'\n');
		res.write();
		res.end('footer');
	}
});

io.listen(server);
server.listen(4567);

io.on('connection', function(socket){
	socket.on('beep', function(){
		console.log('Test')
		socket.emit('boop');
	});
	socket.on('adddata',function(args)
	{
		dao.query('insert into account set ?',args,function(err,result)
		{
			socket.emit('data',result);
		});
	});
})
