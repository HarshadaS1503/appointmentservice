import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserModel } from 'src/app/models/User';
import { AppointmentService } from 'src/app/services/appointment.service';

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
  Patient :UserModel[] =[]
  PatientName:string;
  AppointmentForm =new  FormGroup({
    MeetingTitle: new FormControl("",[Validators.required]),
    Description: new FormControl(),
    Pname: new FormControl(),
    PhName: new FormControl(),
    APTdate : new FormControl(),
  });
  data:any;
  constructor(private Appointmentservice:AppointmentService) { }

  ngOnInit(): void {
    this.getPatient();
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
      console.log(res);
      this.Patient = res;
      
      console.log(this.Patient);
    })
  }

}
