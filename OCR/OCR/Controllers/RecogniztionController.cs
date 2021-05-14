using Newtonsoft.Json;
using OCR.Contants;
using OCR.Models;
using OCR.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Http.Headers;

namespace OCR.Controllers
{
    public class RecogniztionController : Controller
    {
        static HttpClient client = new HttpClient();
        // GET: Recogniztion
        public ActionResult Index()
        {
            var data = new UserModel();
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

        [HttpPost]
        public JsonResult Upload(string mode)
        {
            UserModel result = null;
            //var content = new MultipartFormDataContent();
            //var fileContent = new StreamContent(Request.Files[0].InputStream);
            //content.Add(fileContent, "image", Request.Files[0].FileName);
            HttpResponseMessage response = client.PostAsync(UrlContants.Recognize.Format(new object[] { mode }), null).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<UserModel>().Result;
            }
            return Json(Json(result));
        }

        [HttpPost]
        public JsonResult Post(Users data)
        {
            UserModel result = null;
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