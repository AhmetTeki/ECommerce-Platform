using MultiShop.Dto.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.Comment;

public class CommentService : ICommentService
{
    private readonly HttpClient _httpClient;

    public CommentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultCommentDto>> GetAllCommentAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("comments");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultCommentDto>? values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
        return values;
    }

    public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("comments/CommentListByProductId/" + id);
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<ResultCommentDto>? values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
        return values;
    }

    public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
    {
        await _httpClient.PostAsJsonAsync("comments", createCommentDto);
    }

    public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
    {
        await _httpClient.PutAsJsonAsync("comments", updateCommentDto);
    }

    public async Task DeleteCommentAsync(string id)
    {
        await _httpClient.DeleteAsync("comments?id=" + id);
    }

    public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("comments/" + id);
        UpdateCommentDto? values = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
        return values;
    }
}