import {Component, OnInit, ViewChild, AfterViewInit} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Router} from "@angular/router";
import {MojConfig} from "../../moj-config";
import {MatPaginator, PageEvent} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {tap} from "rxjs";
import {FormBuilder, FormGroup} from "@angular/forms";



@Component({
  selector: 'app-pregled-rezervacija',
  templateUrl: './pregled-rezervacija.component.html',
  styleUrls: ['./pregled-rezervacija.component.css'],
})

export class PregledRezervacijaComponent implements OnInit, AfterViewInit {
  rezervacijePodaci:any;
  naziv :string="";
  show:boolean=false;
  /*length = 0;
  pageSize = 5;
  pageSizeOptions: number[] = [3,5, 10, 25, 100];
  pageIndex=1;*/
  odabranaUplata:any=null;

  iznos:any;

  @ViewChild(MatPaginator)
  paginator:MatPaginator;


  constructor(private httpKlijent: HttpClient, private router: Router, private formBuilder: FormBuilder,) { }

  ngOnInit(): void {
    this.ucitajPodatke();

  }

  frmUplata = this.formBuilder.group({
    iznos: '',
    odobreno: true
  });

  ucitajPodatke() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ `/Rezervacija/GetAllRezervacijePaged?items_per_page=${this.paginator?.pageSize??5}&page_number=${this.paginator?.pageIndex??1}`, MojConfig.http_opcije()).subscribe(x=>{
      this.rezervacijePodaci = x;
    });
  }

  getRezervacijePodaci() {
    if (this.rezervacijePodaci == null)
      return [];
    return this.rezervacijePodaci.dataItems;
  }

  ngAfterViewInit(): void
  {
    console.log(this.paginator);
    this.paginator.page.subscribe(x => this.ucitajPodatke());
    this.ucitajPodatke();
  }

  openModal(s:any):void{
    this.odabranaUplata=s;
    console.log(this.odabranaUplata);
    this.odabranaUplata.prikazi=true;
  }
  closeModal():void{
    this.show=false;
  }

  updateRezervaciju() :void
  {
    this.httpKlijent.post(MojConfig.adresa_servera+ `/Rezervacija/Update/${this.odabranaUplata.id}`,this.frmUplata.value, MojConfig.http_opcije())
      .subscribe(x=>{
        console.log(x);
        this.odabranaUplata.prikazi=false;
        this.frmUplata=null;
      });
  }

}
