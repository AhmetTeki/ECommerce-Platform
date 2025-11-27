using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers;

[AllowAnonymous]
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
    public IActionResult CommentList()
    {
        List<UserComment> values = _commentContext.UserComments.ToList();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public IActionResult GetComment(int id)
    {
        UserComment? value= _commentContext.UserComments.Find(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateComment(UserComment userComment)
    {
        _commentContext.UserComments.Add(userComment);
        _commentContext.SaveChanges();
        return Ok("success");
    }

    [HttpPut]
    public IActionResult UpdateComment(UserComment userComment)
    {
        _commentContext.UserComments.Update(userComment);
        _commentContext.SaveChanges();
        return Ok("success");
    }

    [HttpDelete]
    public IActionResult DeleteComment(int id)
    {
        UserComment values = _commentContext.UserComments.Find(id);
        _commentContext.UserComments.Remove(values);
        _commentContext.SaveChanges();
        return Ok("success");
    }
}