using AutoMapper;
using Ct.Bal.InterfacesBal;
using Ct.common.Entities;
using Ct.common.Models;
using Ct.Dal.InterfacesDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.Bal.ClassBal
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userDataAccess, IMapper mapper)
        {
            _userRepository = userDataAccess;
            _mapper = mapper;
        }
        public void AddUser(UsersModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            var Userentity = _mapper.Map<Users>(model);
            _userRepository.AddUser(Userentity);

        }

        public void DeleteUserById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be a positive integer value.");
            }
            _userRepository.DeleteUserById(id);
        }

        public void UpdateUsers(UsersModel model, int id)
        {
            if (model == null && id <= 0)
            {
                throw new ArgumentNullException("model");
            }
            var userentity = _mapper.Map<Users>(model);
            _userRepository.UpdateUsers(userentity, id);

        }
        public List<UsersModel> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            var usermodel = _mapper.Map<List<UsersModel>>(users);
            return usermodel;
        }
    }
}
