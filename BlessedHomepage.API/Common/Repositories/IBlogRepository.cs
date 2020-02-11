using System.Collections.Generic;
using System.Threading.Tasks;
using BlessedHomepage.API.Models;

namespace BlessedHomepage.API.Common.Repositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync();

        Task<IEnumerable<BlogPost>> GetBlogPostAsync(string id);

        Task AddBlogPostAsync(BlogPost post);

        Task DeleteBlogPostAsync(string id);
    }
}
