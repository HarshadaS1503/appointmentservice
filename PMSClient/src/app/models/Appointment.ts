
export class Appointment{

    visitId:number =0;
    visitTitle:string;
    visitDescription:string;
    doctorId:number=0;
    patientId:number=0;
    visitDate:Date;
    visitTime:Date;
    createdBy:number=0;
    createdOn:number=0;
    updatedBy:number=0;
    updatedOn:Date;
    visitStatusId:number=0;
    users :Users[] = new Array();

}

export class Users
{
    Title="";
    FirstName:"";
    LastName:"";
    GenderID:number;
    Address:"";
    status: Status[] = new Array();

}
export class Status
{
    StatusID:number;
    StatusName:"";
}


