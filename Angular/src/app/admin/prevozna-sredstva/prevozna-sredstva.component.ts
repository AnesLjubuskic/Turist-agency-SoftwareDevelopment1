import { Component, OnInit } from '@angular/core';
import {HttpClient,HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
@Component({
  selector: 'app-prevozna-sredstva',
  templateUrl: './prevozna-sredstva.component.html',
  styleUrls: ['./prevozna-sredstva.component.css']
})
export class PrevoznaSredstvaComponent implements OnInit {
  prevoznaSredstva1:any;
  prevoznaSredstva2:any;
  autobus:boolean=false;
  avioKompanija:boolean=false;
  dodajBus:boolean=false;
  dodajAvion:boolean=false;
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

  dodajBuss(){
    this.dodajBus = true;
    this.dodajAvion=false;
    console.log(this.dodajBus)
  }

  dodajAvionn(){
    this.dodajAvion=true;
    this.dodajBus=false;
    console.log(this.dodajAvion);
  }

  zatvoriOba(){
    this.dodajAvion=false;
    this.dodajBus=false;
  }

}
