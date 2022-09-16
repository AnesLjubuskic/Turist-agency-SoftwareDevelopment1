import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {RouterModule} from "@angular/router";
import {ReactiveFormsModule} from "@angular/forms";
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import {FormsModule} from "@angular/forms";
import {HTTP_INTERCEPTORS, HttpClient, HttpClientModule} from "@angular/common/http";
import {MatGridListModule} from "@angular/material/grid-list";
import { DodavanjeVodicaComponent } from './admin/dodavanje-vodica/dodavanje-vodica.component';
import { HomeMainComponent } from './home/home-main/home-main.component';
import { HomeAdminComponent } from './home/home-admin/home-admin.component';
import { HomeVodicComponent } from './home/home-vodic/home-vodic.component';
import {AutorizacijaAdminProvjera} from "./_guards/autorizacija-admin-provjera.service";
import {AutorizacijaLoginProvjera} from "./_guards/autorizacija-login-provjera.service";
import { PrevoznaSredstvaComponent } from './admin/prevozna-sredstva/prevozna-sredstva.component';
import { AutobusComponent } from './admin/prevozna-sredstva/autobus/autobus.component';
import { AviokompanijaComponent } from './admin/prevozna-sredstva/aviokompanija/aviokompanija.component';
import { SmjestajComponent } from './admin/smjestaj/smjestaj.component';
import { DodavanjePutovanjaComponent } from './admin/dodavanje-putovanja/dodavanje-putovanja.component';
import { PutovanjePrevozComponent } from './admin/putovanje-prevoz/putovanje-prevoz.component';
import { NavigacijaComponent } from './navigacija/navigacija.component';
import { HomeKorisnikComponent } from './home/home-korisnik/home-korisnik.component';
import { KarticaComponent } from './home/kartica/kartica.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { RezervacijaComponent } from './korisnik/rezervacija/rezervacija.component';
import {MatIconModule} from "@angular/material/icon";
import { AplikacijaComponent } from './korisnik/aplikacija/aplikacija.component';
import { CvSlikaComponent } from './korisnik/aplikacija/cv-slika/cv-slika.component';
import { PutovanjeDetaljiComponent } from './home/putovanje-detalji/putovanje-detalji.component';
import { FeedbackComponent } from './korisnik/feedback/feedback.component';
import { FeedbackPostaviComponent } from './korisnik/feedback/feedback-postavi/feedback-postavi.component';
import { InfoComponent } from './korisnik/info/info.component';
import { HistorijaPutovanjaComponent } from './vodic/historija-putovanja/historija-putovanja.component';
import {ngfModule} from "angular-file";
import { PregledRezervacijaComponent } from './admin/pregled-rezervacija/pregled-rezervacija.component';
import {MatSidenavModule} from "@angular/material/sidenav";
import {MatDividerModule} from "@angular/material/divider";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatButtonModule} from "@angular/material/button";
import {MatPaginatorModule} from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatTableModule} from '@angular/material/table';
import {MatTabsModule} from '@angular/material/tabs';
import { PregledUplataComponent } from './admin/pregled-uplata/pregled-uplata.component';
import { PregledPutovanjaComponent } from './vodic/pregled-putovanja/pregled-putovanja.component';
import { PregledPutnikaComponent } from './vodic/pregled-putnika/pregled-putnika.component';
import {NgxPaginationModule} from "ngx-pagination";
import { PregledAplikacijaComponent } from './admin/pregled-aplikacija/pregled-aplikacija.component';
import { PregledBuducihputovanjaComponent } from './vodic/pregled-buducihputovanja/pregled-buducihputovanja.component';
import {DodajPlanComponent} from "./vodic/pregled-buducihputovanja/dodaj-plan/dodaj-plan.component";
import {PrikaziPlanComponent} from "./vodic/pregled-buducihputovanja/prikazi-plan/prikazi-plan.component";
import { ProslaPutovanjaComponent } from './vodic/prosla-putovanja/prosla-putovanja.component';
import { BuducaPutovanjaComponent } from './vodic/buduca-putovanja/buduca-putovanja.component';
import { AdminPregledPutovanjaComponent } from './admin/admin-pregled-putovanja/admin-pregled-putovanja.component';
import {LanguageInterceptor} from "./interceptors/language.interceptor";
import {TranslateModule, TranslateLoader} from "@ngx-translate/core";
import {TranslateHttpLoader} from "@ngx-translate/http-loader";
import { ChatComponent } from './chat/chat.component';
import { ObavijestRezervacijaComponent } from './admin/obavijest-rezervacija/obavijest-rezervacija.component';
import { ReportComponent } from './admin/report/report.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { GrupeComponent } from './vodic/grupe/grupe.component';
import {AutorizacijaVodicProvjera} from "./_guards/autorizacija-vodic-provjera.service";
import { FeedbackListComponent } from './korisnik/feedback/feedback-list/feedback-list.component';

