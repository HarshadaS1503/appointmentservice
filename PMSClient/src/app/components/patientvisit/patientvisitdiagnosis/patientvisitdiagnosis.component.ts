import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { PatientDiagnosisModel } from 'src/app/models/diagnosis';
import { PatientService } from 'src/app/services/patient/patient.service';

@Component({
  selector: 'app-patientvisitdiagnosis',
  templateUrl: './patientvisitdiagnosis.component.html',
  styleUrls: ['./patientvisitdiagnosis.component.css']
})
export class PatientvisitdiagnosisComponent implements OnInit {

  result: any[]=[]; 
  diagnosis_Desc:any='';
  isDepricated:boolean=false;
  submitted = false;
  patientDiagnosisForm: any;
  sections: any;//array to reolicate diagnosis section
  secCount:number=1;
  response: any;
  output: any;
  diagnosisobjPatien:PatientDiagnosisModel;
  patientId:number=1;
  diagnosisobj: PatientDiagnosisModel;
  constructor( private toast : NgToastService,private fb:FormBuilder,private router:Router, private formBuilder:FormBuilder,private service:PatientService) { }

  ngOnInit() {
    this.getMasterDiagnosis();
    this.patientDiagnosisForm = this.fb.group({
      diagnosisCode: new FormControl('', [Validators.required]),
      diagnosisDesc: new FormControl('', [Validators.required]),
      isDeprecated : new FormControl('', [Validators.required]),
    });
    this.sections=[{secCount:this.secCount}];
  }
  getMasterDiagnosis(){
    this.service.getDiagnosis().subscribe((data)=>{
      this.response=data.dataSet;
      console.log(this.response);
      this.result=this.response;
      console.log(this.result);
    })
  }

  addDiagnosis() {
    console.log("new section added");
    this.secCount++;
    var item={secCount:this.secCount};
    this.sections.push(item);
  }
  onChange($event){

  }
  onDropdownChange(event){
    console.log(event);
   
    console.log(this.result);
    this.output=this.result.find(x=>x.diagnosisCode == event);
    console.log(this.output);
    this.diagnosis_Desc=this.output.diagnosisDescription;
    console.log(this.diagnosis_Desc);
    console.log(this.output.diagnosisIsDepricated);
    this.isDepricated=this.output.diagnosisIsDepricated;
    console.log(this.isDepricated);

    // this.patientDiagnosisForm.patchValue({
    //   isDeprecated: this.output.diagnosisIsDepricated
    // });
    // const control2= this.patientDiagnosisForm.get('isDeprecated')

    // if (control2 instanceof FormControl) {

    //   control2.setValue(this.isDepricated);

   // }
    

  }

  onSubmit() {
    this.submitted = true;
 console.log(this.patientDiagnosisForm.value);
    // stop here if form is invalid
    
    if (this.patientDiagnosisForm.valid) {
      this.diagnosisobj=new PatientDiagnosisModel();
       this.diagnosisobj.DiagnosisId=Number(this.output.diagnosisCode) ;
       this.diagnosisobj.PatientId=this.patientId;
       this.diagnosisobj.Description=this.output.diagnosisDescription;
      console.log(this.diagnosisobj);
    //    this.diagnosisobj.Is_Allergy_Fatal=this.allergydetails.get('Is_Fatal')?.value;
    // if (this.patientDiagnosisForm.invalid) {
      this.service.postDiagnosis(this.diagnosisobj).subscribe( (response:any)=>{
        // this.toast.success('Form Successfully Submitted!');    
  
        });
    }

    this.toast.success({detail:"Success Message",summary:"Data saved!",duration:3000});

  }


  edit(){
    console.log("edit activated");
  }

}
