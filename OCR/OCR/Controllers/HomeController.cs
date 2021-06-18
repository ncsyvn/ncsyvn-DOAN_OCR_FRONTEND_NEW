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
using OCR.Attributes;

namespace OCR.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        [Session]
        [Role(Roles = new string[] { RoleConst.admin })]
        public ActionResult Index(string currentPage = "1", string size = "10", string searchWith = "")
        {
            UsersModel data = new UsersModel();
            data.message = Message.DefaultMessage;
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
        [Session]
        [Role(Roles = new string[] { RoleConst.admin, RoleConst.user })]
        public ActionResult Detail(string id)
        {
            UserModel data = new UserModel();
            data.message = Message.DefaultMessage;
            HttpResponseMessage response = client.GetAsync(UrlContants.User.Format(new object[] { id })).Result;
        if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsAsync<UserModel>().Result;
            }
            ViewBag.Title = "";
            return View(data);
        }
        [Session]
        [Role(Roles = new string[] { RoleConst.admin, RoleConst.user })]
        [HttpPost]        
        public JsonResult Edit(Users data)
        {
            UserModel result = new UserModel();
            result.message = Message.DefaultMessage;
            StringContent content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(UrlContants.PutUser.Format(new object[] { data.ma }), content).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<UserModel>().Result;
            }
            return Json(Json(result));
        }
        [Session]
        [Role(Roles = new string[] { RoleConst.admin})]
        [HttpPost]
        public JsonResult Delete(string id)
        {
            UserDeleteModel result = new UserDeleteModel();
            result.message = Message.DefaultMessage;
            HttpResponseMessage response = client.DeleteAsync(UrlContants.DeleteUser.Format(new object[] { id })).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<UserDeleteModel>().Result;
            }
            return Json(Json(result));
        }
        [Session]
        public ActionResult Test()
        {
            UserModel data = new UserModel();
            data.message = Message.DefaultMessage;
            HttpResponseMessage response = client.GetAsync(UrlContants.User.Format()).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsAsync<UserModel>().Result;
            }
            ViewBag.Title = "";
            return View(data);
        }
        [Session]
        [Role(Roles = new string[] { RoleConst.admin })]
        public ActionResult Add()
        {
            UserModel data = new UserModel();
            data.message = Message.DefaultMessage;
            data.data = new UserDataset();
            data.data.user = new Users();
            data.data.user.anh_mat_sau = "";
            data.data.user.anh_mat_truoc = "";
            data.data.user.co_gia_tri_den = DateTime.Now.ToString("dd/MM/yyyy");
            data.data.user.dan_toc = "";
            data.data.user.gioi_tinh = "Nam";
            data.data.user.ho_va_ten = "";
            data.data.user.link_anh = "";
            data.data.user.ma = "";
            data.data.user.ngay_cap = DateTime.Now.ToString("dd/MM/yyyy");
            data.data.user.ngay_sinh = DateTime.Now.ToString("dd/MM/yyyy");
            data.data.user.noi_cap = "";
            data.data.user.que_quan = "";
            data.data.user.que_quan_huyen = "";
            data.data.user.que_quan_tinh = "";
            data.data.user.que_quan_xa = "";
            data.data.user.so_the = "";
            data.data.user.thuong_tru = "";
            data.data.user.thuong_tru_huyen = "";
            data.data.user.thuong_tru_tinh = "";
            data.data.user.thuong_tru_xa = "";
            data.data.user.ton_giao = "Không";
            return View(data);
        }
        [Session]
        [Role(Roles = new string[] { RoleConst.admin })]
        [HttpPost]
        public JsonResult Add(Users data)
        {
            data.ma = (string)Session["user-id"];
            UserModel result = new UserModel();
            result.message = Message.DefaultMessage;
            StringContent content = new System.Net.Http.StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(UrlContants.PostUser.Format(), content).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<UserModel>().Result;
            }
            return Json(Json(result));
        }
    }
}