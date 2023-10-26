using Inventory.DAL.Repository;
using Inventory.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.BAL.Services
{
    public class UserInfoService
    {
        IUserInfoRepository _userInfoRepository;
        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public void Register(UserInfo userinfo)
        {
            _userInfoRepository.Register(userinfo);
        }

        public void Login(UserInfo userinfo)
        {
            _userInfoRepository.Login(userinfo);
        }
    }
}
