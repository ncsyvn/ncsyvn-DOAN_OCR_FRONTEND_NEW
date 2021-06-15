using Newtonsoft.Json;
using OCR.Contants;
using OCR.Extensions;
using OCR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OCR.Controllers
{
    public class UserController : Controller
    {
        static HttpClient client = new HttpClient();
        // GET: User
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public JsonResult SignIn(Account data)
        {
            AccountModel result = new AccountModel();
            result.message = Message.DefaultMessage;
            StringContent content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(UrlContants.SignIn.Format(), content).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<AccountModel>().Result;
            }
            result.data.role = "admin";
            Session["user"] = result;
            Session["role"] = result.data.role;
            Session["user-id"] = result.data.user_id;
            return Json(Json(result));
        }
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public JsonResult SignUp(Account data)
        {
            AccountModel result = new AccountModel();
            result.message = Message.DefaultMessage;
            StringContent content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(UrlContants.SignUp.Format(), content).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<AccountModel>().Result;
            }            
            return Json(Json(result));
        }

        public ActionResult SignOut()
        {
            Session["user"] = null;
            Session["role"] = null;
            Session["user-id"] = null;
            return View("Login");
        }
    }
}