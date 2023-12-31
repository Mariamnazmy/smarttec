﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model;

     public class Employee
     {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
     
    public string Email { get; set; }= string.Empty;

    public string PhoneNumber { get; set; } =  string.Empty;

     public string Department { get; set; } = string.Empty;
     
    public int Salary { get; set; }

    public string Job { get; set; } = string.Empty;

    public int PermissionGroup { get; set; }
}

