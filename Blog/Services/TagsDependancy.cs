using Blog.Data;
using Blog.Interfaces;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Blog.Services
{
    public class TagsDependancy : ITagsDependancy
    {
        private readonly ApplicationDbContext _context;

        public TagsDependancy(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<List<Tag>> GetAllTags()
        {
            return await _context.Tag.ToListAsync();
        }
    }
}
