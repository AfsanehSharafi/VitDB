﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
    }

}
