using MediatR;
using Minimal.Domain.Models;

namespace Minimal.Application.Posts.Commands
{
    public class UpdatePost : IRequest<Post>
    {
        public int PostId { get; set; }
        public string? PostContent { get; set; }
    }
}
