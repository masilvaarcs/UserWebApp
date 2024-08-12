using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using UserWebApp.Models;
using UserWebApp.Services;

namespace UserWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApiService _apiService;

        public CreateModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool result = await _apiService.AddUserAsync(User);
            if (result)
            {
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Erro ao adicionar usuário.");
            return Page();
        }
    }
}
