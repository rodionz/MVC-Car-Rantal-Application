﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class ValidationViewModel
    {
        public bool isValid { get; set; }

        public string errorMessage { get; set; }
    }
}