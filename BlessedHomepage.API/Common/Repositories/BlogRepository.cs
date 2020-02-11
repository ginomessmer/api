using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlessedHomepage.API.Models;
using LiteDB;

namespace BlessedHomepage.API.Common.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly LiteDatabase _database;

        public BlogRepository(LiteDatabase database)
        {
            _database = database;
        }

        public Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync() =>
            Task.FromResult(_database.GetCollection<BlogPost>().FindAll());

        public Task<IEnumerable<BlogPost>> GetBlogPostAsync(string id) =>
            Task.FromResult(_database.GetCollection<BlogPost>().Find(p => p.Id == id));

        public Task AddBlogPostAsync(BlogPost post) =>
            Task.FromResult(_database.GetCollection<BlogPost>().Insert(post));

        public Task DeleteBlogPostAsync(string id) => 
            Task.FromResult(_database.GetCollection<BlogPost>().Delete(id));
    }
}