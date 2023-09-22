using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartTechTask.DAL;

    public interface IEmployee
    {
    IEnumerable<Employee> GetAll();

     Employee? GetById(int id);
      void Add(Employee employee);
    void Update(Employee employee);
    void Delete(Employee employee);
    int SaveChanges(); 

    }
