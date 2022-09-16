import { Component, OnInit,Input } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MojConfig} from "../../../moj-config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-dodaj-plan',
  templateUrl: './dodaj-plan.component.html',
  styleUrls: ['./dodaj-plan.component.css']
})
export class DodajPlanComponent implements OnInit {
  sub:any;
 private id:number;
 naslov:any;
 text:any;
 frmPlan:FormGroup;
  constructor(private httpKlijent:HttpClient,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.sub=this.route.params.subscribe(params=>{
      this.id=+params["id"];
    })
    this.frmPlan=new FormGroup({
      "name":new FormControl(null,Validators.required),
      "text":new FormControl(null,Validators.required),
      "putovanjeId":new FormControl()
    });
  }

  zavrsi(){
    this.frmPlan.value.name=this.naslov;
    this.frmPlan.value.text=this.text;
    this.frmPlan.value.putovanjeId=this.id;
    this.httpKlijent.post(MojConfig.adresa_servera+"/Putovanje/AddPlanProgram",this.frmPlan.value,MojConfig.http_opcije())
      .subscribe((s:any)=>{
        this.router.navigateByUrl("/homevodic/sva-putovanja");
      });
  }

}
