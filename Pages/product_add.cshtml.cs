using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.model;

namespace WebApplication2.Pages
{
    public class product_addModel : PageModel
    {
        private readonly YourEntityRepository _Enitity;

        [BindProperty]
        public products products { get; set; }
        public product_addModel(YourEntityRepository entity)
        {
            _Enitity = entity;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Console.WriteLine("hi"+products.price);
            _Enitity.AddProductAsync(products);
            return Redirect("dashboard");
        }
    }
}
