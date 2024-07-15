using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class Index1Model : PageModel
    {
        private readonly YourEntityRepository _entityRepo;
        public Index1Model (YourEntityRepository check) { 
        
        _entityRepo = check;
        
        
        }  
        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }

        public  async  Task<IActionResult> OnPost()
        {
          YourEntity user = await _entityRepo.GetByIdAsync(username);

            if (user==null)
            {
                Console.WriteLine("Invaild login");
                return Page();
            }
            if(user.username==username && user.password==password)
            {
                return Redirect("dashboard");
            }
            else
            {
            
                Console.WriteLine("invalid login");
            }
            return Page();
        }

    }
}

