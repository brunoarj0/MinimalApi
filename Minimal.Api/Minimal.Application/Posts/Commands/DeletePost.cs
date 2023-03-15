using MediatR;

namespace Minimal.Application.Posts.Commands
{
    public class DeletePost : IRequest
    {
        public int PotsId { get; set; }
    }
}
