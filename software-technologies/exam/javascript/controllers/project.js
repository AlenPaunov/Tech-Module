const Project = require('../models/Project');

module.exports = {
    index: (req, res) => {
        Project.find({}).then(projects => {

            res.render('project/index',{projects:projects});
        })
    },
    createGet: (req, res) => {
        res.render('project/create');
    },
    createPost: (req, res) => {
        let project = req.body;

        Project.create(project).then (project => {
            res.redirect('/');
        })
    },

    editGet: (req, res) => {
        let id = req.params.id;

        Project.findById(id).then(task=>{
            res.render('project/edit',task);
        })
    },
    editPost: (req, res) => {
        let id = req.params.id;
        let task = req.body;

        Project.findByIdAndUpdate(id,task).then(task=>{
            res.redirect('/');
        })
    },
    deleteGet: (req, res) => {
        let id = req.params.id;

        Project.findById(id).then(task=>{
            res.render('project/delete',task);
        })
    },
    deletePost: (req, res) => {
        let id = req.params.id;
        let task = req.body;

        Project.findByIdAndRemove(id,task).then(task=>{
            res.redirect('/');
        })
    }
};