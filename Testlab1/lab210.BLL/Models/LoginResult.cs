﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.BLL.Models
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string AccesToken { get; set; }
        public string RefreshToken { get; set; }
    }
}