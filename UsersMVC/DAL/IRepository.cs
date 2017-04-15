using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersMVC.DAL
{
    interface IRepository<T> : IDisposable
            where T : class
    {
        IEnumerable<T> GetUserList(); 
        T GetUser(long id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(string login); 
        void Save(); 
    }
}