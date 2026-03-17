class Program
{
    static void Main()
    {
        IFilmLibrary library = new FilmLibrary();

        library.AddFilm(new Film("Inception", "Christopher Nolan", 2010));
        library.AddFilm(new Film("Interstellar", "Christopher Nolan", 2014));
        library.AddFilm(new Film("Avatar", "James Cameron", 2009));

        Console.WriteLine("Total Films: " + library.GetTotalFilmCount());

        Console.WriteLine("\nAll Films:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine($"{film.Title} - {film.Director} ({film.Year})");
        }

        Console.WriteLine("\nSearch Result for 'Nolan':");
        foreach (var film in library.SearchFilms("Nolan"))
        {
            Console.WriteLine($"{film.Title} - {film.Director}");
        }

        library.RemoveFilm("Avatar");

        Console.WriteLine("\nFilms After Removal:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine($"{film.Title} - {film.Director}");
        }

        Console.ReadLine();
    }
}