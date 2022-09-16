import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
import { MatPaginator } from '@angular/material/paginator';
import {MatTable, MatTableDataSource} from "@angular/material/table";


@Component({
  selector: 'app-pregled-putnika',
  templateUrl: './pregled-putnika.component.html',
  styleUrls: ['./pregled-putnika.component.css']
})
export class PregledPutnikaComponent implements OnInit {
  @ViewChild('paginator') paginator: MatPaginator;

  @Input()
  putovanje:any;
  rezervacije:any;
  totalRecords:number
  maxSize:number=4;
  directionLinks:boolean=true;
  page:number=1;
  dataSource: MatTableDataSource<any>;
  columndefs : any[] = ['ime','prezime','email','telefon'];
  constructor(private HttpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.getRezervacije(this.putovanje.id);
    this.totalRecords=this.rezervacije.length;
  }

  ngAfterViewInit() {
    this.getRezervacije(this.putovanje.id);
    this.dataSource = new MatTableDataSource(this.rezervacije);
    console.log(this.dataSource);
    this.dataSource.paginator = this.paginator;
  }

  getRezervacije(id:number){
    // this.ukupno=0;
    /*this.HttpKlijent.get(MojConfig.adresa_servera+`/Rezervacija/GetAllRezervacijeByPutovanjeIdPaged?id=${id}&items_per_page=${this.paginator?.pageSize??5}&page_number=${this.paginator?.pageIndex??1}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.rezervacije=x.dataItems;
    console.log(this.rezervacije);*/
    //this.rezervacije.map((r:any)=>this.ukupno=this.ukupno+1);
    //});
    this.HttpKlijent.get(MojConfig.adresa_servera+`/Rezervacija/GetAllRezervacijeByPutovanjeId=${id}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      console.log(x);
      this.rezervacije=x;
      });
  }
}
