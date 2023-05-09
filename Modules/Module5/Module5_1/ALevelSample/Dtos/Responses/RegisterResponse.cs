using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelSample.Dtos.Responses
{
    public class RegisterResponse : LoginResponse
    {
        public int Id { get; set; }
    }
}