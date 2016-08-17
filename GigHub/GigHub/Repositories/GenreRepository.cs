using GigHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Repositories
{
    public class GenreRepository
    {
        private ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

    }
}