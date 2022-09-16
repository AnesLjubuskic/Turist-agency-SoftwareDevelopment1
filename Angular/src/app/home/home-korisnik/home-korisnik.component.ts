import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {MessagesService} from "../../messages.service";
import {Subscription} from "rxjs";
import {TranslateService} from "@ngx-translate/core";

@Component({
  selector: 'app-home-korisnik',
  templateUrl: './home-korisnik.component.html',
  styleUrls: ['./home-korisnik.component.css']
})
export class HomeKorisnikComponent implements OnInit {
listPutovanja:any;
listTest:any=[];
pretraga:any=null;
public sub:Subscription;
  constructor(private HttpKlijent:HttpClient,private msg:MessagesService,  private translateService:TranslateService) { }

  ngOnInit(): void {
    this.HttpKlijent.get(MojConfig.adresa_servera+"/Putovanje/GetBuducaPutovanja",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.listPutovanja=x;
    })
  this.sub=this.msg.getMessage().subscribe(x=>
  {this.pretraga=x;
  })
  }
ngOnDestroy(){
    this.sub.unsubscribe();
}
filtriranje():any{
  if(this.pretraga==null){
   return this.listPutovanja;
  }
  else{
    return this.listTest=this.listPutovanja.filter((x:any)=>x.naziv=='' || x.naziv.toLowerCase().startsWith(this.pretraga.toLowerCase()));
  }


}

}
