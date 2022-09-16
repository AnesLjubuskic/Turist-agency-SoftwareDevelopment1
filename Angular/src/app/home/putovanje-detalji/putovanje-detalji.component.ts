import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
import {TranslateService} from "@ngx-translate/core";
@Component({
  selector: 'app-putovanje-detalji',
  templateUrl: './putovanje-detalji.component.html',
  styleUrls: ['./putovanje-detalji.component.css']
})
export class PutovanjeDetaljiComponent implements OnInit {
sub:any;
id:any;
plan:any;
putovanje:any;
gradovi:any;
  constructor(private route:ActivatedRoute, private HttpKlijent:HttpClient, private router:Router, private translateService:TranslateService) { }

  ngOnInit(): void {
    this.sub=this.route.params.subscribe((params)=>{
      this.id=+params['id'];
    })
    this.HttpKlijent.get(MojConfig.adresa_servera+`/Putovanje/GetPutovanjeById?putovanjeId=${this.id}`,MojConfig.http_opcije()).subscribe(
      (res:any)=> {
        this.putovanje=res;
        this.translateService.get([res])
          .subscribe((x: any) => {
          //this.putovanje = x;
        })

      });

    this.HttpKlijent.get(MojConfig.adresa_servera+`/Putovanje/GetGradoviByPutovanjeId?putovanjeId=${this.id}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.gradovi=x;
    });

    this.HttpKlijent.get(MojConfig.adresa_servera+`/Putovanje/GetPlanProgramById?putovanjeId=${this.id}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.plan=x;
    });
  }

  rezervacija() {
    this.router.navigate(['/rezervacija', this.id]);
  }



}
