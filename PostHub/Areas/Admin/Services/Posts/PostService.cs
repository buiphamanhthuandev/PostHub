using Microsoft.Build.ObjectModelRemoting;
using PostHub.Areas.Admin.Repositories.ManagerRepository;
using PostHub.Areas.Admin.ViewModels.PostViewModels;
using PostHub.Models;
using PostHub.TagHelpers;
using PostHub.Areas.Admin.Instructures;
namespace PostHub.Areas.Admin.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IManagerRepositoy _managerRepositoy;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostService(IManagerRepositoy managerRepositoy, IWebHostEnvironment webHostEnvironment)
        {
            _managerRepositoy = managerRepositoy;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<List<Post>> GetAllAsync(bool trackChanges)
        {
            return await _managerRepositoy.Post.GetAllAsync(trackChanges);
        }
        public async Task<PostViewModel> GetPageLinkAsync(string nameSearch, int page, int pageSize, bool trackChanges)
        {
            var resultPages = await _managerRepositoy.Post.GetPageLinkAsync(nameSearch, page, pageSize, trackChanges);
            var resultCount = await _managerRepositoy.Post.GetCountAsync(nameSearch, trackChanges);
            var result = new PostViewModel
            {
                Posts = resultPages,
                NameSearch = nameSearch,
                PagingInfo = new PagingInfo
                {
                    TotalItems = resultCount,
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                }
            };
            return result;
        }
        public async Task<bool> CreateAsync(PostFormViewModel model)
        {
            try
            {
                if (model.Image != null && model.Image.Length > 0)
                {
                    var fileImage = Path.GetFileNameWithoutExtension(model.Image.FileName);
                    var fileExtention = Path.GetExtension(model.Image.FileName);
                    var fileName = $"{fileImage}_{DateTime.Now.ToString("yyyymmdd_HHmmss")}{fileExtention}";
                    using (var stream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName), FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }
                    var post = new Post
                    {
                        Title = model.Title,
                        Content = model.Content,
                        CategoryId = model.CategoryId,
                        Image = fileName,
                        Slug = SlugHelper.GenerateSlug(model.Title),
                    };
                    _managerRepositoy.Post.CreateAsync(post);
                    await _managerRepositoy.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<PostFormViewModel> EditAsync(int id, bool trackChanges)
        {
            var post = await _managerRepositoy.Post.GetByIdAsync(id, trackChanges);
            if (post != null)
            {
                var result = new PostFormViewModel
                {
                    Title = post.Title,
                    Content = post.Content,
                    CategoryId = post.CategoryId,
                };
                return result;
            }
            return null;
        }
        public async Task<bool> UpdateAsync(int id, PostFormViewModel model, bool trackChanges)
        {
            try
            {
                var post = await _managerRepositoy.Post.GetByIdAsync(id, trackChanges);
                if (post != null)
                {
                    post.Title = model.Title;
                    post.Content = model.Content;
                    post.CategoryId = model.CategoryId;
                    post.Slug = SlugHelper.GenerateSlug(post.Slug);
                    if (model.Image != null && model.Image.Length > 0)
                    {
                        var fileImage = Path.GetFileNameWithoutExtension(model.Image.FileName);
                        var fileExtention = Path.GetExtension(model.Image.FileName);
                        var fileName = $"{fileImage}_{DateTime.Now.ToString("yyyymmdd_HHmmss")}{fileExtention}";
                        using (var stream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName), FileMode.Create))
                        {
                            await model.Image.CopyToAsync(stream);
                        }
                        post.Image = fileName;
                    }
                    _managerRepositoy.Post.UpdateAsync(post);
                    await _managerRepositoy.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> UpdateStateAsync(int id, bool trackChanges)
        {
            try
            {
                var post = await _managerRepositoy.Post.GetByIdAsync(id, trackChanges);
                if (post != null)
                {
                    post.State = post.State == 1 ? 0 : 1;
                    _managerRepositoy.Post.UpdateAsync(post);
                    await _managerRepositoy.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id, bool trackChanges)
        {
            try
            {
                var post = await _managerRepositoy.Post.GetByIdAsync(id, trackChanges);
                if (post != null)
                {
                    _managerRepositoy.Post.DeleteAsync(post);
                    await _managerRepositoy.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
