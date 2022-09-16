import { Component, OnInit } from '@angular/core';
import {Form, FormControl, FormGroup, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

@Component({
  selector: 'app-smjestaj',
  templateUrl: './smjestaj.component.html',
  styleUrls: ['./smjestaj.component.css']
})
export class SmjestajComponent implements OnInit {
frmDrzava:FormGroup;
frmGrad:FormGroup;
frmSmjestaj:FormGroup;
drzavaList:any;
gradoviList:any;

  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.frmDrzava = new FormGroup({
      'naziv': new FormControl(null,[Validators.required,Validators.pattern (/^[A-Za-z\s]+$/)]),
      'oznaka':new FormControl(null,[Validators.required,Validators.pattern (/^[A-Za-z]+$/),Validators.maxLength(3)]),
    });
    this.getDrzaveList();
    this.frmGrad = new FormGroup({
      'naziv': new FormControl(null,[Validators.required,Validators.pattern (/^[A-Za-z\s]+$/)]),
      'postanskiBroj':new FormControl(),
      'drzavaId': new FormControl(Validators.required),
    });
    this.getGradoviList();
    this.frmSmjestaj=new FormGroup({
      'naziv':new FormControl(null,Validators.required),
      'tip':new FormControl(null,Validators.required),
      'opis':new FormControl(),
      'kapacitet':new FormControl(null,[Validators.required,Validators.pattern(/^\d+$/)]),
      'adresa':new FormControl(null,Validators.required),
      'gradId':new FormControl(null,Validators.required),
    })
  }
  spasiDrzavu(){
    console.log(this.frmDrzava.value);
    this.httpKlijent.post(MojConfig.adresa_servera + "/api/Drzava", this.frmDrzava.value,MojConfig.http_opcije()).subscribe((povratnavrijednost: any) => {
      window.location.reload();
  })
  }
  getDrzaveList(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/api/Drzava",MojConfig.http_opcije()).subscribe(x=>this.drzavaList=x);;
  }
  spasiGrad(){
    this.httpKlijent.post(MojConfig.adresa_servera+"/Grad/Add",this.frmGrad.value,MojConfig.http_opcije()).subscribe((povratnaVrijednost:any)=>{
      window.location.reload();
    })
  }
  getGradoviList(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/Grad/GetAll",MojConfig.http_opcije()).subscribe((povratnaVrijednost:any)=>this.gradoviList=povratnaVrijednost);
  }
  spasiSmjestaj(){
    this.httpKlijent.post(MojConfig.adresa_servera+"/Smjestaj/Add",this.frmSmjestaj.value,MojConfig.http_opcije()).subscribe(x=>{
      window.location.reload();
    })
  }

}
