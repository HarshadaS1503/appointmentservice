import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
  }

  PostAppointmentData()
  {
      this.Appointmentservice.postAppointmentDetails(this.data).subscribe((res)=>{

        console.log(this.data);
      })
  }

}
