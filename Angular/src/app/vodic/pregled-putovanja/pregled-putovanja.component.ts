import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {MatTabsModule} from '@angular/material/tabs';

@Component({
  selector: 'app-pregled-putovanja',
  templateUrl: './pregled-putovanja.component.html',
  styleUrls: ['./pregled-putovanja.component.css']
})
export class PregledPutovanjaComponent implements OnInit {
  prevoznaSredstva1:any;
  prevoznaSredstva2:any;
  autobus:boolean=false;
  avioKompanija:boolean=false;
  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.getApiAutobus();
    this.getAPIAvion();
  }

  getApiAutobus():void{
    this.autobus=true;
    this.avioKompanija=false;
    this.httpKlijent.get(MojConfig.adresa_servera+'/Autobus/GetAll',MojConfig.http_opcije()).subscribe(x=>{
      this.prevoznaSredstva1=x;
    })
  }

  getAutobus(){
    if(this.prevoznaSredstva1==null) return [];
    return this.prevoznaSredstva1;
  }

  getAPIAvion(){
    this.autobus=false;
    this.avioKompanija=true;
    this.httpKlijent.get(MojConfig.adresa_servera+'/Aviokompanija/GetAll',MojConfig.http_opcije()).subscribe(x=>{this.prevoznaSredstva2=x;})
  }

  getAvion(){
    if(this.prevoznaSredstva2==null) return [];
    return this.prevoznaSredstva2;
  }

}
