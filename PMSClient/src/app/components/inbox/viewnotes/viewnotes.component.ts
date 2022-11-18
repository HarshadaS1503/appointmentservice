import { Component, OnInit } from '@angular/core';
import { ResponseModel } from 'src/app/models/responseModel';
import { NotesService } from 'src/app/services/notes.service';

@Component({
  selector: 'app-viewnotes',
  templateUrl: './viewnotes.component.html',
  styleUrls: ['./viewnotes.component.css']
})
export class ViewnotesComponent implements OnInit {

  dataTableValues: any

  totalLength:any;
  page:number=1;

  constructor(private _service: NotesService) { }

  ngOnInit(): void {
    this.getSentNotes();
  }

  getSentNotes() {

    this._service.getAllNotesBySenderId(1).subscribe((response: ResponseModel) => {
      debugger;
      this.dataTableValues = response.dataSet;
    });
  }

}
