using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCR.Contants
{
    public class UrlContants
    {
        private const string BaseUrl = "http://127.0.0.1:5000";
        public static string Users = $"{BaseUrl}/api/v1/users?page={{0}}&page_size={{1}}&keyword={{2}}";
        public static string User = $"{BaseUrl}/api/v1/users/{{0}}";
        public static string PutUser = $"{BaseUrl}/api/v1/users/{{0}}";
        public static string PostUser = $"{BaseUrl}/api/v1/users";
        public static string DeleteUser = $"{BaseUrl}/api/v1/users/{{0}}";
        public static string Recognize = $"{BaseUrl}/api/v1/images?face={{0}}";        
    }
}