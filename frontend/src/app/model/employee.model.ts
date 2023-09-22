export class Employee{
    constructor(
       public id:number=0,
       public name: string ='',
        public email: string='',
        public phoneNumber: string='',
        public department:string='',
       public salary : number=0,
        public job:string='',
    
        public permissionGroup:number=0
    ){}
   
}