﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;

public class AppUser : IdentityUser<long>
{
    public string? PhotoUrl { get; set; }
}
