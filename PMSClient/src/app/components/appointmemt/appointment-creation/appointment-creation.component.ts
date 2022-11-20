import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserModel } from 'src/app/models/User';
import { AppointmentService } from 'src/app/services/appointment.service';
import * as $ from 'jquery'
@Component({
  selector: 'app-appointment-creation',
  templateUrl: './appointment-creation.component.html',
  styleUrls: ['./appointment-creation.component.css']
})
export class AppointmentCreationComponent implements OnInit {
  MeetingTitle="";
  Pname:"";
  PhName:"";
  Description:"";
  APTdate:Date;
  Patient :UserModel[];
  physician: UserModel[];
  PatientName:string;
  meetingTitle:string;
  UnavailableSlots = ["11/21/2022:11", "11/22/2020:0", "11/23/2020:17"]; //your dates from database with only hr
  AppointmentForm = this.fb.group({
    MeetingTitle: new FormControl("",[Validators.required]),
    Description: new FormControl(),
    Pname: new FormControl(),
    PhName: new FormControl(),
    APTdate : new FormControl(),
  });
  
  
  data:any;
  constructor(private Appointmentservice:AppointmentService,private fb: FormBuilder) { 


  
  }

  ngOnInit(): void {
    this.getPatient();
    this.getPysician();
    
    
    
  }

  PostAppointmentData()
  {
      this.Appointmentservice.postAppointmentDetails(this.data).subscribe((res)=>{

        console.log(this.data);
      })
  }

  getPatient()
  {
    this.Appointmentservice.getUsers().subscribe(res =>{
    
      this.Patient = res;
      
      console.log(this.Patient);
      
    })
  }

  getPysician()
  {
    this.Appointmentservice.getPysician().subscribe(res =>{
      
      this.physician = res;
      
      console.log(this.physician);
    })
  }



formatDate(datestr)
{
    // var date = new Date(datestr);
    // var day = (date.getDate());
    // day = (day>9?day:"0"+day);
    // var month = date.getMonth()+1; 
    // month = month>9?month:"0"+month;
    // return month+"/"+day+"/"+date.getFullYear();
}
getAvailableSlots(date:any,id:number)
{
  this.Appointmentservice.getSlots(date,id).subscribe(res =>{
    console.log(res);
  })
}


OnDateTimeChange(event:any)
{
   let pId = this.AppointmentForm.get("PhName")?.value;
   this.getAvailableSlots(event,pId);
}



}
