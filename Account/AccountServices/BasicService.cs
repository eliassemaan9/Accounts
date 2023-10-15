using AccountModels.DTO;
using AccountRepository;
using AccountServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServices.Services
{
    public class BasicService : IBasicService
    {
        private IBasicRepository _basicRepository;
        public BasicService(IBasicRepository basicRepository)
        {
            _basicRepository = basicRepository;
        }

        public LoginResponseDTO register(RegisterDTO registerDTO)
        {
            return _basicRepository.register(registerDTO);  
        }
        public LoginResponseDTO login(LoginDTO loginDTO)
        {
            return _basicRepository.login(loginDTO);
        }
    }
}
