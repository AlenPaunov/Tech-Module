package imdb.bindingModel;

import javax.validation.constraints.NotNull;

public class FilmBindingModel {

    @NotNull
    private String name;

    @NotNull
    private String genre;

    @NotNull
    private String director;

    @NotNull
    private String year;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getGenre() {
        return genre;
    }

    public void setGenre(String genre) {
        this.genre = genre;
    }

    public String getDirector() {
        return director;
    }

    public void setDirector(String director) {
        this.director = director;
    }

    public String getYear() {
        return year;
    }

    public void setYear(String year) {
        this.year = year;
    }
}
