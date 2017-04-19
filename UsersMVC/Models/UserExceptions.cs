using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersMVC.Models
{
    public class UserExceptions
    {
        public bool isEmpty;
        public string LoginException
        {
            get;
            set;
        }
                     
        public string EmailException
        {
            get;
            set;
        }

        public string PasswordException
        {
            get;
            set;
        }
    }
}