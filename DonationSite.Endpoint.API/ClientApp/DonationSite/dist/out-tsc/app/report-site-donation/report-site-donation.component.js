import { __decorate } from "tslib";
import { Component } from '@angular/core';
import * as BaseParamsModel from '../../models/serviceParams';
let ReportSiteDonationComponent = class ReportSiteDonationComponent {
    //************************************************** */
    constructor(router, service) {
        this.router = router;
        this.service = service;
        //************************************************** */
        this.result = [];
        this.hasError = false;
        this.totalCount = 0;
        this.page = 1;
        this.itemsPerPage = 5;
        this.siteId = 0;
    }
    ngOnInit() {
        this.siteId = this.router.snapshot.params['id'];
        this.getTotalCount(this.siteId);
        this.loadData(this.siteId, 1);
    }
    loadData(siteId, page) {
        let params = new BaseParamsModel.ReportSiteServiceModel();
        params.skip = (page - 1) * this.itemsPerPage;
        params.take = this.itemsPerPage;
        params.siteId = siteId;
        this.service.GetDonationSiteReport(params).subscribe((result) => {
            this.result = result;
        }, (error) => {
            this.hasError = true;
            console.log(error);
        }, () => {
            console.log(`Completed!`);
        });
    }
    getTotalCount(siteId) {
        this.service.GetDonationSiteReportTotalCount(siteId).subscribe((result) => {
            this.totalCount = result;
        }, (error) => {
            this.hasError = true;
            console.log(error);
        }, () => {
            console.log(`Completed!`);
        });
    }
    onPagingChange(page, siteId) {
        this.loadData(siteId, page);
    }
};
ReportSiteDonationComponent = __decorate([
    Component({
        selector: 'app-report-site-donation',
        templateUrl: './report-site-donation.component.html',
        styleUrls: ['./report-site-donation.component.css'],
    })
], ReportSiteDonationComponent);
export { ReportSiteDonationComponent };
//# sourceMappingURL=report-site-donation.component.js.map