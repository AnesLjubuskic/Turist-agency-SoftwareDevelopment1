import {ChangeDetectorRef, Component, OnInit, ViewChild} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../../moj-config";
import {MatPaginator, PageEvent} from "@angular/material/paginator";
import {Router} from "@angular/router";
@Component({
  selector: 'app-historija-putovanja',
  templateUrl: './historija-putovanja.component.html',
  styleUrls: ['./historija-putovanja.component.css']
})
export class HistorijaPutovanjaComponent implements OnInit {
  putovanje:any;
  podaci:any;
  currentPage:number;
  pageEvent:any;
  datum:any=new Date();
  ukupno:number=0;
  constructor(private HttpKlijent:HttpClient, private router:Router) { }

  @ViewChild(MatPaginator)
  paginator:MatPaginator;
  paginatorRez:MatPaginator;


  ngOnInit(): void {
    this.svaPutovanja();
    this.pageEvent=new PageEvent();
    console.log(this.datum);

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
  svaPutovanja(){

    this.HttpKlijent.get(MojConfig.adresa_servera+`/Putovanje/GetAllPutovanjePaged?items_per_page=${this.paginator?.pageSize??3}&page_number=${this.paginator?.pageIndex??0}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.podaci=x;
      console.log(this.podaci.dataItems);

    });
  }


  ngAfterViewInit(): void
  {
    console.log(this.paginator);
    this.paginator.page.subscribe((x:any) =>{console.log("pozvalo se");
      this.svaPutovanja();});
  }

  setPutovanje(id:number){
    this.HttpKlijent.get(MojConfig.adresa_servera+`/Putovanje/GetPutovanjeById?putovanjeId=${id}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.putovanje=x;
      console.log(this.putovanje);

    });
  }

  dodaj(s:any){
    this.router.navigate(["homevodic/dodaj-plan", s.id]);
  }
  pregled(s:any){
    this.router.navigate(["homevodic/prikazi-plan",s.id]);
  }
  uporediDatum(d:any,d2:any):boolean{
    if(d<d2){
      return true;
    }
    else{
      return false;
    }
  }
}
