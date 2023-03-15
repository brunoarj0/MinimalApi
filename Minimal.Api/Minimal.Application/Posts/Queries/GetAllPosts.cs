using MediatR;
using Minimal.Domain.Models;

namespace Minimal.Application.Posts.Queries
{
    public class GetAllPosts : IRequest<ICollection<Post>>
    {

    }
}
