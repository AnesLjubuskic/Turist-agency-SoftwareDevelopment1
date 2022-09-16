import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {LoginInformacije} from "../../_helpers/login-informacije";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacija-helper";
import {SignalrService} from "../../signalr.service";

@Component({
  selector: 'app-home-main',
  templateUrl: './home-main.component.html',
  styleUrls: ['./home-main.component.css']
})
export class HomeMainComponent implements OnInit {

  showMe:boolean=true;
  userId:any;
  user:any;
  constructor(private httpKlijent:HttpClient,private route:Router, public signalRService: SignalrService) { }

  ngOnInit(): void {
    this.signalRService.connect();
    this.getUser();
  }

  loginInfo():LoginInformacije{
    return AutentifikacijaHelper.getLoginInfo();
  }
  logoutButton(){
    AutentifikacijaHelper.setLoginInfo(null);
    this.httpKlijent.post(MojConfig.adresa_servera+'/api/Autentifikacija/Logout',null,MojConfig.http_opcije())
      .subscribe((x:any)=>{
        this.route.navigateByUrl('/login');
        alert('Lougout uspjesan!');
      })
  }

  toogleTag()
  {
    this.showMe=false;
  }

  getUser(){
    this.userId=this.loginInfo().autentifikacijaToken.korisnickiNalogId;
    this.httpKlijent.get(MojConfig.adresa_servera+`/api/Admin/GetKorisnikById/${this.userId}`,MojConfig.http_opcije())
      .subscribe((x:any)=>{
        this.user=x;
      })
  }

  activateTwo(){
    let saljemo = {
      id:this.userId
    };
    this.httpKlijent.post(MojConfig.adresa_servera+`/api/Autentifikacija/ActivateTwoStep/`,saljemo,MojConfig.http_opcije())
      .subscribe((x:any)=>{
          this.ngOnInit();
      });
  }
}
