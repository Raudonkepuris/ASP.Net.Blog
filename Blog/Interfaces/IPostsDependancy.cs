using Blog.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Interfaces
{
    public interface IPostsDependancy
    {
        [Authorize]
        Task<List<Post>> GetAllPosts();
    }
}
