using Inventory.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Repository
{
    public interface IUserInfoRepository
    {
        void Register (UserInfo userInfo);
        UserInfo Login (UserInfo user);  

    }
}
