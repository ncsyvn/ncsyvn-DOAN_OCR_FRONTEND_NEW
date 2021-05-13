using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCR.Models
{
    public class Model
    {
        public Message message;
    }
    public class UserDeleteModel : Model
    {
        public object data; 
    }
    public class UsersModel : Model
    {
        public UsersDataset data;
    }
    public class UserModel : Model
    {
        public UserDataset data;
    }
    public class UsersDataset
    {
        public List<Users> users;
        public int? current_page;
        public int? amount_pages;
        public int? amount_users;
        public string keyword;
        public string size;
    }

    public class UserDataset
    {
        public Users user;
        public int? type;
    }
}