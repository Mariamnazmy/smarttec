import { Component,OnInit } from '@angular/core';
import { EmployeesService } from './services/employees.service';
import { Employee } from './model/employee.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  selectedDepartment: string = '';
  selectedJob:string='';
  selectedGroup:number=0;
  title = 'app';
  currentEmployeeIndex:number=0;
 employees:Employee[]=[{
  id:0,
  salary:0, 
  name:'',
  email:'',
  phoneNumber:'',
  department:'',
  job:'',
  permissionGroup:0


 }];
 addEmployeereq:Employee={
  id:0,
  salary:0, 
  name:'',
  email:'',
  phoneNumber:'',
  department:'',
  job:'',
  permissionGroup:0


 };
  constructor(private employeesServices:EmployeesService){}
  

  ngOnInit(): void {
    console.log('Before fetching data:', this.employees);
  this.employeesServices.getAllEmployees().subscribe({
    next: (employees) => {
      
      this.employees = employees;
      // this.initializeEmployeeData();
      console.log('after fetching data:', this.employees);
      console.log(employees);
    },
    error: (response) => {
      console.log(response);
    }
  });

} 
addEmployee(){
  console.log(this.employees[this.currentEmployeeIndex]);
  this.employeesServices.addEmployee(this.employees[this.currentEmployeeIndex])
  .subscribe({
    next:(employee)=> {
      alert("employee added successfully");
      console.log(employee)},
    error: (response) => {
      console.log(response);
    }
  })
} 
// getEmployee(emdid:number){
//   if(emdid){
//     this.employeesServices.getEmployee(emdid).subscribe({
//       next:(response) => {this.employees[0]=response}
//     })
//   }
// }

updateEmployee(){
  console.log('Employee to update:', this.employees[this.currentEmployeeIndex]);
  const employeeToUpdate = this.employees[this.currentEmployeeIndex];
  if(!employeeToUpdate){console.error('Selected employee is null or undefined.');
  return;}
  employeeToUpdate.name=this.employees[this.currentEmployeeIndex].name;
  employeeToUpdate.email=this.employees[this.currentEmployeeIndex].email;
  employeeToUpdate.phoneNumber=this.employees[this.currentEmployeeIndex].phoneNumber;
  employeeToUpdate.department=this.employees[this.currentEmployeeIndex].department;
  employeeToUpdate.permissionGroup=this.employees[this.currentEmployeeIndex].permissionGroup;
  this.employeesServices.updateEmployee(employeeToUpdate).subscribe({
    next:()=> {
      alert("employee updated successfully");
      console.log('updated')},
  
    error: (response) => {
      console.log(response);
    }
  });
}
deleteEmployee(id:number){
  this.employeesServices.deleteEmployee(id)
  .subscribe({
    next:() =>{
      alert("employee deleted successfully");
      console.log('deleted');
    },
    error: (response) => {
      console.log(response);
    }
  })
}
playNext(){
  if (this.currentEmployeeIndex < this.employees.length - 1) {
    this.currentEmployeeIndex++;
  }
  else {
    
    this.currentEmployeeIndex = 0;
  }
}
playPrevious(){
  if (this.currentEmployeeIndex > 0) {
    this.currentEmployeeIndex--;
  }
}
  getEmployeeByIndex(index: number): Employee {
    return this.employees[index];
  }
  selectDepartment(department: string) {
    this.addEmployeereq.department = department;
  }
  selectJob(job:string){this.addEmployeereq.job=job}
  selectGroup(group:number){this.addEmployeereq.permissionGroup=group}
}
