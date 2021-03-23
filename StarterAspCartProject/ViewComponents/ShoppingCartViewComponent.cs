using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarterAspCartProject.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace StarterAspCartProject.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        const string SessionCart = "_Cart";

        public ShoppingCartViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CartItem> cart = new List<CartItem>();
            if (HttpContext.Session.GetString(SessionCart) != null) { 
                    string serialJSON = HttpContext.Session.GetString(SessionCart);
                    cart = JsonSerializer.Deserialize<List<CartItem>>(serialJSON);
            }
            return View(cart);
        }
    }



}
