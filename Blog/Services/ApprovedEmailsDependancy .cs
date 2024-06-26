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

        public async Task<bool> IsEmailApproved(string email)
        {
            List<ApprovedEmail> emails = await _context.ApprovedEmail.Where(p => p.Email.ToLower() == email.ToLower()).ToListAsync();
            bool isapproved = emails.Count != 0;
            return isapproved;
        }
    }
}
