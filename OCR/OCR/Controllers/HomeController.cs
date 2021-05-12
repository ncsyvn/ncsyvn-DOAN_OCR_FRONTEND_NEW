using OCR.Contants;
using OCR.Models;
using OCR.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace OCR.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        public ActionResult Index(string currentPage = "1", string size = "10", string searchWith = "")
        {
            UsersModel data = null;
            HttpResponseMessage response = client.GetAsync(UrlContants.Users.Format(new object[] { currentPage, size, searchWith })).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsAsync<UsersModel>().Result;
            }
            data.data.current_page = Convert.ToInt32(currentPage);
            return View(data);
        }

        public ActionResult Detail()
        {
            UserModel data = null;
            HttpResponseMessage response = client.GetAsync(UrlContants.User.Format()).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsAsync<UserModel>().Result;
            }
            ViewBag.Title = "";
            return View(data);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}