using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersMVC.Models
{
    public static class TempList
    {
        static TempList()
        {
            Users = new List<IUser>();
        }
        public static List<IUser> Users;
    }
}