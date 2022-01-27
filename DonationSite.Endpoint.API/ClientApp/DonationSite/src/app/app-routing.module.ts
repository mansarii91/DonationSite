import { BrowserModule } from '@angular/platform-browser';
// **************************************************
import { NgModule } from '@angular/core';

import { Routes } from '@angular/router';
import { RouterModule } from '@angular/router';
// **************************************************

// **************************************************
import { SiteComponent } from './site/site.component';
import { ReportSiteComponent } from './report-site/report-site.component';
import { ReportSiteDonationComponent } from './report-site-donation/report-site-donation.component';
import { DonateComponent } from './donate/donate.component';
// **************************************************

const routes: Routes = [
  {
    path: '',
    redirectTo: '/site',
    pathMatch: 'full',
  },

  {
    path: 'site',
    component: SiteComponent,
  },

  {
    path: 'reportSite',
    component: ReportSiteComponent,
  },
  {
    path: 'reportSiteDonation',
    component: ReportSiteDonationComponent,
  },
  {
    path: 'donate',
    component: DonateComponent,
  },
];

@NgModule({
  imports: [BrowserModule, RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
