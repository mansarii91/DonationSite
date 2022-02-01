import { __decorate } from "tslib";
import { UpdateSiteComponent } from './update-site/update-site.component';
import { BrowserModule } from '@angular/platform-browser';
// **************************************************
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
// **************************************************
// **************************************************
import { SiteComponent } from './site/site.component';
import { ReportSiteComponent } from './report-site/report-site.component';
import { ReportSiteDonationComponent } from './report-site-donation/report-site-donation.component';
import { DonateComponent } from './donate/donate.component';
import { AddSiteComponent } from './add-site/add-site.component';
// **************************************************
const routes = [
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
        path: 'site/:result',
        component: SiteComponent,
    },
    {
        path: 'addSite',
        component: AddSiteComponent,
    },
    {
        path: 'updateSite/:id',
        component: UpdateSiteComponent,
    },
    {
        path: 'reportSite',
        component: ReportSiteComponent,
    },
    {
        path: 'reportSiteDonation/:id',
        component: ReportSiteDonationComponent,
    },
    {
        path: 'donate/:id',
        component: DonateComponent,
    },
];
let AppRoutingModule = class AppRoutingModule {
};
AppRoutingModule = __decorate([
    NgModule({
        imports: [BrowserModule, RouterModule.forRoot(routes)],
        exports: [RouterModule],
    })
], AppRoutingModule);
export { AppRoutingModule };
//# sourceMappingURL=app-routing.module.js.map