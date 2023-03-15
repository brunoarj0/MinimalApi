using MediatR;
using Minimal.Application.Abstractions;
using Minimal.Application.Posts.Commands;
using Minimal.Domain.Models;

namespace Minimal.Application.Posts.CommandHandlers
{
    public class CreatePostHandler : IRequestHandler<CreatePost, Post>
    {
        private readonly IPostRepository _postRepo;

        public CreatePostHandler(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var newPost = new Post
            {
                Content = request.PostContent
            };

            return await _postRepo.CreatePost(newPost);
        }
    }
}
