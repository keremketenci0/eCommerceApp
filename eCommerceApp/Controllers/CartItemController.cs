using eCommerceApp.Data.Services;
using Microsoft.AspNetCore.Mvc;

public class CartItemController : Controller
{
    private readonly ICartItemService _service;

    public CartItemController(ICartItemService service)
    {
        _service = service;
    }
}
