import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MojConfig} from "../../../moj-config";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;
@Component({
  selector: 'app-feedback-postavi',
  templateUrl: './feedback-postavi.component.html',
  styleUrls: ['./feedback-postavi.component.css']
})
export class FeedbackPostaviComponent implements OnInit {

  ime:any;
  sadrzaj:any;
  frmFeedback:FormGroup;
  constructor(private httpKlijent:HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.frmFeedback=new FormGroup({
      "ime":new FormControl(null,Validators.required),
      "sadrzaj":new FormControl(null,Validators.required)
    });
  }

  apliciraj(){
    this.frmFeedback.value.ime=this.ime;
    this.frmFeedback.value.sadrzaj=this.sadrzaj;
    this.httpKlijent.post(MojConfig.adresa_servera+"/Feedback/Postavi",this.frmFeedback.value,MojConfig.http_opcije())
      .subscribe((s:any)=>{
          this.router.navigateByUrl("feedback");
      });
  }


}
