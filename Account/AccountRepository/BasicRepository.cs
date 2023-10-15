
using AccountModels.Models;
using AccountModels.DTO;
using AccountRepository.Helper;
using AccountRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountRepository
{
    public class BasicRepository : IBasicRepository
    {
        private AccountsContext _context;
        private IHelper _helper;
        public BasicRepository(AccountsContext context, IHelper helper)
        {
            _context = context;
            _helper = helper;
           
        }

        public LoginResponseDTO register(RegisterDTO registerDTO) 
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (!_helper.CheckIfEmail(registerDTO.email))
                    {
                        throw new UnauthorizedAccessException("Invalid Email structure");
                    }
                    var exists = _context.Users.Where(c => c.Email.ToLower() == registerDTO.email.ToLower() && c.IsDeleted == 0).FirstOrDefault();
                    if (exists != null)
                    {
                        throw new UnauthorizedAccessException("Email Already exists");
                    }
                    LoginResponseDTO loginResponse = new LoginResponseDTO();
                    User user = new User();
                    user.Email = registerDTO.email.ToLower();
                    user.Salt = _helper.GenerateSalt(64);
                    user.PasswordHash = _helper.HashStringHMACSHA512(registerDTO.password, user.Salt);
                    user.FirstName = registerDTO.firstName;
                    user.LastName = registerDTO.lastName;
                    user.IsDeleted = 0;
                    user.IsActive = 1;
                    user.PhoneNumber = registerDTO.phoneNumber;
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    LoginDTO loginDTO = new LoginDTO();
                    loginDTO.Login = registerDTO.email;
                    loginDTO.Password = registerDTO.password;

                    loginResponse = login(loginDTO);
                    transaction.Commit();
                    return loginResponse;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public LoginResponseDTO login(LoginDTO loginDTO)
        {

          
            LoginResponseDTO loginResponse = new LoginResponseDTO();
            var email = loginDTO.Login.ToLower();

            User user = _context.Users.Where(c => c.Email.ToLower() == email && c.IsDeleted == 0).FirstOrDefault();
            if(user == null)
            {
                throw new UnauthorizedAccessException("Invalid Email or Password");
            }
            var pass = _helper.HashStringHMACSHA512(loginDTO.Password,user.Salt);
            user = _context.Users.Where(c => c.PasswordHash == pass && c.Email.ToLower() == email).FirstOrDefault();
            if( user == null )
            {
                throw new UnauthorizedAccessException("Invalid Email or Password");
            }
            string accessToken = _helper.GenerateJwt(user);
            loginResponse.expiryDate = DateTime.UtcNow.AddHours(12);
            loginResponse.userId = user.Id;
            loginResponse.accessToken = accessToken;
            return loginResponse;
        }
    }
}
