import {AfterViewInit, Component, ElementRef, ViewChild, OnInit} from '@angular/core';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})
export class InfoComponent implements OnInit {
  @ViewChild('mapRef', {static: true}) mapElement: ElementRef;
  constructor() { };

  ngOnInit(): void {
    this.renderMap();
  }

  renderMap() {

    window['initMap'] = () => {
      this.loadMap();
    }
    if(!window.document.getElementById('google-map-script')) {
      var s = window.document.createElement("script");
      s.id = "google-map-script";
      s.type = "text/javascript";
      //s.src = "https://maps.googleapis.com/maps/api/js?key=AIzaSyDIy3IfxFmuRkxX43YtqNBRB73dU4xXtnI&callback=initMap";
      s.src = "https://maps.googleapis.com/maps/api/js?key=&callback=initMap";

      window.document.body.appendChild(s);
    } else {
      this.loadMap();
    }
  }

  loadMap = () => {
    var map = new window['google'].maps.Map(this.mapElement.nativeElement, {
      center: {lat: 43.343777, lng: 17.807758},
      zoom:10
    });

    var marker = new window['google'].maps.Marker({
      position: {lat: 43.343777, lng: 17.807758},
      map: map,
      title: 'Hello World!',
      draggable: true,
      animation: window['google'].maps.Animation.DROP,
    });

    var contentString = '<div id="content">'+ '<div id="siteNotice">'
      + '</div>'+ '<div id="bodyContent">'
      +  '<p style="color: #0a0c0d; font-size: 20px">TravelPoint</p>'
      + '</div>'+ '</div>'
      +  '</div>'+ '</div>';

    var infowindow = new window['google'].maps.InfoWindow({
      content: contentString
    });

    marker.addListener('click', function() {
      infowindow.open(map,marker);
    });


  }
}
