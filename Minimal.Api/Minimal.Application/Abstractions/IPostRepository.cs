using Minimal.Domain.Models;

namespace Minimal.Application.Abstractions
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetPosts();
        Task<Post> GetPostById(int id);
        Task<Post> CreatePost(Post toCreate);
        Task<Post> UpdatePost(string updatedContent, int postId);
        Task DeletePost(int postId);
    }
}
