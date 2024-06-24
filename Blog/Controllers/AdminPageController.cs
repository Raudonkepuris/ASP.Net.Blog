using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Blog.Controllers;
using Blog.Interfaces;
using Blog.Models;


namespace Blog.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly IPostsDependancy _postsDependancy;
        private readonly ITagsDependancy _tagsDependancy;
        private readonly IApprovedEmailsDependancy _approvedEmailsDependancy;

        public AdminPageController(IPostsDependancy postsDependancy, ITagsDependancy tagsDependancy, IApprovedEmailsDependancy approvedEmailsDependancy)
        {
            _postsDependancy = postsDependancy;
            _tagsDependancy = tagsDependancy;
            _approvedEmailsDependancy = approvedEmailsDependancy;
        }

        [Authorize]
        [Route("admin")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Authorize]
        [Route("admin/posts")]
        public async Task<IActionResult> Posts()
        {
            List<Post> posts = await _postsDependancy.GetAllPosts();
            return View(posts);
        }

        [Authorize]
        [Route("admin/tags")]
        public async Task<IActionResult> Tags()
        {
            List<Tag> tags = await _tagsDependancy.GetAllTags();
            return View(tags);
        }

        [Authorize]
        [Route("admin/approvedemails")]
        public async Task<IActionResult> ApprovedEmails()
        {
            List<ApprovedEmail> approvedEmails =  await _approvedEmailsDependancy.GetAllApprovedEmails();
            return View(approvedEmails);
        }

    }
}
