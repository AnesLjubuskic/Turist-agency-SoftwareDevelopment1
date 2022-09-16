import {Component, OnInit, ViewChild, ElementRef, AfterContentInit, ChangeDetectorRef, OnChanges,} from '@angular/core';
import {jsPDF} from "jspdf";
import {Chart} from 'node_modules/chart.js';
import { registerables } from 'chart.js';
import {MojConfig} from "../../moj-config";
import {HttpClient} from "@angular/common/http";
@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  @ViewChild('content',{static:false}) el!:ElementRef;
  datum=new Date(Date.now());
  ukupnoPutovanja:number=0;
  ukupnoZaposleni:number=0;
  putovanjaData:any;
  listNaziv:any[];
  listBrLjudi:any[];
  destinacije:any;
  revenueData:any;

  constructor(private HttpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.listBrLjudi=[];
    this.listNaziv=[];
    this.HttpKlijent.get(MojConfig.adresa_servera+"/Putovanje/GetAllPutovanja",MojConfig.http_opcije()).subscribe((x:any)=>{
      for(var i=0; i<x.length; i++){
        this.ukupnoPutovanja++;
      }
    })
    this.HttpKlijent.get(MojConfig.adresa_servera+"/Vodic/GetAll",MojConfig.http_opcije()).subscribe((x:any)=>{
      for(var i=0; i<x.length; i++){
        this.ukupnoZaposleni++;
      }
    })
    this.HttpKlijent.get(MojConfig.adresa_servera+"/Putovanje/PutovanjaByMjesec?year=2022",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.putovanjaData=x;
    })
    this.HttpKlijent.get(MojConfig.adresa_servera+"/Putovanje/RevenueByMonth?year=2022",MojConfig.http_opcije()).subscribe((x:any)=>{
      this.revenueData=x;
    })
    this.HttpKlijent.get(MojConfig.adresa_servera+"/Putovanje/Top5Putovanja?year=2022",MojConfig.http_opcije()).subscribe((x:any)=>{
     this.destinacije=x;
      for(var i=0; i<this.destinacije.length; i++){
        this.listBrLjudi[i]=this.destinacije[i].brLjudi;
        this.listNaziv[i]=this.destinacije[i].putovanjeNaziv;
      }
    })
    Chart.register(...registerables);

    setTimeout(() => {
      this.createChart();
    }, 2000);

  }

  createChart(){
    const myChart = new Chart("myChart", {
      type: 'bar',
      data: {
        labels: this.listNaziv,
        datasets: [{
          label: 'Broj rezervacija',
          data: this.listBrLjudi,
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });


    const labels = ['Jan', 'Feb', 'Mar', 'Apr', 'Maj', 'Jun', 'Jul','Avg','Sep','Okt','Nov','Dec'];
    const niz=this.putovanjaData;
    const revenueNiz=this.revenueData;
    const data = {
      labels: labels,
      datasets: [
        {
          label: 'Broj putovanja',
          data:niz,
          borderColor: 'rgb(255, 99, 132)',
          backgroundColor: 'rgb(255,255,255)',
        }
      ]
    };

    const revenueChartData = {
      labels: labels,
      datasets: [
        {
          label: 'Prihodi po mjesecima',
          data:revenueNiz,
          borderColor: 'rgb(63,84,217)',
          backgroundColor: 'rgb(255,255,255)',
        }
      ]
    };


    const tripsLastYear = new Chart("tripsLastYearChart",{
      type: 'line',
      data: data,
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
          },
          title: {
            display: true,
            text: 'Broj putovanja u 2022.'
          }
        }
      },
    });

    const revenueLastYear = new Chart("revenueLastYearChart",{
      type: 'line',
      data: revenueChartData,
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: 'top',
          },
          title: {
            display: true,
            text: 'Prihodi po mjesecima u 2022.'
          }
        }
      },
    });

  }

  makePDF(){
    let pdf=new jsPDF('p','pt','a4');
    pdf.html(this.el.nativeElement, {
      callback:(pdf)=>{
        pdf.save("reportTravelPoint.pdf");
      }
    })

  }
}
