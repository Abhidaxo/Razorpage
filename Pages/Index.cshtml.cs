using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;


namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly YourEntityRepository _entityRepo;


        [BindProperty]
        public YourEntity User { get; set; }

        public IndexModel(ILogger<IndexModel> logger, YourEntityRepository entityRepo)
        {
            _logger = logger;
            _entityRepo = entityRepo;
        }

        public IActionResult OnGet()
        {
            // Optionally, initialize Employees or other data on GET request
            return Page();
        }



        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Use the User object
            var name = User.username;
            var email = User.email;
            var password = User.password;
            _entityRepo.AddAsync(User);

            // Log the user data
            Console.WriteLine($"Name: {name}, Email: {email}, Password: {password}");

            
            return RedirectToPage("Index1", new { username = User.username, email = User.email, password = User.password });
        }
    }



}

