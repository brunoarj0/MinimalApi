using MediatR;
using Minimal.Application.Abstractions;
using Minimal.Application.Posts.Queries;
using Minimal.Domain.Models;

namespace Minimal.Application.Posts.QueryHandlers
{
    public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
    {
        private readonly IPostRepository _postRepo;

        public GetPostByIdHandler(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
        {
            return await _postRepo.GetPostById(request.PostId);
        }
    }
}
