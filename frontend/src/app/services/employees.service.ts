import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../model/employee.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
baseURl:string='https://localhost:7278/api/Employee';
addURl:string='https://localhost:7278/api/Employee';
  constructor(private http: HttpClient) { }

  getAllEmployees():Observable<Employee[]>{
  return  this.http.get<Employee[]>(this.baseURl)

  }

  addEmployee(addEmployeeReuest:Employee):Observable<Employee>{
    addEmployeeReuest.id=0;
   return this.http.post<Employee>(this.addURl,addEmployeeReuest)
  } 
  getEmployee(id:number): Observable<Employee>{
    return this.http.get<Employee>(this.baseURl + id );
  }

  updateEmployee(emp:Employee):Observable<Employee>{
    return this.http.put<Employee>(this.baseURl,emp)
  }
  deleteEmployee(id:number){
    return this.http.delete(this.baseURl+'/'+id);
  }
}
