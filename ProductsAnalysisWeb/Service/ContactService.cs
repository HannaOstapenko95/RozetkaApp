using ProductsAnalysisWeb.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductsAnalysisWeb.Service
{
    public static class ContactService
    {
        public static void SendEmail(Contact contact)
        {
            SaveContactInXML(contact);
        }

        public static void SendEmail(string contact)
        {
            using (StreamWriter sw = File.AppendText("DataSource/SubscriberListData/emailList.txt"))
            {
                sw.WriteLine(contact);
            }
        }
        private static XDocument SaveContactInXML(Contact contact)
        {
            var doc = new XDocument();
            var records = new XElement("Contact");
            var contactEl = new XElement("Contact");
            var name = new XAttribute("Name", contact.Name);
            var phone = new XAttribute("Phone", contact.Phone);
            var email = new XAttribute("Email", contact.Email);
            var message = new XElement("Message", contact.Message);
            contactEl.Add(name);
            contactEl.Add(phone);
            contactEl.Add(email);
            contactEl.Add(message);
            records.Add(contactEl);
            doc.Add(records);
            doc.Save("DataSource/IncomingMessagesData/IncomingMessage.xml");
            return doc;
        }
    }
}
