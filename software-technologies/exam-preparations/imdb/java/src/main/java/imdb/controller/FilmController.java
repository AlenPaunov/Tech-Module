package imdb.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import imdb.bindingModel.FilmBindingModel;
import imdb.entity.Film;
import imdb.repository.FilmRepository;

import java.util.List;

@Controller
public class FilmController {

	@Autowired
	private FilmRepository filmRepository;

	@Autowired
	public FilmController(FilmRepository filmRepository) {
		//TODO: Implement me ...
	}

	@GetMapping("/")
	public String index(Model model) {
		List<Film> films = this.filmRepository.findAll();
		model.addAttribute("films",films);
		model.addAttribute("view", "/film/index");
		return "base-layout";
	}

	@GetMapping("/create")
	public String create(Model model) {
		model.addAttribute("view", "/film/create");
		return "base-layout";
	}

	@PostMapping("/create")
	public String createProcess(Model model, FilmBindingModel filmBindingModel) {
		try{
			Integer.parseInt(filmBindingModel.getYear());
		}
		catch(NumberFormatException e){
			model.addAttribute("view", "/film/create");
			return "base-layout";
		}
		Film film = new Film(
				filmBindingModel.getName(),
				filmBindingModel.getGenre(),
				filmBindingModel.getDirector(),
				filmBindingModel.getYear()
		);

		filmRepository.saveAndFlush(film);
		return "redirect:/";
	}

	@GetMapping("/edit/{id}")
	public String edit(Model model, @PathVariable int id) {

		if (!filmRepository.exists(id)){
			return "redirect/:";
		}

		Film film = filmRepository.findOne(id);
		model.addAttribute("film", film);
		model.addAttribute("view", "/film/edit");
		return "base-layout";
	}

	@PostMapping("/edit/{id}")
	public String editProcess(Model model, @PathVariable int id, FilmBindingModel filmBindingModel) {
		if (!filmRepository.exists(id)){
			return "redirect:/";
		}

		try{
			Integer.parseInt(filmBindingModel.getYear());
		}
		catch(NumberFormatException e){
			Film film = filmRepository.findOne(id);
			model.addAttribute("film", film);
			model.addAttribute("view", "/film/edit");
			return "base-layout";
		}
		Film film = filmRepository.findOne(id);
		film.setDirector(filmBindingModel.getDirector());
		film.setGenre(filmBindingModel.getGenre());
		film.setName(filmBindingModel.getName());
		film.setYear(filmBindingModel.getYear());

		this.filmRepository.saveAndFlush(film);
		return "redirect:/";
	}

	@GetMapping("/delete/{id}")
	public String delete(Model model, @PathVariable int id) {
		if (!filmRepository.exists(id)){
			return "redirect:/";
		}

		Film film = filmRepository.findOne(id);
		model.addAttribute("film", film);
		model.addAttribute("view", "/film/delete");

		return "base-layout";
	}

	@PostMapping("/delete/{id}")
	public String deleteProcess(@PathVariable int id) {
		if (!filmRepository.exists(id)){
			return "redirect:/";
		}
		Film film = filmRepository.findOne(id);

		filmRepository.delete(film);
		return "redirect:/";
	}
}
