using MultiShop.Dto.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

public interface IOfferDsicountServices
{
    Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();

    Task CreateOfferDiscountAsync(CreateOfferDiscountDto dto);

    Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto dto);

    Task DeleteOfferDiscountAsync(string id);

    Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
}