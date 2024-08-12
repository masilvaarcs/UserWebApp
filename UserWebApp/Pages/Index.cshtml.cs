using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserWebApp.Models;
using UserWebApp.Services;

namespace UserWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApiService _apiService;

        public IndexModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _apiService.GetUsersAsync();
        }
    }
}
