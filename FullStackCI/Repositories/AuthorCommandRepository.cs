using FullStackCI.Data;
using FullStackCI.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackCI.Repositories
{
    public class AuthorCommandRepository : IAuthorCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Author CreateAsync(Author Author)
        {
            _context.Authors.Add(Author);
            // await _context.SaveChangesAsync();
            return Author;
        }

        public async Task UpdateAsync(Author Author)
        {
            _context.Entry(Author).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Author = await _context.Categories.FindAsync(id);
            if (Author != null)
            {
                _context.Categories.Remove(Author);
                //await _context.SaveChangesAsync();
            }
        }

    }
}