export function HttpLoaderFactory(http:HttpClient){
  return new TranslateHttpLoader(http);
}
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DodavanjeVodicaComponent,
    HomeMainComponent,
    HomeAdminComponent,
    HomeVodicComponent,
    PrevoznaSredstvaComponent,
    AutobusComponent,
    AviokompanijaComponent,
    SmjestajComponent,
    DodavanjePutovanjaComponent,
    PutovanjePrevozComponent,
    NavigacijaComponent,
    HomeKorisnikComponent,
    KarticaComponent,
    RezervacijaComponent,
    AplikacijaComponent,
    CvSlikaComponent,
    PutovanjeDetaljiComponent,
    FeedbackComponent,
    FeedbackPostaviComponent,
    InfoComponent,
    HistorijaPutovanjaComponent,
    PregledRezervacijaComponent,
    PregledUplataComponent,
    PregledPutovanjaComponent,
    PregledPutnikaComponent,
    PregledAplikacijaComponent,
    DodajPlanComponent,
    PrikaziPlanComponent,
    PregledBuducihputovanjaComponent,
    ProslaPutovanjaComponent,
    BuducaPutovanjaComponent,
    AdminPregledPutovanjaComponent,
    ChatComponent,
    ObavijestRezervacijaComponent,
    ReportComponent,
    GrupeComponent,
    FeedbackListComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(
      [
        {path: 'login', component: LoginComponent},
        {
          path: 'homevodic', component: HomeVodicComponent,canActivate:[AutorizacijaVodicProvjera],
          children: [
            {path: 'sva-putovanja', component: HistorijaPutovanjaComponent},
            { path: 'buduca-putovanja', component: BuducaPutovanjaComponent},
            {path: 'prosla-putovanja', component: ProslaPutovanjaComponent},

            {path: 'pregled-rezervacija', component: PregledRezervacijaComponent},
            {path: 'uplate', component: PregledUplataComponent},
            {path: 'putovanja', component: PregledPutovanjaComponent},
            {path: 'pravo-putovanje',component: PregledBuducihputovanjaComponent},
            {path: 'dodaj-plan/:id', component: DodajPlanComponent},
            {path: 'prikazi-plan/:id', component: PrikaziPlanComponent},
            {path: 'grupe', component: GrupeComponent},
          ]
        },
        {path: '', component: HomeKorisnikComponent},
        {path: 'rezervacija/:id', component: RezervacijaComponent},
        {path: 'aplikacija', component: AplikacijaComponent},
        {path: 'chat', component: ChatComponent},
        {path: 'detalji/:id', component: PutovanjeDetaljiComponent},
        {path: 'aplikacijaCV', component: CvSlikaComponent},
        {path: 'feedback', component: FeedbackPostaviComponent},
        {path: 'feedback-list', component: FeedbackListComponent},
        //{path: 'feedbackPost', component: FeedbackPostaviComponent},
        {path: 'feedbacklist',component:FeedbackListComponent},
        {path: 'info', component: InfoComponent},

        {
          path: 'homeadmin', component: HomeAdminComponent,canActivate:[AutorizacijaAdminProvjera],
          children: [
            {path: 'register', component: DodavanjeVodicaComponent},
            {path: 'prevoznasredstva', component: PrevoznaSredstvaComponent},
            {path: 'dodavanjesmjestaja', component: SmjestajComponent},
            {path: 'dodavanje-putovanja', component: DodavanjePutovanjaComponent},
            {path: 'admin-pregled-putovanja', component: AdminPregledPutovanjaComponent},
            {path: 'pregled-rezervacija', component: PregledRezervacijaComponent},
            {path: 'uplate', component: PregledUplataComponent},
            {path: 'aplikacije', component: PregledAplikacijaComponent},
            {path: 'obavijest', component: ObavijestRezervacijaComponent},
            {path: 'report', component: ReportComponent},
          ]
        },
      ]),
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NoopAnimationsModule,
    MatGridListModule,
    MatIconModule,
    MatSidenavModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatDividerModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatTabsModule,
    MatSelectModule,
    ngfModule,
    NgxPaginationModule,
    TranslateModule.forRoot({
      loader:{
        provide:TranslateLoader,
        useFactory:HttpLoaderFactory,
        deps:[HttpClient]
      }
    }),
    NgbModule
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS,
    useClass:LanguageInterceptor,
    multi:true},
    AutorizacijaAdminProvjera,
    AutorizacijaVodicProvjera,
    HttpClient
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
