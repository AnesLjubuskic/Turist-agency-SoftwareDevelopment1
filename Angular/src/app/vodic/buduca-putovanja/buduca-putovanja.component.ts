import {Component, OnInit, ViewChild} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MatPaginator, PageEvent} from "@angular/material/paginator";
import {MojConfig} from "../../moj-config";
import {Router} from "@angular/router";
import {NgbModalConfig, NgbModal} from '@ng-bootstrap/ng-bootstrap'
import {MatSelectModule} from '@angular/material/select';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";

interface Car {
  value: string;
  viewValue: string;
}

@Component({
  selector: 'app-buduca-putovanja',
  templateUrl: './buduca-putovanja.component.html',
  styleUrls: ['./buduca-putovanja.component.css']
})
export class BuducaPutovanjaComponent implements OnInit {
  putovanje:any;
  podaci:any;
  currentPage:number;
  pageEvent:any;
  selectedCar: string;
  closeResult = '';
  vodiciPodaci:any;
  frmGrupa:FormGroup;
  odabranoPutovanje:any;
  vodicId:number;
  putovajeId:number;
  brojPutnika:number;

  ukupno:number=0;
  constructor(private HttpKlijent:HttpClient, private router:Router, config: NgbModalConfig, private modalService: NgbModal, private formBuilder: FormBuilder,) {
    config.backdrop = false;
    config.keyboard = false;
  }

  @ViewChild(MatPaginator)
  paginatorBuduca:MatPaginator;
  paginatorRez:MatPaginator;


  ngOnInit(): void {
    this.buducaPutovanja();
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
  buducaPutovanja(){

    this.HttpKlijent.get(MojConfig.adresa_servera+`/Putovanje/GetBuducaPutovanjaPaged?items_per_page=${this.paginatorBuduca?.pageSize??3}&page_number=${this.paginatorBuduca?.pageIndex??0}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.podaci=x;
      console.log("evo podataka");
      console.log(this.podaci.dataItems);

    });
  }

  zavrsenaPutovanja(){
    this.HttpKlijent.get(MojConfig.adresa_servera+`/Putovanje/GetProslaPutovanjePaged?items_per_page=${this.paginatorBuduca?.pageSize??3}&page_number=${this.paginatorBuduca?.pageIndex??1}`,MojConfig.http_opcije()).subscribe((x:any)=>{
      this.podaci=x;
      console.log(this.podaci.dataItems);

    });
  }

  ucitajPodatkeVodic()
  {

    this.HttpKlijent.get(MojConfig.adresa_servera+"/Vodic/GetAll",MojConfig.http_opcije()).subscribe((povratnaVrijednost:any)=>this.vodiciPodaci=povratnaVrijednost);

  }


  ngAfterViewInit(): void
  {
    console.log(this.paginatorBuduca);
    this.paginatorBuduca.page.subscribe((x:any) =>{console.log("pozvalo se");
      this.buducaPutovanja();});
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
         this.router.navigateByUrl("/homevodic/sva-putovanja");
      });
  }

}


