using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersMVC.Models
{
    public class UserExceptions
    {
        public UserExceptions()
        {
            isValid = true;
            isUnique = true;
        }
        
        public bool isValid;
        public bool isUnique;

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