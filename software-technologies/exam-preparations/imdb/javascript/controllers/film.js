const Film = require('../models/Film');

module.exports = {
	index: (req, res) => {
		Film.find({}).then(films => {
			res.render('film/index',{films:films});
		})
	},

	createGet: (req, res) => {
        res.render('film/create');
	},
	createPost: (req, res) => {
        let filmArgs = req.body;

        let errorMsg = '';

        if(!filmArgs.name){
        	errorMsg = "Invalid Name";
		}
		else if(!filmArgs.genre){
        	errorMsg = "Invalid genre";
		}
		else if (!filmArgs.director){
        	errorMsg = "Invalid director";
		}
		else if(!filmArgs.year || isNaN(filmArgs.year)){
        	errorMsg = "Invalid Year";
		}
		if(errorMsg){
        	res.render('film/create', {error:errorMsg});
        	return;
		}
		Film.create(filmArgs).then(film => {
			res.redirect('/')
		})

	},

	editGet: (req, res) => {
		let id = req.params.id;
		Film.findById(id).then(film => res.render('film/edit', film))
	},

	editPost: (req, res) => {
        let filmArgs = req.body;

        let errorMsg = '';

        if(!filmArgs.name){
            errorMsg = "Invalid Name";
        }
        else if(!filmArgs.genre){
            errorMsg = "Invalid genre";
        }
        else if (!filmArgs.director){
            errorMsg = "Invalid director";
        }
        else if(!filmArgs.year || isNaN(filmArgs.year)){
            errorMsg = "Invalid Year";
        }

        if(errorMsg){
            res.redirect('/');
            return;
        }
        let id = req.params.id;
        let film = req.body;

        Film.findByIdAndUpdate(id, film).then(film => {
            res.redirect('/')
        });

	},

	deleteGet: (req, res) => {
        let id = req.params.id;
        Film.findById(id).then(film => res.render('film/delete', film))
	},

	deletePost: (req, res) => {
        let id = req.params.id;
        Film.findByIdAndRemove(id).then(film => {
            res.redirect('/');
        }).catch(err => res.redirect('/'));

	}
};