using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rozetka;

namespace ProductsAnalysisWeb.Pages
{
    public class TopModel : PageModel
    {
        public List<Mobile> mbls { get; set; }
        public void OnGet()
        {
            mbls = Start.FromeXML();
        }
    }
}
