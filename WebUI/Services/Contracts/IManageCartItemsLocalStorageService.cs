using Application.DTOs;

namespace WebUI.Services.Contracts
{
    public interface IManageCartItemsLocalStorageService
    {
        Task<List<CartItemDTO>> GetCollection();
        Task SaveCollection(List<CartItemDTO> cartItemDtos);
        Task RemoveCollection();
    }
}
