using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using UserWebApp.Models;
using UserWebApp.Services;

namespace UserWebApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ApiService _apiService;

        public DeleteModel(ApiService apiService)
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
            bool result = await _apiService.DeleteUserAsync(id);
            if (result)
            {
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Erro ao excluir usuário.");
            return Page();
        }
    }
}
