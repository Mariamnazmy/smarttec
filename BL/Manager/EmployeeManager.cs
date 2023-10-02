using BL.Dto;
using DAL.Model;
using smartTechTask.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Manager;

public class EmployeeManager : IEmployeeManager
{
    private readonly IEmployee _employeeRepo;

    public EmployeeManager(IEmployee employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }

    public int Add(EmployeeAddDto employeeDto)
    {
        var employee = new Employee { 
        Name = employeeDto.Name,
        Email = employeeDto.Email,
        PhoneNumber = employeeDto.PhoneNumber,
        Department = employeeDto.Department,
        Job = employeeDto.Job,
        PermissionGroup = employeeDto.PermissionGroup,
        };
        _employeeRepo.Add(employee);
        _employeeRepo.SaveChanges();
        return employee.Id;
    }

    public void Delete(int id)
    {
       var empFromDb=_employeeRepo.GetById(id);
        if(empFromDb == null) { return; }
        _employeeRepo.Delete(empFromDb);
        _employeeRepo.SaveChanges();
    }

    public List<EmployeeDto> GetAll()
    {
        IEnumerable<Employee> empFromDb= _employeeRepo.GetAll();
        return empFromDb.Select(e =>new EmployeeDto
        {
            Id= e.Id,
            Name= e.Name,
            Department= e.Department,
            Job = e.Job,
            PermissionGroup = e.PermissionGroup,
            Email= e.Email,
            PhoneNumber= e.PhoneNumber,
        }).ToList();
    }

    public bool Update(EmployeeUpdateDtocs employeeUdateDto)
    {
        var empFromDb = _employeeRepo.GetById(employeeUdateDto.Id);
        if(empFromDb == null) { return false; }

        empFromDb.Name = employeeUdateDto.Name;
        empFromDb.Job = employeeUdateDto.Job;
        empFromDb.Email = employeeUdateDto.Email;
        empFromDb.PhoneNumber = employeeUdateDto.PhoneNumber;
        empFromDb.Department = employeeUdateDto.Department;
        empFromDb.PermissionGroup= employeeUdateDto.PermissionGroup;

        _employeeRepo.Update(empFromDb);
        _employeeRepo.SaveChanges();
        return true;
    }
}

