using Blog.Data;
using Blog.Interfaces;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Blog.Services
{
    public class PostsDependancy : IPostsDependancy
    {
        private readonly ApplicationDbContext _context;

        public PostsDependancy(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<List<Post>> GetAllPosts()
        {
            return await _context.Post.Include(p => p.Tags).ToListAsync();
        }
    }
}
