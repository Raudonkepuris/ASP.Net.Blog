using Blog.Data;
using Blog.Interfaces;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Blog.Services
{
    public class ApprovedEmailsDependancy : IApprovedEmailsDependancy
    {
        private readonly ApplicationDbContext _context;

        public ApprovedEmailsDependancy(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<List<ApprovedEmail>> GetAllApprovedEmails()
        {
            return await _context.ApprovedEmail.ToListAsync();
        }
    }
}
