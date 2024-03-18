using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Services.Contracts
{
    public interface IShoppingCartService
    {
        Task<List<CartItemDTO>> GetItems(int userId);
        Task<CartItemDTO> AddItem(CartItemToAddDTO cartItemToAddDto);
        Task<CartItemDTO> DeleteItem(int id);
        Task<CartItemDTO> UpdateQty(CartItemQtyUpdateDTO cartItemQtyUpdateDto);

        event Action<int> OnShoppingCartChanged;
        void RaiseEventOnShoppingCartChanged(int totalQty);
    }
}
