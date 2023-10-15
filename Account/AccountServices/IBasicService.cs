using AccountModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServices
{
    public interface IBasicService
    {
        LoginResponseDTO register(RegisterDTO registerDTO);
        LoginResponseDTO login(LoginDTO loginDTO);
    }
}
