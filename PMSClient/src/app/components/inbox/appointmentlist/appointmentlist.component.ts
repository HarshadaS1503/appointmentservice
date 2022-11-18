import { Component, OnInit } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';
import { ResponseModel } from 'src/app/models/responseModel';
import { updateappointment } from 'src/app/models/updateappointment';
import { NotesService } from 'src/app/services/notes.service';

@Component({
  selector: 'app-appointmentlist',
  templateUrl: './appointmentlist.component.html',
  styleUrls: ['./appointmentlist.component.css']
})
export class AppointmentlistComponent implements OnInit {

  dataTableValues: any;
  appointmentId = 0;

  totalLength: any;
  page: number = 1;

  constructor(private _service: NotesService, private _toast: NgToastService) { }

  ngOnInit(): void {
    this.GettAppointmentsList();
  }

  GettAppointmentsList() {
    this._service.getAllAppointments(1).subscribe((response: ResponseModel) => {
      if (response.responseCode == 1) {
        debugger;
        this.dataTableValues = response.dataSet;

        this.totalLength = response.dataSet.length;
        console.log(this.totalLength);

        //this.appointmentCount=this.response2.length;
        //console.log('appoint', this.response2.length);

      }
    });
  }

  updateAppointment(val: any) {
    this.appointmentId = val.visitId;
  }

  updateAppointmentStatus(statusId: any) {
    let updateAppointmentObj: updateappointment = new updateappointment();
    updateAppointmentObj.AppointmentId = this.appointmentId;
    updateAppointmentObj.UpdateType = statusId;

    this._service.updateAppointmentStatus(updateAppointmentObj).subscribe((response: any) => {
      if (response.responseCode == 1) {
        this._toast.success({ detail: "Appointment Accepted", summary: "Successfully!", duration: 3000 });
        this.ngOnInit();
      }
      else {
        this._toast.error({ detail: "Failed to accept Appointment", summary: "Error!", duration: 3000 });
      }
    });



  }

}
