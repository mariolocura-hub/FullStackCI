using FullStackCI.Models;
using Microsoft.EntityFrameworkCore;
using FullStackCI.Data;

namespace FullStackCI.Repositories
{
    public class CategoryCommandRepository : ICategoryCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Category CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            //await _context.SaveChangesAsync();
            return category;
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                //  await _context.SaveChangesAsync();
            }
        }
    }
}
