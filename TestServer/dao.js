
var sqlclient=module.exports;

var mysql=require('mysql');

var connection=mysql.createConnection(
{
  host:'127.0.0.1',
  user:'root',
  password:'28899321',
  database:'lulio'

});
sqlclient.init=function()
{
  // connection.connect();
}
sqlclient.query=function(sql,args,cb)
{
  connection.query(sql,args,function(err,result)
  {
    if(!!cb)
      cb(err,result);
  });

}
sqlclient.quit=function()
{
  connection.end();
}

var account={
  name:'Frisk',
  content:'LOVE'

}
// var query=connection.query('insert into account set ?',account,function(err,result)
// {
//   if(err)
//   console.log(err);
// console.log(query);
// })
