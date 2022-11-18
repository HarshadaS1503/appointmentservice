import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NotesModel } from 'src/app/models/notes';
import { ResponseModel } from 'src/app/models/responseModel';
import { NotesService } from 'src/app/services/notes.service';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-receivednotes',
  templateUrl: './receivednotes.component.html',
  styleUrls: ['./receivednotes.component.css']
})
export class ReceivednotesComponent implements OnInit {

  dataTableValues: any;
  sendNoteForm!: FormGroup;
  senderId = 0;
  noteId = 0;
  sendNoteId = 0;
  delNoteId = 0;
  senderName = "";
  senderDesignation = "";
  noteobj!: NotesModel;

  totalLength: any;
  page: number = 1;

  constructor(private _service: NotesService, private _formBuilder: FormBuilder, private _toast: NgToastService) { }

  ngOnInit(): void {
    this.getReceivedNotes();

    this.sendNoteForm = this._formBuilder.group({
      message: new FormControl('', [Validators.required]),
      urgency: new FormControl('true', [Validators.required])
    });
  }

  getReceivedNotes() {
    this._service.getAllNotesByReceiverId(10).subscribe((response: ResponseModel) => {
      debugger;
      this.dataTableValues = response.dataSet;
      console.log(this.dataTableValues);
    });
  }

  sendReply(values: any) {
    debugger;
    this.sendNoteId = values.noteId;
    this.senderId = values.senderId;
    this.senderName = values.senderName;
    this.senderDesignation = values.senderDesignation;



  }

  deleteNote(values: any) {
    debugger;
    console.log(values);
    this.delNoteId = values.noteId;
  }

  deleteReceivedNote() {
    //let delteNoteObj: NotesModel = new NotesModel();
    let deleteNoteId = this.delNoteId;
    //delteNoteObj.SenderId = this.senderId;
    this._service.deleteNoteByid(deleteNoteId).subscribe((response: ResponseModel) => {
      if (response.responseCode == 1) {
        console.log(response.responseMessage);
        this._toast.success({ detail: "Note Deleted", summary: "Successfully!", duration: 3000 });
        this.ngOnInit();
      }
      else {
        this._toast.error({ detail: "Error in deleting notes", summary: "Failure!", duration: 3000 });
      }
    });
  }

  sendReplyNote() {
    debugger;
    if (this.sendNoteForm.valid) {
      this.noteobj = new NotesModel();
      this.noteobj.receiverId = this.senderId;
      this.noteobj.receiveName = this.senderName;
      this.noteobj.receiverDesignation = this.senderDesignation;
      this.noteobj.senderId = 10;
      this.noteobj.senderDesignation = "Mr Luke Walker";
      this.noteobj.senderName = "Mohan";
      this.noteobj.message = this.sendNoteForm.get('message')?.value;
      this.noteobj.isUrgent = this.sendNoteForm.get('urgency')?.value == "true" ? true : false;
      this.noteobj.replyId = this.sendNoteId;
      this.noteobj.isResponded = false;
      console.log(this.noteobj);
      this._service.sendNotes(this.noteobj).subscribe((data: ResponseModel) => {
        if (data.responseCode == 1) {
          this._toast.success({ detail: "Reply Sent", summary: "Successfully!", duration: 3000 });
        }
        else {
          this._toast.error({ detail: "Error in inserting notes", summary: "Error Failure!", duration: 3000 });
        }
      });
    }
  }

}
