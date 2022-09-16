import {Component, OnInit, ViewChild, AfterViewInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../../moj-config";
import {MatPaginator, PageEvent} from '@angular/material/paginator';

@Component({
  selector: 'app-pregled-uplata',
  templateUrl: './pregled-uplata.component.html',
  styleUrls: ['./pregled-uplata.component.css']
})
export class PregledUplataComponent implements OnInit,AfterViewInit {

  uplate:any=[];
  show:boolean=false;
  tekst:string="";
  /*length = 0;
  pageSize = 5;
  pageSizeOptions: number[] = [3,5, 10, 25, 100];
  pageIndex=1;*/

  @ViewChild(MatPaginator)
  paginator1:MatPaginator;

  constructor(private httpKlijent: HttpClient, private router: Router,) { }



  ngOnInit(): void {
    this.ucitajPodatke();
  }

  ucitajPodatke() :void
  {

    this.httpKlijent.get(MojConfig.adresa_servera
      + `/Rezervacija/GetAllUplatePaged?items_per_page=
      ${this.paginator1?.pageSize??3}&page_number=
      ${this.paginator1?.pageIndex??1}`
      , MojConfig.http_opcije())
      .subscribe(x=>{
        this.uplate = x;
      });
  }

  getUplatePodaci() {
    if (this.uplate == null)
      return [];
    return this.uplate.dataItems
      .filter((x: any)=> x.ime.length==0 || (x.ime + " " + x.prezime)
        .toLowerCase()
        .startsWith(this.tekst.toLowerCase()) || (x.prezime + " " + x.ime)
        .toLowerCase().startsWith(this.tekst.toLowerCase()));
  }

  ngAfterViewInit(): void
  {
    console.log("Ova glupost se poziva"+  this.paginator1);
    this.paginator1.page.subscribe(x => this.ucitajPodatke());
    this.ucitajPodatke();
  }

}
