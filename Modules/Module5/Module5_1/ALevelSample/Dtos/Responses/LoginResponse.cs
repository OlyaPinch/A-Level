using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelSample.Dtos.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Error { get; set; }
        public bool IsSuccess => string.IsNullOrEmpty(Error);
    }
}