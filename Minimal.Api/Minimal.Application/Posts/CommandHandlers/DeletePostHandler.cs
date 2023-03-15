using MediatR;
using Minimal.Application.Abstractions;
using Minimal.Application.Posts.Commands;

namespace Minimal.Application.Posts.CommandHandlers
{
    public class DeletePostHandler : IRequestHandler<DeletePost>
    {
        private readonly IPostRepository _postRepo;

        public DeletePostHandler(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task Handle(DeletePost request, CancellationToken cancellationToken)
        {
            await _postRepo.DeletePost(request.PotsId);
        }
    }
}
