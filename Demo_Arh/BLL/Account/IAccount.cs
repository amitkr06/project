using MAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Account
{
    public interface IAccount
    {
        bool AddUser(Register model);
        List<Register> GetUsers();

        bool Update(Register model);
        bool Delete(int id);
    }
}
