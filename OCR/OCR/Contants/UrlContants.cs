using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCR.Contants
{
    public class UrlContants
    {
        private const string BaseUrl = "https://741vibt902.execute-api.us-east-2.amazonaws.com/stag";
        public static string Users = $"{BaseUrl}/api/v1/users?page={0}&page_size={1}&keyword={2}";
        public static string User = $"{BaseUrl}/api/v1/users/user_id";
    }
}