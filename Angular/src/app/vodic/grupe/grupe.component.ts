import {Component, OnInit, ViewChild} from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
import {MatPaginator} from "@angular/material/paginator";

@Component({
  selector: 'app-grupe',
  templateUrl: './grupe.component.html',
  styleUrls: ['./grupe.component.css']
})
export class GrupeComponent implements OnInit {

  grupePodaci:any;
  @ViewChild(MatPaginator)
  paginator:MatPaginator;


  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.ucitajPodatke();
  }

  ucitajPodatke() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ `/Grupe/GetAllGrupePaged?items_per_page=${this.paginator?.pageSize??5}&page_number=${this.paginator?.pageIndex??1}`, MojConfig.http_opcije()).subscribe(x=>{
      this.grupePodaci = x;
    });
  }

  getGrupePodaci() {
    if (this.grupePodaci == null)
      return [];
    return this.grupePodaci.dataItems;
  }

  ngAfterViewInit(): void
  {
    console.log(this.paginator);
    this.paginator.page.subscribe(x => this.ucitajPodatke());
    this.ucitajPodatke();
  }
}
