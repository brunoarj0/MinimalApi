using MediatR;
using Minimal.Domain.Models;

namespace Minimal.Application.Posts.Queries
{
    public class GetPostById : IRequest<Post>
    {
        public int PostId { get; set; }
    }
}
