using Application.DTOs;
using Microsoft.AspNetCore.Components;

namespace WebUI.Pages
{
    public class DisplayProductsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDTO> Products { get; set; }

    }
}
