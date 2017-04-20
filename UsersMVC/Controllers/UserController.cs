using System;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using UsersMVC.DAL;
using UsersMVC.Models;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using AutoMapper;

namespace UsersMVC.Controllers
{
    public class UserController : Controller
    {
        private IRepository<User> dbContext;

        public UserController()
        {
            dbContext = new UserRepository();
        }
        [HttpPost]
        public string AddUsers(AddUserViewModel user)
        {
            UserExceptions userExceptions = new UserExceptions();

            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AddUserViewModel, User>());
                User user1 = Mapper.Map<AddUserViewModel, User>(user);

                dbContext.Create(user1);
                dbContext.Save();
                return JsonConvert.SerializeObject(userExceptions);
            }
            catch (DbEntityValidationException validationExcaption)
            {
                userExceptions.isValid = false;

                foreach (DbEntityValidationResult entityValidationResult in validationExcaption.EntityValidationErrors)
                {
                    foreach (DbValidationError validationError in entityValidationResult.ValidationErrors)
                    {
                        if (validationError.PropertyName == "Login")
                            userExceptions.LoginException = validationError.ErrorMessage;
                        if (validationError.PropertyName == "Email")
                            userExceptions.EmailException = validationError.ErrorMessage;
                        if (validationError.PropertyName == "Password")
                            userExceptions.PasswordException = validationError.ErrorMessage;
                    }
                }
                return JsonConvert.SerializeObject(userExceptions);
            }
            catch (DbUpdateException)
            {
                userExceptions.isUnique = false;
                return JsonConvert.SerializeObject(userExceptions);
            }
        }

        [HttpPost]
        public string RemoveUser(string login, string pasword)
        {
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
            catch (Exception)
            {
                return "User not found.";
            }
        }

        [HttpGet]
        public string GetUser(long id)
        {
            return JsonConvert.SerializeObject(dbContext.GetUser(id));
        }

        [HttpPost]
        public string UpdateUsers(User userToUpdate)
        {
            try
            {
                if (userToUpdate.Password == dbContext.GetUser(userToUpdate.ID).Password)
                {
                    dbContext.Update(userToUpdate);
                    dbContext.Save();
                    return "Updated.";
                }
                else
                    return "Wrong password.";
            }
            catch (DbUpdateException)
            {
                return "User with such login or email already exists.";
            }
        }

        [HttpGet]
        public string UniquenessValidation(string validatedValue)
        {
            bool isEmail = validatedValue.Contains("@");

            foreach (User user in dbContext.GetUserList())
            {
                if (user.Login == validatedValue && !isEmail)
                    return "false";
                if (user.Email == validatedValue && isEmail)
                    return "false";
            }
            return "true";
        }
    }
}