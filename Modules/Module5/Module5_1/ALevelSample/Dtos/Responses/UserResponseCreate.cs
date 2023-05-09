using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelSample.Dtos.Responses
{
    internal class UserResponseCreate : UserResponse
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}