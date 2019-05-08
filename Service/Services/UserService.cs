using Data.Infrastructure;
using Domain.Entities;
using Service.IServices;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
   public class UserService : Service<User>,IUserService
    {
        private static IDatabaseFactory dbfactor = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbfactor);
        IDatabaseFactory dbfactory = null;
        public UserService() : base(wow)
        {

        }
        public User FindRoleByName(string name)
        {
            IEnumerable<User> ls = this.GetMany().OrderBy(p => p.FName).Where(p => p.UserName == name).Take(1);
            User c = new User();
            foreach (var i in ls)
            {
                c.FName = i.FName;
                c.Role = i.Role;
            }
            return c;
        }

        public void ChangeStateById(int id,String state)
        {
            User u = this.GetById(id);
            u.Etat = state;
            this.Update(u);
            this.Commit();
        }

        public User getUserByEmailAndPassword(String email,String password)
        {
           ICollection<User> lu = this.GetAll().ToArray();
            

            foreach (User u in lu)
            {
                if (u.Email.Equals(email) && (u.Password.Equals(password)))
                {
                    return u;
                }
            }

            return new User();
        }
        public IEnumerable<User> GetParticipants()
        {
            return this.GetMany().Where(u => u.Role.Equals("Participant"));
        }

        public User getUser(int id)
        {
            User u = this.GetById((long)id);
            return u;
        }
    }
}
