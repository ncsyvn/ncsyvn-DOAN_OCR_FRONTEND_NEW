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
using Newtonsoft.Json;
using System.Text;

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
            data.data.keyword = searchWith;
            data.data.size = size;
            return View(data);
        }
        //[HttpPost]
        //public ViewResult Gets(string[] _params)
        //{
        //    UsersModel data = null;
        //    HttpResponseMessage response = client.GetAsync(UrlContants.Users.Format(_params)).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        data = response.Content.ReadAsAsync<UsersModel>().Result;
        //    }
        //    data.data.current_page = Convert.ToInt32(_params[0]);
        //    return RedirectToAction("Index", new { currentPage = _params[0], size = _params[1], searchWith = _params[2] });
        //}

        public ActionResult Detail(string id)
        {
            UserModel data = null;
            HttpResponseMessage response = client.GetAsync(UrlContants.User.Format(new object[] { id })).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsAsync<UserModel>().Result;
            }
            ViewBag.Title = "";
            return View(data);
        }

        [HttpPost]
        public JsonResult Edit(Users data)
        {
            UserModel result = null;
            StringContent content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(UrlContants.PutUser.Format(new object[] { data.ma }), content).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<UserModel>().Result;
            }
            return Json(Json(result));
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            UserDeleteModel result = null;
            HttpResponseMessage response = client.DeleteAsync(UrlContants.DeleteUser.Format(new object[] { id })).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<UserDeleteModel>().Result;
            }
            return Json(Json(result));
        }

        public ActionResult Test()
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
    }
}