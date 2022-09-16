import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../moj-config";

@Component({
  selector: 'app-aviokompanija',
  templateUrl: './aviokompanija.component.html',
  styleUrls: ['./aviokompanija.component.css']
})
export class AviokompanijaComponent implements OnInit {
  naziv:string='';
  mail:string='';
  frmAvion:FormGroup;
  kapacitet:number=0;
  telefon:string='';
  @Input() slanje:any;
  @Output() prikazi=new EventEmitter();
  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.frmAvion=new FormGroup({
      'naziv':new FormControl(null,Validators.required),
      'kapacitet':new FormControl(null,
        [Validators.required,
          Validators.pattern("^[0-9]*$"),
          Validators.maxLength(2)]),
      'mail':new FormControl(null,[Validators.required,Validators.email]),
      'telefon':new FormControl(null,[Validators.required,Validators.pattern('\\d+'),Validators.minLength(9)])
    });
  }

  snimi(){
    this.frmAvion.value.naziv=this.naziv;
    this.frmAvion.value.kapacitet=this.kapacitet;
    this.frmAvion.value.klima=this.mail;
    this.frmAvion.value.telefon=this.telefon;
    this.httpKlijent.post(MojConfig.adresa_servera+"/Aviokompanija/Add",this.frmAvion.value,MojConfig.http_opcije()).subscribe((x:any)=>{
      console.log(this.frmAvion.value);
      this.zatvori();
    })
    console.log(this.frmAvion.value);
  }

  zatvori(){
    this.prikazi.emit();
  }

}
