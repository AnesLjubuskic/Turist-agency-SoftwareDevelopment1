import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../../moj-config";

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {

  feedbacks:any;
  constructor(private httpKlijent:HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.httpKlijent.get(MojConfig.adresa_servera+'/Feedback/GetAll',MojConfig.http_opcije())
      .subscribe((s:any)=>{
        this.feedbacks=s;
      })
  }

  dodajFeedback(){
    this.router.navigateByUrl("feedbackPost");
  }

  home(){
    this.router.navigateByUrl('');
  }

}
