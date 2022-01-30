import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SiteComponent } from './site/site.component';
import { ReportSiteComponent } from './report-site/report-site.component';
import { ReportSiteDonationComponent } from './report-site-donation/report-site-donation.component';
import { RouterModule } from '@angular/router';
import { DonateComponent } from './donate/donate.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HttpClientModule } from '@angular/common/http';
import { AddSiteComponent } from './add-site/add-site.component';
import { UpdateSiteComponent } from './update-site/update-site.component';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';

@NgModule({
  declarations: [
    AppComponent,
    SiteComponent,
    ReportSiteComponent,
    ReportSiteDonationComponent,
    DonateComponent,
    NavbarComponent,
    AddSiteComponent,
    UpdateSiteComponent,
  ],
  imports: [
    RouterModule,
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    NgxPaginationModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
