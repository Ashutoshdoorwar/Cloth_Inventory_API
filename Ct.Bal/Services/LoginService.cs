using Ct.Bal.InterfacesBal;
using Ct.common.Entities;
using Ct.common.Models;
using Ct.Dal.Data;
using Ct.Dal.InterfacesDal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;


namespace Ct.Bal.ClassBal
{
    public class LoginService : ILoginService
    {
        private readonly IMapper _mapper;
        private IConfiguration _config;
     
        private readonly ILoginRepository _loginRepository;
        public LoginService(IConfiguration configuration, 
            ILoginRepository loginRepository, IMapper mapper)
        {

            _config = configuration;

            _loginRepository = loginRepository;
            _mapper = mapper;
            
        }
        public string GenerateToken(UsersModel usermodel)
        {
            var secuiritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(secuiritykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UsersModel AuthenticationUser(UsersModel usersModel)
        {
            //   if(usermodel.Username == "admin" && usermodel.Password == "12345")
            var user_ = _loginRepository.GetUser(usersModel.Username);
          
          //  UsersModel usermd = _mapper.Map<Users, UsersModel>(user_);


           if (usersModel != null && usersModel.Password == usersModel.Password)
        
            {
                return _mapper.Map<UsersModel>(user_);
            }
            return null;
        }



    }
}
