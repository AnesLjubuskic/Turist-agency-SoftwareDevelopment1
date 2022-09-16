import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MojConfig} from "../../moj-config";
import {Observable, Subscriber} from "rxjs";

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
  selector: 'app-dodavanje-putovanja',
  templateUrl: './dodavanje-putovanja.component.html',
  styleUrls: ['./dodavanje-putovanja.component.css']
})
export class DodavanjePutovanjaComponent implements OnInit {

  naziv:string="";
  tipPutovanja:string="";
  brojPutnika:number=0;
  cijena:number=0;
  trajanje:number=0;
  datumOd:any;
  datumDo:any;
  nazivSmjestaj:string="";
  nazivPrijevoz:string="";
  listSmjestaj:any;
  slika:any;
  gradovi:any;
  brojac:number=0;

  frmPutovanje:FormGroup;
  frmSmjestaj:FormGroup;
  frmPrevoz:FormGroup;
  frmSlika:FormGroup;
  frmGrad:FormGroup;

  PutovanjePodaci:any;
  PutovanjeGrad:any;
  smjestajId:any;
  putovanjeId:any;

  tipovi: string[] = ['Avionom','Autobusom'];
  posljPut:any;
  alert:boolean=false;
  alertGrad:boolean=false;
  alertSmjestaj:boolean=false;

  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.frmPutovanje=new FormGroup({
      'naziv':new FormControl(null,Validators.required),
      'tipPutovanja':new FormControl(null,Validators.required),
      'brojPutnika':new FormControl(null, [Validators.required, Validators.pattern("^[0-9]*$"),  Validators.maxLength(3)]),
       'cijena':new FormControl(null, [Validators.required, Validators.pattern("^[0-9]*$"),  Validators.maxLength(5)]),
       'trajanje':new FormControl(null, [Validators.required, Validators.pattern("^[0-9]*$"),  Validators.maxLength(3)]),
      'datumOd':new FormControl(),
      'datumDo':new FormControl(),
      /*'nazivSmjestaj':new FormControl(),
      'nazivPrijevoz':new FormControl(),*/
    });
    this.frmSmjestaj=new FormGroup({
      'smjestajId':new FormControl(),
      'putovanjeId':new FormControl()
    });
    this.frmPrevoz=new FormGroup({
      'prevoznoSredstvoId':new FormControl(),
      'putovanjeId':new FormControl()
    });
    this.frmGrad=new FormGroup({
      'gradId':new FormControl(),
      'putovanjeId':new FormControl()
    });
    this.frmSlika=new FormGroup({
      'slika':new FormControl()
    });

    this.brojac=0;
    this.getGradoviList();
    this.getSmjestaj();
    this.getPosljednjePutovanje();


  }

  PostPutovanje():void
  {
    this.frmPutovanje.value.naziv=this.naziv;
    this.frmPutovanje.value.tipPutovanja=this.tipPutovanja;
    this.frmPutovanje.value.brojPutnika=this.brojPutnika;
    this.frmPutovanje.value.cijena=this.cijena;
    this.frmPutovanje.value.trajanje=this.trajanje;
    this.frmPutovanje.value.datumOd=this.datumOd;
    this.frmPutovanje.value.datumDo=this.datumDo;
    this.frmPutovanje.value.slika=this.slika;

    this.httpKlijent.post(MojConfig.adresa_servera + "/Putovanje/AddPutovanje", this.frmPutovanje.value,MojConfig.http_opcije()).subscribe((povratnavrijednost: any) => {
      this.alert=true;
      })

    setTimeout(() => {
      this.alert=false;
      window.location.reload();
    }, 1800);

  }


  PostPutovanjeSmjestaj():void
  {
    this.PutovanjePodaci = Object.assign(this.frmSmjestaj.value);
    this.PutovanjePodaci.putovanjeId = Number(this.PutovanjePodaci.putovanjeId);
    this.PutovanjePodaci.smjestajId = Number(this.PutovanjePodaci.smjestajId);
    this.httpKlijent.post(MojConfig.adresa_servera + "/Putovanje/AddPutovanjeSmjestaj", this.PutovanjePodaci,MojConfig.http_opcije()).subscribe((povratnavrijednost: any) => {
      this.alertSmjestaj=true;
    });

    setTimeout(() => {
      this.alertSmjestaj=false;
    }, 1800);
  }

  PostPutovanjeGrad():void
  {
    this.PutovanjeGrad = Object.assign(this.frmGrad.value);
    this.PutovanjeGrad.putovanjeId = Number(this.PutovanjeGrad.putovanjeId);
    this.PutovanjeGrad.gradId = Number(this.PutovanjeGrad.gradId);

    this.httpKlijent.post(MojConfig.adresa_servera + "/Putovanje/AddPutovanjeGrad", this.PutovanjeGrad,MojConfig.http_opcije()).subscribe((povratnavrijednost: any) => {

      this.alertGrad=true;});

    setTimeout(() => {
      this.alertGrad =false;
    }, 1800);
  }

PostSlika():void{

}

  getSmjestaj():void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Smjestaj/GetAll",MojConfig.http_opcije()).subscribe(x=> this.listSmjestaj=x );
  }

  getPosljednjePutovanje():void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+"/Putovanje/GetPosljednjePutovanje",MojConfig.http_opcije()).subscribe(x=> this.posljPut=x );

  }
  getGradoviList(){
    this.httpKlijent.get(MojConfig.adresa_servera+"/Grad/GetAll",MojConfig.http_opcije()).subscribe((povratnaVrijednost:any)=>this.gradovi=povratnaVrijednost);
  }

  onChange($event:Event) {
    const file=($event.target as HTMLInputElement).files[0];
    this.convertToBase64(file);
  }

  convertToBase64(file:File)
  {
    const observable=new Observable((subscriber:Subscriber<any>)=>
    {
      this.readFile(file, subscriber);
    })
    observable.subscribe((d)=>{
      this.slika=d;
    })

  }

  readFile(file:File, subsicriber:Subscriber<any>)
  {
    const fileReader=new FileReader();
    fileReader.readAsDataURL(file);

    fileReader.onload=()=>
    {
      subsicriber.next(fileReader.result);
      subsicriber.complete();
    }
    fileReader.onerror=(error)=>
    {
      subsicriber.error(error);
    }
  }



}
