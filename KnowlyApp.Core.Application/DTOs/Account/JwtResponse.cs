﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowlyApp.Core.Application.DTOs.Account
{
    public class JwtResponse
    {
        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
