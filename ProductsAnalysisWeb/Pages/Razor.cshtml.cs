using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Rozetka;

namespace ProductsAnalysisWeb.Pages
{
    public class IndexModel : PageModel
    {
        public int ID { get; set; }
        public string nam { get; set; }
        public List<string> NameList { get; set; }
        public List<Mobile> MobileList { get; set; }
        public int Price { get; set; }
        public int Popularity { get; set; }
        public string NumberOfReviews { get; set; }
        public string ProductLink { get; set; }
        public string Message { get; set; }

        List<Mobile> mbls = Start.FromeXML();
        
        public void OnGet()
        {
            MobileList = new List<Mobile>();
            for (int i = 0; i < mbls.Count; i++)
            {
                Mobile mob = new Mobile();
                mob.ID = mbls[i].ID;
                mob.Name= mbls[i].Name;
                mob.Price = mbls[i].Price;
                mob.Rating = mbls[i].Rating;
                mob.Reviews = mbls[i].Reviews;
                mob.DescriptionUrl = mbls[i].DescriptionUrl;
                MobileList.Add(mob); 
            }
        }

        public void OnPost()
        {
        }
    }
}
