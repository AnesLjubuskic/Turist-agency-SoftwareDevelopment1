import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MojConfig} from "../../moj-config";
import {Observable, Subscriber} from "rxjs";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;
@Component({
  selector: 'app-aplikacija',
  templateUrl: './aplikacija.component.html',
  styleUrls: ['./aplikacija.component.css']
})
export class AplikacijaComponent implements OnInit {

  ime:any;
  prezime:any;
  zanimanje:any;
  cv:any;
  frmZanimanje:FormGroup;
  constructor(private httpKlijent: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.frmZanimanje = new FormGroup({
      'ime': new FormControl(null, Validators.required),
      'prezime': new FormControl(null, Validators.required),
      'zanimanje': new FormControl(null, Validators.required),
      'cv':new FormControl()
    })
  }

  apliciraj(){
    this.frmZanimanje.value.ime=this.ime;
    this.frmZanimanje.value.prezime=this.prezime;
    this.frmZanimanje.value.zanimanje=this.zanimanje;
    this.frmZanimanje.value.cv=this.cv;
    this.httpKlijent.post(MojConfig.adresa_servera+"/api/AplikacijaPosao/Add",this.frmZanimanje.value,MojConfig.http_opcije())
      .subscribe((x:any)=>{
        this.router.navigateByUrl("/aplikacijaCV");
      },()=>{porukaError("Neuspjeh!")})
  }

  onChange($event:Event) {
    const file=($event.target as HTMLInputElement).files[0];
    console.log(file);
    this.convertToBase64(file);
  }

  convertToBase64(file:File) {
    const observable = new Observable((subscriber: Subscriber<any>) => {
      this.readFile(file, subscriber);
    })
    observable.subscribe((d) => {
      console.log(d);
      this.cv = d;
    })
  }

  readFile(file:File, subsicriber:Subscriber<any>) {
    const fileReader = new FileReader();
    fileReader.readAsDataURL(file);

    fileReader.onload = () => {
      subsicriber.next(fileReader.result);
      subsicriber.complete();
    }
    fileReader.onerror = (error) => {
      subsicriber.error(error);
    }
  }

}
