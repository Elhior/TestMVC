using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using UsersMVC.DAL;
using UsersMVC.Models;
using System.Data.Entity.Migrations;
//using AutoMapperApp.Models;
using AutoMapper;
using Ninject;

namespace UsersMVC.Controllers
{
    public class HomeController : Controller
    {
        //private UserContext dbContext = new UserContext();
        //private UserContext dbContext1 = new UserContext();
        private IRepository<User> dbContext;

        public HomeController()
        {
            dbContext = new UserRepository();
        }
        
        public ActionResult Index()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, IndexUserViewModel>());
            var users =
                Mapper.Map<IEnumerable<User>, List<IndexUserViewModel>>(dbContext.GetUserList());
            //return View(dbContext.User);
            //return View(dbContext.GetUserList());
            return View(users);
        }
        
        [HttpPost]
        public void AddUsers(AddUserViewModel user)
        {
            // dbContext.User.Add(user);
            // dbContext.SaveChanges();
            /*
            dbContext1.User.Add(user);
            dbContext1.SaveChanges();
            */

            Mapper.Initialize(cfg => cfg.CreateMap<AddUserViewModel, User>());
                 /*  .ForMember("Name", opt => opt.MapFrom(c => c.FirstName + " " + c.LastName))
                   .ForMember("Email", opt => opt.MapFrom(src => src.Login)));*/
            // Выполняем сопоставление
            User user1 = Mapper.Map<AddUserViewModel, User>(user);

            dbContext.Create(user1);
             dbContext.Save();
        }

        [HttpPost]
        public string RemoveUser(string login, string pasword)
        {
            /* User userToRemove = dbContext.User.First(n => n.Login == user.Login);
                dbContext.User.Remove(userToRemove);
                dbContext.SaveChanges();*/
            try
            {
                User userToRemove = dbContext.GetUserList().First(n => n.Login == login);
                if (userToRemove.Password == pasword)
                {
                    dbContext.Delete(userToRemove.ID);
                    dbContext.Save();
                    return "Removed.";
                }
                return "Wrong password.";
            }
            catch(Exception)
            {
                return "User not found.";
            }
        }

        [HttpGet]
        public string GetUser(long id)
        {
            /* User userToEdit = dbContext.User.First(n => n.ID == (int)id);
             string json = JsonConvert.SerializeObject(userToEdit);
             return json;*/
            return JsonConvert.SerializeObject(dbContext.GetUser(id));
        }

        [HttpPost]
        public string UpdateUsers(User userToUpdate)
        {
            /*dbContext.User.AddOrUpdate(h => h.ID, userToUpdate);
            dbContext.SaveChanges();*/
            if (userToUpdate.Password == dbContext.GetUser(userToUpdate.ID).Password)
            {
                dbContext.Update(userToUpdate);
                dbContext.Save();
                return "Updated";
            }
            else
                return "Wrong password.";
        }

        [HttpGet]
        public string UniquenessValidation(string validatedValue)
        {
            bool isEmail = validatedValue.Contains("@");

            foreach (User user in dbContext.GetUserList())
            {
                if(user.Login== validatedValue && !isEmail)
                    return "false";
                if (user.Email == validatedValue && isEmail)
                    return "false";
            }
            return "true";
        }
    }
}
 