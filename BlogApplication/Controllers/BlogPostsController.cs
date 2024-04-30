using Azure;
using BlogApplication.Models.Domain;
using BlogApplication.Models.ViewModels;
using BlogApplication.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogApplication.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly UserManager<IdentityUser> _userManager; 
        public BlogPostsController(IBlogPostRepository blogPostRepository, UserManager<IdentityUser> userManager)
        {
            this.blogPostRepository = blogPostRepository;
            this._userManager = userManager;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBlogPostRequest addBlogPostRequest)
        {
            var blogPost = new Post()
            {
                Title = addBlogPostRequest.Title,
                Content = addBlogPostRequest.Content,
                FeaturedImageUrl = addBlogPostRequest.FeaturedImageUrl,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Author = addBlogPostRequest.Author,
            };


            await blogPostRepository.AddAsync(blogPost);

            // Show success message
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var blogs = await blogPostRepository.GetAllAsync();
            return View(blogs);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var blogPost = await blogPostRepository.GetAsync(id);

            if (blogPost != null)
            {
                // map the domain model into the view model
                var model = new EditBlogPostRequest
                {
                    PostId = blogPost.PostId,
                    Title = blogPost.Title,
                    Content = blogPost.Content,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    CreatedAt = blogPost.CreatedAt,
                    UpdatedAt = blogPost.UpdatedAt,
                    Author = blogPost.Author
                };

                return View(model);
            }

            // pass data to view
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBlogPostRequest editBlogPostRequest)
        {
            // map view model back to domain model
            var blogPostDomainModel = new Post
            {
                PostId = editBlogPostRequest.PostId,
                Title = editBlogPostRequest.Title,
                Content = editBlogPostRequest.Content,
                Author = editBlogPostRequest.Author,
                FeaturedImageUrl = editBlogPostRequest.FeaturedImageUrl,
                CreatedAt = editBlogPostRequest.CreatedAt,
                UpdatedAt = DateTime.Now
            };

            // Submit information to repository to update
            var updatedBlog = await blogPostRepository.UpdateAsync(blogPostDomainModel);

            if (updatedBlog != null)
            {
                // Show success notification
                return RedirectToAction("Edit");
            }

            // Show error notification
            return RedirectToAction("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditBlogPostRequest editBlogPostRequest)
        {
            // tell repository to delte
            var deletedBlog = await blogPostRepository.DeleteAsync(editBlogPostRequest.PostId);

            if (deletedBlog != null)
            {
                // show success message
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id = editBlogPostRequest.PostId });
        }
    }
}
