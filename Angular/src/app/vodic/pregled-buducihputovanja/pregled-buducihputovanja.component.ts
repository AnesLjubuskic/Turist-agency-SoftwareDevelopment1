import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {Subscription} from "rxjs";
import {Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-pregled-buducihputovanja',
  templateUrl: './pregled-buducihputovanja.component.html',
  styleUrls: ['./pregled-buducihputovanja.component.css']
})
export class PregledBuducihputovanjaComponent implements OnInit {
  listPutovanja:any;


  public sub:Subscription;
  constructor(private HttpKlijent:HttpClient,private router: Router) { }

  ngOnInit(): void {
    this.HttpKlijent.get(MojConfig.adresa_servera+"/Putovanje/GetBuducaPutovanja",MojConfig.http_opcije())
      .subscribe((x:any)=>{
      this.listPutovanja=x;
    })



  }
  dodaj(s:any){
    this.router.navigate(["homevodic/dodaj-plan", s.id]);
  }

  pregled(s:any){
    this.router.navigate(["homevodic/prikazi-plan",s.id]);
  }

}
