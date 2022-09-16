import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";

interface Alert {
  type: string;
  message: string;
}
declare function porukaSuccess(a: string):any;
const template = `
<ngfFormData
  [files]      = "files"
  [(FormData)] = "myFormData"
  postName     = "file"
></ngfFormData>

<ngfUploadStatus
  [(percent)] = "uploadPercent"
  [httpEvent] = "httpEvent"
></ngfUploadStatus>

<div *ngIf="uploadPercent">
  Upload Progress: {{ uploadPercent }}%
</div>
`
@Component({
  selector: 'app-putovanje-prevoz',
  templateUrl: './putovanje-prevoz.component.html',
  styleUrls: ['./putovanje-prevoz.component.css']
})
export class PutovanjePrevozComponent implements OnInit {

  frmPrevoz:FormGroup;
  listPrijevoz:any;

  PutovanjePodaci:any;
  prevoznoSredstvoId:any;
  putovanjeId:any;
  posljPut:any;
  alert:boolean=false;
  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.frmPrevoz=new FormGroup({
      'prevoznoSredstvoId':new FormControl(),
      'putovanjeId':new FormControl()
    });
    this.getPrijevoz()
    this.getPosljednjePutovanje();
  }

  PostPutovanjePrevoz():void
  {
    this.PutovanjePodaci = Object.assign(this.frmPrevoz.value);
    this.PutovanjePodaci.putovanjeId = Number(this.PutovanjePodaci.putovanjeId);
    this.PutovanjePodaci.prevoznoSredstvoId = Number(this.PutovanjePodaci.prevoznoSredstvoId);
    this.httpKlijent.post(MojConfig.adresa_servera + "/Putovanje/AddPutovanjePrevoz", this.PutovanjePodaci,MojConfig.http_opcije()).subscribe((povratnavrijednost: any) => {
      console.log(povratnavrijednost)});
    this.alert=true;
    setTimeout(() => {
      this.alert=false;
    }, 1800);
  }


  getPrijevoz():void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/PrevoznoSredstvo/GetAll",MojConfig.http_opcije()).subscribe(x=> this.listPrijevoz=x );
    console.log(this.listPrijevoz);
  }

  getPosljednjePutovanje():void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Putovanje/GetPosljednjePutovanje",MojConfig.http_opcije()).subscribe(x=> this.posljPut=x );

  }
}
