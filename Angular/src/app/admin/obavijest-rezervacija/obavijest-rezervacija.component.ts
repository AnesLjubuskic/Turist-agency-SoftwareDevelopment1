import {Component, OnInit, ViewChild} from '@angular/core';
import {SignalrService} from '../../signalr.service';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
import {MatPaginator} from "@angular/material/paginator";

@Component({
  selector: 'app-obavijest-rezervacija',
  templateUrl: './obavijest-rezervacija.component.html',
  styleUrls: ['./obavijest-rezervacija.component.css']
})
export class ObavijestRezervacijaComponent implements OnInit {

  poruke:any;

  @ViewChild(MatPaginator)
  paginator:MatPaginator;

  constructor( public signalRService: SignalrService, private HttpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.signalRService.connect();
    this.ucitajPodatke();
  }

  ucitajPodatke() :void
  {
    this.HttpKlijent.get(MojConfig.adresa_servera+ `/Chat/GetAllNotifications?items_per_page=${this.paginator?.pageSize??5}&page_number=${this.paginator?.pageIndex??1}`, MojConfig.http_opcije()).subscribe(x=>{
      this.poruke = x;
    });
  }

  getPoruke() {
    if (this.poruke == null)
      return [];
    return this.poruke.dataItems;
  }

  ngAfterViewInit(): void
  {
    console.log(this.paginator);
    this.paginator.page.subscribe(x => this.ucitajPodatke());
    this.ucitajPodatke();
  }

  markAsRead(id:any) :void
  {
    this.HttpKlijent.put(MojConfig.adresa_servera+ `/Chat/MarkNotificationAsRead?id=${id}`, MojConfig.http_opcije())
      .subscribe(x=>{
        console.log(x);
      });
  }

}
