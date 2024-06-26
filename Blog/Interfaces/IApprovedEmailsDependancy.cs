using Blog.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Interfaces
{
    public interface IApprovedEmailsDependancy
    {
        [Authorize]
        Task<List<ApprovedEmail>> GetAllApprovedEmails();
        [Authorize]
        Task<bool> IsEmailApproved(string email);
    }
}
