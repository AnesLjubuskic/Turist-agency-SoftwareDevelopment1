import {Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from "@angular/material/paginator";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../../moj-config";

@Component({
  selector: 'app-pregled-aplikacija',
  templateUrl: './pregled-aplikacija.component.html',
  styleUrls: ['./pregled-aplikacija.component.css']
})
export class PregledAplikacijaComponent implements OnInit {

  aplikacije:any=[];
  @ViewChild(MatPaginator)
  paginator1:MatPaginator;

  constructor(private httpKlijent:HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.ucitajPodatke();
  }

  ucitajPodatke() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+
      `/api/AplikacijaPosao/GetAllPaged?items_per_page=
      ${this.paginator1?.pageSize??3}&page_number=
      ${this.paginator1?.pageIndex??1}`
      , MojConfig.http_opcije())
      .subscribe((x:any)=>{
        this.aplikacije = x;
      });
  }

  getAplikacijaPodaci() {
    if (this.aplikacije == null)
      return [];
    return this.aplikacije.dataItems;
  }

  ngAfterViewInit(): void
  {
    console.log("Ova glupost se poziva"+  this.paginator1);
    this.paginator1.page.subscribe(x => this.ucitajPodatke());
    this.ucitajPodatke();
  }

}
