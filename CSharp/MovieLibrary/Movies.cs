using System;
using System.Collections.Generic;
using System.Linq;

// ================= INTERFACES =================

public interface IFilm
{
    string Title { get; set; }
    string Director { get; set; }
    int Year { get; set; }
}

public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}

// ================= FILM CLASS =================

public class Film : IFilm
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }

    public Film(string title, string director, int year)
    {
        Title = title;
        Director = director;
        Year = year;
    }
}

// ================= FILM LIBRARY =================

public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> films = new List<IFilm>();

    public void AddFilm(IFilm film)
    {
        films.Add(film);
    }

    public void RemoveFilm(string title)
    {
        var film = films.FirstOrDefault(f => f.Title == title);
        if (film != null)
        {
            films.Remove(film);
        }
    }

    public List<IFilm> GetFilms()
    {
        return films;
    }

    public List<IFilm> SearchFilms(string query)
    {
        List<IFilm> result = new List<IFilm>();

        foreach (var film in films)
        {
            if (film.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                film.Director.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                result.Add(film);
            }
        }

        return result;
    }

    public int GetTotalFilmCount()
    {
        return films.Count;
    }
}