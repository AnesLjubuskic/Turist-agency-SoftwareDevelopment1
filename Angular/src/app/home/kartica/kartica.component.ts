import {Component, Input, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {TranslateService} from "@ngx-translate/core";

@Component({
  selector: 'app-kartica',
  templateUrl: './kartica.component.html',
  styleUrls: ['./kartica.component.css']
})
export class KarticaComponent implements OnInit {
@Input()
putovanje:any;

  constructor(private router:Router, private translateService:TranslateService) { }

  ngOnInit(): void {


  }
  rezervisi(id:any){
    this.router.navigate(['/detalji/',id]);
  }

}
