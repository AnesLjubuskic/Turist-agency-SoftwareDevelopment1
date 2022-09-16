import {Component, OnInit, ViewChild} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MatPaginator, PageEvent} from "@angular/material/paginator";
import {MojConfig} from "../../moj-config";

@Component({
  selector: 'app-prosla-putovanja',
  templateUrl: './prosla-putovanja.component.html',
  styleUrls: ['./prosla-putovanja.component.css']
})
export class ProslaPutovanjaComponent implements OnInit {
  putovanje:any;
  podaci:any;
  currentPage:number;
  pageEvent:any;

  ukupno:number=0;
  constructor(private HttpKlijent:HttpClient) { }

  @ViewChild(MatPaginator)
  paginatorProsla:MatPaginator;
  paginatorRez:MatPaginator;


  ngOnInit(): void {
    this.zavrsenaPutovanja();
    this.pageEvent=new PageEvent();





  }
  getPageIndex(){
    if(!this.pageEvent.pageIndex){
      return 0;
    }
    else{
      return this.pageEvent.pageIndex;
    }
  }
  listPutovanja(){
    if (this.podaci == null)
      return [];
    return this.podaci;
  }


  zavrsenaPutovanja(){
    this.HttpKlijent.get(MojConfig.adresa_servera+`/Putovanje/GetProslaPutovanjaPaged?items_per_page=${this.paginatorProsla?.pageSize??3}&page_number=${this.paginatorProsla?.pageIndex??0}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.podaci=x;
      console.log(this.podaci.dataItems);

    });
  }

  ngAfterViewInit(): void
  {
    console.log(this.paginatorProsla);
    this.paginatorProsla.page.subscribe((x:any) =>{console.log("pozvalo se");
      this.zavrsenaPutovanja();});
  }

  setPutovanje(id:number){
    this.HttpKlijent.get(MojConfig.adresa_servera+`/Putovanje/GetPutovanjeById?putovanjeId=${id}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.putovanje=x;
      console.log(this.putovanje);

    });
  }



}
