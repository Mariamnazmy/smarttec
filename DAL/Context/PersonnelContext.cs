﻿using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context;

    public class PersonnelContext: DbContext
    {
    public DbSet<Employee> Employees => Set<Employee>();

    public PersonnelContext(DbContextOptions<PersonnelContext> options) : base(options) { }
    
}


