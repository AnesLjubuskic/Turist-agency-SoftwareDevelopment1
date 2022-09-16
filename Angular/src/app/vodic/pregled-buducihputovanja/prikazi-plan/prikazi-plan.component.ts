import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import {MojConfig} from "../../../moj-config";

@Component({
  selector: 'app-prikazi-plan',
  templateUrl: './prikazi-plan.component.html',
  styleUrls: ['./prikazi-plan.component.css']
})
export class PrikaziPlanComponent implements OnInit {
  sub:any;
  private id:number;
  podaci:any;
  constructor(private HttpKlijent:HttpClient,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.sub=this.route.params.subscribe(params=>{
      this.id=+params["id"];

    })
    this.ucitajPlan();
  }

  ucitajPlan(){

    this.HttpKlijent.get(MojConfig.adresa_servera+`/Putovanje/GetPlanProgramById?putovanjeId=${this.id}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.podaci=x;
      console.log("evo podataka");
      console.log(this.podaci);

    });
  }

  izbrisi(s:any){
    this.HttpKlijent.delete(MojConfig.adresa_servera+`/Putovanje/DeletePlanProgram?id=${s.id}`,MojConfig.http_opcije())
      .subscribe((s:any)=>{
        this.ngOnInit();
      })
  }

}
