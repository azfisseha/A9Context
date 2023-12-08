using ContextExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextExample.Data
{
    public class Context : IContext
    {
        public List<Movie> Movies { get; set; }


        public Context()
        {
            Movies = new List<Movie>()
            {
                new Movie { Id = 1, Title = "Toy Story" },
                new Movie { Id = 2, Title = "Star Wars" },
                new Movie { Id = 3, Title = "Oceans 11" },
                new Movie { Id = 3, Title = "Oceans 12" }
            };
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        public Movie GetByTitle(string title)
        {
            return Movies.FirstOrDefault(x => x.Title == title);
        }

        public List<Movie> FindMovie(string title)
        {
            // find by title - could return more than one item
            return Movies
                .Where(movie => movie.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) > -1)
                .ToList();
        }
    }
}
