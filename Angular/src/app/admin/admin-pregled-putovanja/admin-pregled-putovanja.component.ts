import {Component, OnInit, ViewChild} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MatPaginator, PageEvent} from "@angular/material/paginator";
import {MojConfig} from "../../moj-config";
import {FormBuilder, FormControl, FormGroup} from "@angular/forms";
import {NgbModal, NgbModalConfig} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-admin-pregled-putovanja',
  templateUrl: './admin-pregled-putovanja.component.html',
  styleUrls: ['./admin-pregled-putovanja.component.css']
})
export class AdminPregledPutovanjaComponent implements OnInit {
  putovanje:any;
  podaci:any;
  currentPage:number;
  pageEvent:any;
  vodiciPodaci:any;
  frmGrupa:FormGroup;
  odabranoPutovanje:any;
  vodicId:number;
  putovajeId:number;
  brojPutnika:number;

  ukupno:number=0;
  constructor(private HttpKlijent:HttpClient, private router:Router, config: NgbModalConfig, private modalService: NgbModal, private formBuilder: FormBuilder,) { }

  @ViewChild(MatPaginator)
  paginatorAdmin:MatPaginator;



  ngOnInit(): void {
    this.pregledPutovanja();
    this.pageEvent=new PageEvent();
    this.ucitajPodatkeVodic();
    this.frmGrupa=this.formBuilder.group({
      "brojPutnika":new FormControl(),
      "vodicId":new FormControl(),
      "putovajeId":new FormControl()
    });

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
  pregledPutovanja(){

    this.HttpKlijent.get(MojConfig.adresa_servera+`/Putovanje/GetAllPutovanjePaged?items_per_page=${this.paginatorAdmin?.pageSize??3}&page_number=${this.paginatorAdmin?.pageIndex??0}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.podaci=x;
      console.log(this.podaci.dataItems);

    });
  }

  open(content :any, p:any) {
    this.modalService.open(content, p);
    this.odabranoPutovanje=p;
    this.putovajeId=this.odabranoPutovanje.id;
  }

  sacuvajGrupu(){

    this.frmGrupa.value.vodicId=this.vodicId;
    this.frmGrupa.value.putovajeId=this.putovajeId;
    this.frmGrupa.value.brojPutnika=this.brojPutnika;
    console.log("frm " +  this.frmGrupa.value.putovajeId);
    this.HttpKlijent.post(MojConfig.adresa_servera+"/Grupe/Add",this.frmGrupa.value)
      .subscribe((s:any)=>{
        this.router.navigateByUrl("/homeadmin");
      });
  }

  ucitajPodatkeVodic()
  {

    this.HttpKlijent.get(MojConfig.adresa_servera+"/Vodic/GetAll",MojConfig.http_opcije()).subscribe((povratnaVrijednost:any)=>this.vodiciPodaci=povratnaVrijednost);

  }


  ngAfterViewInit(): void
  {
    console.log(this.paginatorAdmin);
    this.paginatorAdmin.page.subscribe((x:any) =>{console.log("pozvalo se");
      this.pregledPutovanja();});
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


  obrisi(id:any){
    this.HttpKlijent.delete(MojConfig.adresa_servera+`/Putovanje/Delete?id=${id}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      console.log(x);

    });
  }
}
