using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using UserWebApp.Models;
using UserWebApp.Services;

namespace UserWebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApiService _apiService;

        public EditModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _apiService.GetUserByIdAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool result = await _apiService.UpdateUserAsync(id, User);
            if (result)
            {
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Erro ao atualizar usuário.");
            return Page();
        }
    }
}
