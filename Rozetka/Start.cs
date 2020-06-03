using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Utf8Json;
using Xunit;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Rozetka
{
    public  class Start
    {
        public static List<Mobile> StartApplication()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                NavigateToProducts(driver);
                InitializeElements(driver);
                SortByPopularity(driver);
                ExpandToViewAllProducts(driver);
                List<Mobile> mobilePhones = PopulateListWithProduct(driver);
                ShowProductsOnConsole(mobilePhones);
                XDocument doc = new XDocument();
                SaveProducts(mobilePhones, doc);
                return mobilePhones;
            }
        }
        private static void NavigateToProducts(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl($"https://rozetka.com.ua/mobile-phones/c80003/");
        }
        private static Dictionary<string, IWebElement> InitializeElements(IWebDriver driver)
        {
            Dictionary<string, IWebElement> dictElements = new Dictionary<string, IWebElement>();
            dictElements.Add("linkViewMoreElement", driver.FindElement(By.ClassName("catalog-more__text")));
            dictElements.Add("sortDropBox", driver.FindElement(By.XPath("/html/body/app-root/div/div[1]/rz-category/div/main/ctg-catalog/div/div[1]/div/ctg-sort/select")));
            dictElements.Add("selectDropBoxPopulaity", driver.FindElement(By.XPath("/html/body/app-root/div/div[1]/rz-category/div/main/ctg-catalog/div/div[1]/div/ctg-sort/select/option[4]")));
            return dictElements;
        }
        private static void SortByPopularity(IWebDriver driver)
        {
            var dictElements = InitializeElements(driver);
            var sortDropBoxElement = dictElements["sortDropBox"];
            var selectDropBoxPopulaityElement = dictElements["selectDropBoxPopulaity"];
            sortDropBoxElement.Click();
            selectDropBoxPopulaityElement.Click();
        }
        public static void ExpandToViewAllProducts(IWebDriver driver)
        {
            var dictElements = InitializeElements(driver);
            var linkViewMoreElement = dictElements["linkViewMoreElement"];
            Thread.Sleep(1000);
            int p = 0;
            do
            {
                try
                {
                    linkViewMoreElement.Click();
                    Thread.Sleep(1000);
                    p++;
                }
                catch
                {
                    return;
                }
            }
            while (p < 1);
        }
        public static bool CheckXmlExists()
        {
            bool res = File.Exists("DataSource/RozetkaData/Mobiles.xml");
            return res;
        }
        private static List<Mobile> PopulateListWithProduct(IWebDriver driver)
        {
            List<Mobile> mobileEntities = new List<Mobile>();
            var mobileNamesElements = driver.FindElements(By.ClassName("goods-tile__title"));
            var mobilePricesElements = driver.FindElements(By.ClassName("goods-tile__price-value"));
            var reviewsInTextElements = driver.FindElements(By.ClassName("goods-tile__reviews-link"));
            var productLinkElement = driver.FindElements(By.ClassName("goods-tile__heading"));

            int popularity = mobileNamesElements.Count;
            for (int i = 0; i < mobileNamesElements.Count; i++)
            {
                string link = productLinkElement[i].GetAttribute("href");
                Mobile m = new Mobile();
                m.Name = mobileNamesElements[i].Text;
                m.Price = Convert.ToInt32(mobilePricesElements[i].Text.Replace(" ", ""));
                m.Rating = popularity;
                m.Reviews = reviewsInTextElements[i].Text;
                m.DescriptionUrl = link;
                popularity--;
                mobileEntities.Add(m);
            }
            return mobileEntities;
        }
        private static void SaveProducts(List<Mobile> mobileEntities, XDocument doc)
        {
  
            var records = new XElement("Mobile");
            foreach (var item in mobileEntities)
            {
                var mobile = new XElement("Mobile");
                var name = new XElement("Title", item.Name);
                var price = new XAttribute("Price", item.Price);
                var reviews = new XAttribute("Reviews", item.Reviews);
                var pop = new XAttribute("Popularity", item.Rating);
                var link = new XAttribute("Link", item.DescriptionUrl);
                mobile.Add(name);
                mobile.Add(price);
                mobile.Add(reviews);
                mobile.Add(pop);
                mobile.Add(link);
                records.Add(mobile);
            } 
            doc.Add(records);
            doc.Save("DataSource/RozetkaData/Mobiles.xml");
        }
        public static List<Mobile> FromeXML()
        {
            List<Mobile> mobiles = new List<Mobile>();
            
            XmlDocument doc1 = new XmlDocument();
            doc1.Load("DataSource/RozetkaData/Mobiles.xml");
            XmlNode node = doc1.DocumentElement.SelectSingleNode("/Mobile/Title");
            double price;
            int popularity;
            foreach (XmlNode node1 in doc1.DocumentElement.ChildNodes)
            {
                Mobile mobile = new Mobile();
                string name = node1.InnerText; 
                mobile.Name = name;

                bool priceParse = Double.TryParse(node1.Attributes["Price"]?.InnerText, out price);
                if (priceParse == true)
                { 
                    Console.WriteLine("Преобразование прошло успешно");
                    mobile.Price = price;
                }
                else
                    Console.WriteLine("Преобразование завершилось неудачно");

                string reviews = node1.Attributes["Reviews"]?.InnerText;
                mobile.Reviews = reviews;

                bool popularityParse = Int32.TryParse(node1.Attributes["Popularity"]?.InnerText, out popularity);
                if (popularityParse == true)
                {
                    Console.WriteLine("Преобразование прошло успешно");
                    mobile.Rating = popularity;
                }
                else
                    Console.WriteLine("Преобразование завершилось неудачно");
                string link = node1.Attributes["Link"]?.InnerText;
                mobile.DescriptionUrl = link;
                mobiles.Add(mobile);
            }
            return mobiles;
        }
        private static void DeleteXML(XDocument doc)
        {
            File.Delete("Mobiles.xml");
        }
        private static void ShowProductsOnConsole(List<Mobile> mobileEntities)
        {
            for (int i = 1; i < mobileEntities.Count; i++)
            {
                Console.WriteLine("N: " + i + " \t" + mobileEntities[i].Name + "\t" + 
                    mobileEntities[i].Price + "\tPopularity: " + mobileEntities[i].Rating + "\n"
                    + mobileEntities[i].Reviews + "\n" + "Link:" + mobileEntities[i].DescriptionUrl + "\n");
            }
        }
        private static void SaveProductsInDB(List<Mobile> mobileEntities, DB db)
        {

            using (db)
            {
                if (!db.Mobiles.Any())
                {
                    foreach (var mobile in mobileEntities)
                    {
                        db.Mobiles.Add(mobile);
                    }
                    db.SaveChanges();
                }
            }
        }
        //public static void DeleteDataFromDB(DB db)
        //    {
        //       // var db = new DB();
        //       // db.Database.Log = Console.WriteLine;
        //            var dep = db.Mobiles.Where(d => d.Price < 10000).First();
        //            db.Mobiles.Remove(dep);
        //            db.SaveChanges();

        //            Console.WriteLine("Mobile {0} ({1}) is Deleted ", dep.Name, dep.Price);
        //            Console.ReadKey();
        //    }
    }
}
