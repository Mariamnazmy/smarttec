using BL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Manager;

    public interface IEmployeeManager
    {
      List<EmployeeDto> GetAll();
     int Add(EmployeeAddDto employeeDto);
    bool Update(EmployeeUpdateDtocs employeeUdateDto);
    void Delete(int id);
    }

