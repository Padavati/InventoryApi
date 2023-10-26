using Inventory.DAL.Data;
using Inventory.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Repository
{
    public class UserInfoRepository:IUserInfoRepository
    {
        private ProductDbContext _productDbContext;
        public UserInfoRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public UserInfo Login(UserInfo user)
        {
            UserInfo userInfo = null;
            var result=_productDbContext.users.Where(Obj => Obj.Email == user.Email && Obj.Password == user.Password).ToList();
            if(result.Count > 0)
            {
                userInfo = result[0];
            }
            return userInfo;


         }

        public void Register(UserInfo userInfo)
        {
            _productDbContext.users.Add(userInfo);
            _productDbContext.SaveChanges();
                
         }
    }
}
