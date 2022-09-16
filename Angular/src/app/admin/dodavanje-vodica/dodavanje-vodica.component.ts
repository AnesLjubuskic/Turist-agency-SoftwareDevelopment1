import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {Observable, Subscriber} from "rxjs";
import {Router} from "@angular/router";

interface Alert {
  type: string;
  message: string;
}
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;
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
  selector: 'app-dodavanje-vodica',
  templateUrl: './dodavanje-vodica.component.html',
  styleUrls: ['./dodavanje-vodica.component.css']
})
export class DodavanjeVodicaComponent implements OnInit {
  ime:string="";
  prezime:string="";
  email:string="";
  password:string="";
  slika:any;
  frmVodicPodaci:FormGroup;
  frmVodicSlika:FormGroup;
  imageUrl:string;
  vodicId:any;
  vodic:any;
  datumRodj:any;
  alert:boolean=false;
  alertError:boolean=false;
  constructor(private HttpKlijent:HttpClient, private router:Router) { }

  ngOnInit(): void {
    this.frmVodicPodaci=new FormGroup({
      'ime':new FormControl(null,Validators.required),
      'prezime':new FormControl(null,Validators.required),
      'email':new FormControl(null,Validators.email),
      'lozinka':new FormControl(),
      'brojTelefona':new FormControl(null,[Validators.required,Validators.pattern('\\d+'),Validators.minLength(9)]),
      'korisnickoIme':new FormControl()
    });

    this.frmVodicSlika=new FormGroup({
      'datumRodjenja':new FormControl(),
      'slika':new FormControl()
    })
  }


  generisiPassword():string{
    this.password=Math.random().toString(36).slice(-8);
    return this.password;
  }

  posaljiNoviVodic():void{
    this.frmVodicPodaci.value.email=this.email;
    this.frmVodicPodaci.value.lozinka=this.password;
    this.frmVodicPodaci.value.korisnickoIme=this.ime.toLowerCase()+this.prezime.toLowerCase();
    this.frmVodicSlika.value.slika=this.slika;

    this.vodic = Object.assign(this.frmVodicPodaci.value, this.frmVodicSlika.value);


    console.log(this.vodic);
    this.HttpKlijent.post(MojConfig.adresa_servera + "/Vodic/AddVodic", this.vodic,MojConfig.http_opcije()).subscribe((povratnavrijednost: any) => {
      console.log(povratnavrijednost)
      this.vodicId=povratnavrijednost.id;
      this.alert=true;
      setTimeout(() => {
        this.alert=false;
        window.location.reload();
      }, 3000);
    },
      (error => {
        this.alertError=true;
        setTimeout(()=>{
          this.alertError=false;},3000
        )
      })
)


  }

  onSelectFile(e: any) {
    if (e.target.files) {
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0]);
      reader.onload = (event: any) => {
        this.imageUrl = event.target.result;
      }
    }
  }
/*spasiSliku(){
   var saljemo={
      slika:this.imageUrl
    }
    console.log(saljemo);
  this.HttpKlijent.post(MojConfig.adresa_servera + `/api/Vodic/AddProfileImage?id=${this.vodicId}`, saljemo).subscribe((povratnavrijednost: any) => {
    console.log(povratnavrijednost)
    this.imageUrl=povratnavrijednost.slika;
  })
}*/
  /*posaljiSliku():void{


    /*this.HttpKlijent.post(MojConfig.adresa_servera + "/api/Vodic/AddProfileImage/"+, this.frmVodicPodaci.value).subscribe((povratnavrijednost: any) => {
      console.log(povratnavrijednost)})
  }*/

  onChange($event:Event) {
    const file=($event.target as HTMLInputElement).files[0];
    console.log(file);
    this.convertToBase64(file);
  }

  convertToBase64(file:File)
  {
    const observable=new Observable((subscriber:Subscriber<any>)=>
    {
      this.readFile(file, subscriber);
    })
    observable.subscribe((d)=>{
      console.log(d);
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
