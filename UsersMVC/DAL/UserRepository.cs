using System;
using System.Collections.Generic;
using System.Linq;
using UsersMVC.Models;
using System.Data.Entity.Migrations;


namespace UsersMVC.DAL
{
    public class UserRepository : IRepository<User>
    {

        private UserContext db;

        public UserRepository()
        {
            this.db = new UserContext();
        }

        public IEnumerable<User> GetUserList()
        {
            return db.User.ToList();
        }

        public User GetUser(long id)
        {
            User user = db.User.First(n => n.ID == (int)id);
            return user;
        }

        public void Create(User user)
        {
            db.User.Add(user);
        }

        public void Update(User user)
        {
            db.User.AddOrUpdate(h => h.ID, user);
        }

        public void Delete(long id)
        {
            User userToRemove = db.User.First(n => n.ID == id);
            if (userToRemove != null)
                db.User.Remove(userToRemove);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}