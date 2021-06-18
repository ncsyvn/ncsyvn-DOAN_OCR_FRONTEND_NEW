using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCR.Models
{
    public class Message
    {
        public string id { get; set; }
        public string text { get; set; }
        public string status { get; set; }
        public bool popup { get; set; }
        public int duration { get; set; }
        public static Message DefaultMessage = new Message
        {
            text = "Thất bại",
            status = "error",
            popup = true,
            duration = 5
        };
    }    
}