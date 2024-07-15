using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication2.model;

namespace WebApplication2.Pages
{
    public class dashboardModel : PageModel
    {
        private readonly YourEntityRepository _entity;
        [BindProperty]
        public int id { get; set; }

        public dashboardModel(YourEntityRepository entity)
        {
            _entity = entity;
        }
       
        public IEnumerable<products> Products { get; set; }
        public async Task OnGet()
        {
            Products = await _entity.GetAllAsync();
        }

        public IActionResult OnPost() 
        {
            _entity.DeleteAsync(id);
            return Redirect("dashboard");
        }
    }
}
