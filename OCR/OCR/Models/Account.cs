﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCR.Models
{
    public class Account
    {
        public string username { get; set; }
        public string password { get; set; }
        public string confirm_password { get; set; }
        public string token { get; set; }
        public string user_id { get; set; }
        public string role { get; set; }
        public string account_id { get; set; }
    }
}