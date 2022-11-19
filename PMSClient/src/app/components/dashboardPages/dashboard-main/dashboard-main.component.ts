import { Component, OnInit } from '@angular/core';
import { ResponseModel } from 'src/app/models/responseModel';
import { NotesService } from 'src/app/services/notes.service';

@Component({
  selector: 'app-dashboard-main',
  templateUrl: './dashboard-main.component.html',
  styleUrls: ['./dashboard-main.component.css']
})
export class DashboardMainComponent implements OnInit {

  dashboardValues: any;
  response2!: any;
  appointmentCount:number=0;

  constructor(private _service: NotesService,) { }

  ngOnInit(): void {
    this.loadAppointments();
  }

  loadAppointments() {
    this._service.getAllAppointments(1).subscribe((response: ResponseModel) => {
      if (response.responseCode == 1) {
        debugger;
        this.response2 = response.dataSet;
        console.log(this.response2);

        this.appointmentCount=this.response2.length;
        console.log('appoint', this.response2.length);

      }
    });
  }

}
