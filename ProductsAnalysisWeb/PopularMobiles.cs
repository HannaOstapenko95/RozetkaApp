using Microsoft.AspNetCore.Mvc;
using Rozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProductsAnalysisWeb
{
    public class PopularMobiles : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            List<Mobile> mbls = Start.ExtractProductsFromeXML();
            return View(mbls.Take(count));
        }
    }
}
