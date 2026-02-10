using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly CommentContex _commentContext;

    public CommentsController(CommentContex commentContext)
    {
        _commentContext = commentContext;
    }

    [HttpGet]
    public async Task<IActionResult> CommentList()
    {
        List<UserComment> values = await _commentContext.UserComments.ToListAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetComment(int id)
    {
        UserComment? value = await _commentContext.UserComments.FindAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment(UserComment userComment)
    {
        await _commentContext.UserComments.AddAsync(userComment);
        await _commentContext.SaveChangesAsync();
        return Ok("success");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateComment(UserComment userComment)
    {
        _commentContext.UserComments.Update(userComment);
        await _commentContext.SaveChangesAsync();
        return Ok("success");
    }

    [HttpDelete]
    public IActionResult DeleteComment(int id)
    {
        UserComment? values = _commentContext.UserComments.Find(id);
        if (values != null) _commentContext.UserComments.Remove(values);
        _commentContext.SaveChanges();
        return Ok("success");
    }

    [HttpGet("CommentListByProductId/{id}")]
    public IActionResult CommentListByProductId(string id)
    {
        List<UserComment> value = _commentContext.UserComments.Where(x => x.ProductId == id).ToList();
        return Ok(value);
    }
}