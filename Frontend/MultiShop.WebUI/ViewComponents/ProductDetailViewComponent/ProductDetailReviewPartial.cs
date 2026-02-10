using Microsoft.AspNetCore.Mvc;
using MultiShop.Dto.CommentDtos;
using MultiShop.WebUI.Services.Comment;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent;

public class ProductDetailReviewPartial : ViewComponent
{
    private readonly ICommentService _commentService;

    public ProductDetailReviewPartial(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string productId)
    {
        List<ResultCommentDto> values = await _commentService.CommentListByProductId(productId);
        return View(values);
    }
}