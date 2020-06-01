using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductsAnalysisWeb.Data;
using ProductsAnalysisWeb.Pages;
using ProductsAnalysisWeb.Service;
using Rozetka;

namespace ProductsAnalysisWeb
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }
        public string Message { get; private set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ContactService.SendEmail(Contact);
              
                return new RedirectToPageResult("Confirmation", "Contact");
            }
            return Page();
        }
        public IActionResult OnPostSubscribe(string adress)
        {
            ContactService.SendEmail(adress);
            return new RedirectToPageResult("Confirmation", "Subscribe");
        }
    }
}