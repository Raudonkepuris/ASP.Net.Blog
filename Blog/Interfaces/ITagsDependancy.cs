using Blog.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Interfaces
{
    public interface ITagsDependancy
    {
        [Authorize]
        Task<List<Tag>> GetAllTags();
    }
}
