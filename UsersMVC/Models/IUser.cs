using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersMVC.Models
{
    public interface IUser
    {
        string Login
        {
            get;
            set;
        }
        string FirstName
        {
            get;
            set;
        }
        string LastName
        {
            get;
            set;

        }
        string Phone
        {
            get;
            set;
        }
        string Email
        {
            get;
            set;
        }
        string Address
        {
            get;
            set;
        }
    }
}