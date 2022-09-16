import {Component, Input, OnInit, Output} from '@angular/core';
import {FormControl, FormControlName, FormGroup, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../../moj-config";
import {EventEmitter} from "@angular/core";
@Component({
  selector: 'app-autobus',
  templateUrl: './autobus.component.html',
  styleUrls: ['./autobus.component.css']
})
export class AutobusComponent implements OnInit {
  naziv:string='';
  klima:boolean=false;
  frmBus:FormGroup;
  kapacitet:number=0;
  wiFi:boolean=false;
  @Input() slanje:any;
  @Output() prikazi=new EventEmitter();
  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.frmBus=new FormGroup({
      'naziv':new FormControl(null,Validators.required),
      'kapacitet':new FormControl(null,
        [Validators.required,
        Validators.pattern("^[0-9]*$"),
        Validators.maxLength(2)]),
      'klima':new FormControl(),
      'wiFi':new FormControl()
    });
  }

  snimi(){
    this.frmBus.value.naziv=this.naziv;
    this.frmBus.value.kapacitet=this.kapacitet;
    this.frmBus.value.klima=this.klima;
    this.frmBus.value.wiFi=this.wiFi;
    this.httpKlijent.post(MojConfig.adresa_servera+"/Autobus/Add",this.frmBus.value,MojConfig.http_opcije()).subscribe((x:any)=>{
      console.log(this.frmBus.value);
      this.zatvori();
    })
    console.log(this.frmBus.value);
  }

  zatvori(){
    this.prikazi.emit();
  }

}
