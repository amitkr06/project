using BLL.Account;
using DAL.AppDB;
using MAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implement
{
    public class AccountService:IAccount
    {
        ContextDB db = new ContextDB();
        public bool AddUser(Register model)
        {
            User_tbl tbl = new User_tbl();
           // tbl.id= model.id;
            tbl.username= model.username;
            tbl.password= model.password;
            tbl.email= model.email;
            db.User_tbl.Add(tbl);
            var data=db.SaveChanges();
            return data > 0;
        }
        public List<Register> GetUsers()
        {
            List<Register> users = new List<Register>();
            var data = db.User_tbl.ToList();
            foreach (var item in data)
            {
                Register model = new Register();
                model.id = item.id;
                model.username = item.username;
                model.password = item.password;
                model.email = item.email;
                users.Add(model);
            }
            return users;
        }

        public bool Update(Register model)
        {
            var data = db.User_tbl.Find(model.id);
            //User_tbl tbl=new User_tbl();
            data.id = model.id;
            data.username= model.username;
            data.password= model.password;
            data.email= model.email;
            var check=db.SaveChanges();
            return check > 0;


        }
        public bool Delete(int id)
        {
            var data = db.User_tbl.Find(id);
            db.User_tbl.Remove(data);
            var check= db.SaveChanges();
            return check > 0;
        }
    }
}
