using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelSample.Dtos.Responses
{
    internal class UserResponseUpdate : UserResponse
    {
        public DateTimeOffset UpdatedAt { get; set; }
    }
}