const express = require('express');
const app = express();
const bodyParser = require('body-parser');

app.use(bodyParser.urlencoded({
	extended: true
}));

app.get('/', (req,res) =>
	res.send(`<h1>Hello World!</h1>
	<a href="login">Please login</a>
	`)
);

app.get('/login', (req,res) =>
	res.send(`<form method="post">
	Login:<input type="text" name ="username"/>
	<br>
	Password: <input type="password" name="passwd"/>
	<br>
	<input type="submit"/>
	</form>`)
);

app.get('/users/:id', (req,res) => {
	res.send('Showing User: '+ req.params.id)
});

app.post('/login', function (req,res) {
	let data = req.body;
	if (data.username =="alen" && data.passwd == "alen123")
		res.send("Welcome, alen!");
	else
		res.send(`<h1>Sorry, invalid login</h1>
	<a href="login">Go back</a>	
	`);
});

app.listen(3000,()=>
	console.log('Example app listening on port 3000!')
);