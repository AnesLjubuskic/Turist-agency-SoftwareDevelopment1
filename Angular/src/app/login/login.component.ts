import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "../_helpers/autentifikacija-helper";
import {LoginInformacije} from "../_helpers/login-informacije";
import {FormControl, FormGroup, Validators} from "@angular/forms";


declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
   txtKorisnickoIme: any;
   txtLozinka: any;
   txtStep:any;
   korisnik:any;
   frmLogin:FormGroup;

  constructor(private httpKlijent: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.frmLogin=new FormGroup({
      'txtKorisnickoIme':new FormControl(null,Validators.required),
      'txtLozinka':new FormControl(null,Validators.required),
      'txtStep':new FormControl()
    });
  }


  LoginBtn() {
    this.GetPoKorisnickomImenu();
    let saljemo = {
      korisnickoIme:this.txtKorisnickoIme,
      lozinka: this.txtLozinka
    };
    let saljemoTwoStep = {
      korisnickoIme:this.txtKorisnickoIme,
      lozinka: this.txtLozinka,
      twoStep:this.txtStep
    };
        if(this.korisnik.isTwoStep){
          this.httpKlijent.post<LoginInformacije>(MojConfig.adresa_servera+ "/api/Autentifikacija/LoginTwoStep", saljemoTwoStep,MojConfig.http_opcije())
            .subscribe((x:LoginInformacije) =>{
              if (x.isLogiran) {
                AutentifikacijaHelper.setLoginInfo(x)
                if(x.isPermisijaAdmin) {
                  this.router.navigateByUrl("/homeadmin");
                }
                if(x.isPermisijaVodic){
                  this.router.navigateByUrl("/homevodic");
                }
              }
              else
              {
                AutentifikacijaHelper.setLoginInfo(null)
                porukaError("neispravan login");
              }
            });
        }
    else {
          this.httpKlijent.post<LoginInformacije>(MojConfig.adresa_servera + "/api/Autentifikacija/Login", saljemo, MojConfig.http_opcije())
            .subscribe((x: LoginInformacije) => {
              if (x.isLogiran) {
                AutentifikacijaHelper.setLoginInfo(x)
                if (x.isPermisijaAdmin) {
                  this.router.navigateByUrl("/homeadmin");
                }
                if (x.isPermisijaVodic) {
                  this.router.navigateByUrl("/homevodic");
                }
              } else {
                AutentifikacijaHelper.setLoginInfo(null)
                porukaError("neispravan login");
              }
            });
        }

  }

  GetPoKorisnickomImenu(){
      this.httpKlijent.get(MojConfig.adresa_servera+`/api/Admin/GetKorisnikByName/${this.txtKorisnickoIme}`
        ,MojConfig.http_opcije())
        .subscribe((x:any)=>{
          this.korisnik=x;
        })
  }

  SendMail() {
    this.GetPoKorisnickomImenu();
    let saljemo = {
      id:this.korisnik.id
    };
    if(this.korisnik.isVodic)
    {
    this.httpKlijent.post(MojConfig.adresa_servera+`/api/Autentifikacija/SendTwoStep`,saljemo,MojConfig.http_opcije())
      .subscribe((x:any)=>{
        porukaSuccess("Email Poslan!")
      },()=>{porukaError("Greska")});
    }
    else{
      this.httpKlijent.post(MojConfig.adresa_servera+`/api/Autentifikacija/SendTwoStepAdmin`,saljemo,MojConfig.http_opcije())
        .subscribe((x:any)=>{
          porukaSuccess("Email Poslan!")
        },()=>{porukaError("Greska")});
    }
  }
}
