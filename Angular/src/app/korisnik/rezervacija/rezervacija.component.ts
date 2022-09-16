import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {ActivatedRoute, Router} from "@angular/router";
import {FormControl, FormGroup} from "@angular/forms";
import {Observable, Subscriber} from "rxjs";
import {SignalrService} from '../../signalr.service'


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
  selector: 'app-rezervacija',
  //template: template,
  templateUrl: './rezervacija.component.html',
  styleUrls: ['./rezervacija.component.css']
})
export class RezervacijaComponent implements OnInit {

  putovanje:any;
  id:number;
  putovanjeId:number;
  sub:any;
  ime:string="";
  prezime:string="";
  slikaUplatnice:any;
  email:string="";
  brojTelefona:string="";
  frmRezervacija:FormGroup;
  alert: boolean=false;
  text: string = "Dodanaa je nova rezervacija";

  constructor(private httpKlijent:HttpClient,private route:ActivatedRoute, private router:Router, public signalRService: SignalrService) {
  }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe((params) => {
      this.id = +params['id'];
    });

    this.frmRezervacija=new FormGroup({
      'Ime':new FormControl(),
      'Prezime':new FormControl(),
      'Email':new FormControl(),
      'BrojTelefona':new FormControl(),
      'slikaUplatnice':new FormControl(),
      'putovanjeId':new FormControl(),
    });

   this.OdabranoPutovanje();
    this.signalRService.connect();

  }

  sendMessage(): void {

    // you can send the messge direclty to the hub or use the api controller.
    // choose wisely

    debugger;
    this.signalRService.sendMessageToApi(this.text).subscribe({
      next: _ => this.text = '',
      error: (err) => console.error(err)
    });

    // this.signalRService.sendMessageToHub(this.text).subscribe({
    //   next: _ => this.text = '',
    //   error: (err) => console.error(err)
    // });
  }

  SacuvajRezervaciju() {
    this.frmRezervacija.value.ime=this.ime;
    this.frmRezervacija.value.prezime=this.prezime;
    this.frmRezervacija.value.putovanjeId=this.id;
    this.frmRezervacija.value.slikaUplatnice=this.slikaUplatnice;
    this.frmRezervacija.value.email=this.email;
    this.frmRezervacija.value.brojTelefona=this.brojTelefona;
    console.log(this.frmRezervacija);
    this.httpKlijent.post(MojConfig.adresa_servera+ "/Rezervacija/AddRezervaciju", this.frmRezervacija.value,MojConfig.http_opcije())
      .subscribe((povratnavrijednost: any) => {
        this.sendMessage();
        this.alert=true;
        setTimeout(() => {
          this.alert=false;
          this.router.navigate(['/']);
        }, 1800);
      });

    //alert("Rezervacija uspjesno dodano")
  }

  OdabranoPutovanje()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ `/Putovanje/GetPutovanjeById?putovanjeId=${this.id}`, MojConfig.http_opcije()).subscribe(x=>{
      this.putovanje = x;
    });
  }

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
      this.slikaUplatnice=d;
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
