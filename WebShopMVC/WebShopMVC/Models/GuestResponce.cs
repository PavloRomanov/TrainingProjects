﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopMVC.Models
{
    public class GuestResponce
   {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? WillAttend { get; set; }

    }
}