using DAL.Context;
using DAL.Model;
using smartTechTask.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo;

public class EmployeeRepo : IEmployee
{ private readonly PersonnelContext _personnelContext;

    public EmployeeRepo(PersonnelContext personnelContext)
    {
        _personnelContext = personnelContext;
    }
    public void Add(Employee employee)
    {
        _personnelContext.Employees.Add(employee);
    }

    public void Delete(Employee employee)
    {
       _personnelContext.Employees.Remove(employee);
    }

    public IEnumerable<Employee> GetAll()
    {
        return _personnelContext.Employees;
    }

    public Employee? GetById(int id)
    {
        return _personnelContext.Employees.Find(id);
    }

    public int SaveChanges()
    {
        return _personnelContext.SaveChanges();
    }

    public void Update(Employee employee)
    {
       
    }
}

