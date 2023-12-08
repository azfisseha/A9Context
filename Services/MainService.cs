using ContextExample.Data;
using System;

namespace ContextExample.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    private readonly IContext _context;

    public MainService(IContext context)
    {
        _context = context;
    }

    public void Invoke()
    {
        // provide an option to the user to 
        // 1. select by id
        // 2. select by title 
        // 3. find movie by title

        int choice = 0;
        do
        {
            choice = MainMenu();
            switch (choice)
            {
                
                case 1:
                    var movie = _context.GetById(InputID());
                    if (movie == null)
                    {
                        Console.WriteLine("No movie found.");
                    }
                    else
                    {
                        Console.WriteLine($"Your movie is {movie.Id}: {movie.Title}");
                    }
                    break;
                case 2:
                    movie = _context.GetByTitle(InputTitle());
                    if (movie == null)
                    {
                        Console.WriteLine("No movie found.");
                    }
                    else
                    {
                        Console.WriteLine($"Your movie is {movie.Id}: {movie.Title}");
                    }
                    break;
                case 3:
                    var movies = _context.FindMovie(InputTitle());
                    if (movies.Count == 0)
                    {
                        Console.WriteLine("No movie found.");
                    }
                    else
                    {
                        Console.WriteLine($"Your movies are: ");
                        movies.ForEach(x => Console.WriteLine($"\t{x.Id}: {x.Title}"));
                    }
                    break;
                case 0:
                    return;
            }
        } while (choice > 0);
    }

    private int MainMenu()
    {
        string input;

        do
        {
            Console.WriteLine("1. Select by id");
            Console.WriteLine("2. Select by title");
            Console.WriteLine("3. Find movie by title");
            Console.WriteLine("X. Exit");

            input = Console.ReadLine();

            switch (input)
            {
                case "1": return 1;
                case "2": return 2;
                case "3": return 3;
            }
        } while (input != "X");
        return 0;
    }

    private int InputID()
    {
        string input;
        int id = 0;
        bool parsed = false;
        do
        {
            Console.Write("Enter the ID to search for: ");
            input = Console.ReadLine();
            parsed = Int32.TryParse(input, out id);
        } while (!parsed);
        return id;
    }

    private string InputTitle()
    {
        Console.Write("Input the title to search for:  ");
        return Console.ReadLine();
    }
}
