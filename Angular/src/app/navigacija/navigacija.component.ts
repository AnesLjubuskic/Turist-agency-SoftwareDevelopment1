import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {Router} from "@angular/router";
import {MessagesService} from "../messages.service";

@Component({
  selector: 'app-navigacija',
  templateUrl: './navigacija.component.html',
  styleUrls: ['./navigacija.component.css']
})
export class NavigacijaComponent implements OnInit {
filter:any;
lang:any;
  constructor(public router:Router,private msg:MessagesService) { }

  ngOnInit(): void {
    this.lang=localStorage.getItem('lang') ||  'ba';
  }
funcPretraga(){
   this.msg.updateMessage(this.filter);
}



changeLang(target:any){
    const tgt=target as HTMLInputElement;
    localStorage.setItem("lang",tgt.value);
    window.location.reload();
}
}
