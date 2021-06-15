using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCR.Models
{
    public class Message
    {
        public string id;
        public string text;
        public string status;
        public bool popup;
        public int duration;
        public static Message DefaultMessage = new Message
        {
            text = "Thất bại",
            status = "error",
            popup = true,
            duration = 5
        };
    }    
}