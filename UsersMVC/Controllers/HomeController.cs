using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UsersMVC.DAL;
using UsersMVC.Models;
using AutoMapper;

namespace UsersMVC.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<User> dbContext;

        public HomeController()
        {
            dbContext = new UserRepository();
        }
        
        public ActionResult Index()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, IndexUserViewModel>());
            var users =
                Mapper.Map<IEnumerable<User>, IEnumerable<IndexUserViewModel>>(dbContext.GetUserList());

            return View(users);
        }
      
    }
}
 