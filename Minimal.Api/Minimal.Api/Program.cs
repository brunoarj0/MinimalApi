using MediatR;
using Microsoft.EntityFrameworkCore;
using Minimal.Application.Abstractions;
using Minimal.Application.Posts.Commands;
using Minimal.Application.Posts.Queries;
using Minimal.Domain.Models;
using Minimal.Infrastructure;
using Minimal.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer(cs));
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreatePost>());

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/api/posts/{id}", async (IMediator mediator, int id) =>
{
    var getPost = new GetPostById { PostId = id };
    var post = await mediator.Send(getPost);
    return Results.Ok(post);
})
    .WithName("GetPostById");

app.MapPost("/api/posts", async (IMediator mediator, Post post) =>
{
    var createPost = new CreatePost { PostContent = post.Content };
    var createdPost = await mediator.Send(createPost);
    return Results.CreatedAtRoute("GetPostById", new { createdPost.Id}, createPost);
});

app.MapGet("/api/posts", async (IMediator mediator) =>
{
    var getCommand = new GetAllPosts();
    var posts = await mediator.Send(getCommand);
    return Results.Ok(posts);
});

app.MapPut("/api/posts/{id}", async (IMediator mediator, Post post, int id) =>
{
    var updatePost = new UpdatePost { PostId = id, PostContent = post.Content };
    var updatedPost = await mediator.Send(updatePost);
    return Results.Ok(updatedPost);
});

app.MapDelete("/api/posts/{id}", async (IMediator mediator, int id) =>
{
    var deletePost = new DeletePost { PotsId = id };
    await mediator.Send(deletePost);
    return Results.NoContent();
});

app.Run();
