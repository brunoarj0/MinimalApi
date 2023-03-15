using MediatR;
using Minimal.Domain.Models;

namespace Minimal.Application.Posts.Commands
{
    public class CreatePost : IRequest<Post>
    {
        public string? PostContent { get; set; }
    }
}
