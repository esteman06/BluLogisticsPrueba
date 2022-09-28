using BluLogistics.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BluLogisticsWeb.Pages.Autores
{
    public class AuotoresCreateModel : PageModel
    {
        [BindProperty]
        public AutoresView AutoresView { get; set; }
        public void OnGet()
        {
        }
    }
}
