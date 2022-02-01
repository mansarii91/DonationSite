import { __decorate } from "tslib";
import { Component } from '@angular/core';
import * as BaseParamsModel from './../../models/serviceParams';
let ReportSiteComponent = class ReportSiteComponent {
    //=======================================================
    constructor(reportService) {
        this.reportService = reportService;
        this.hasError = false;
        this.totalCount = 0;
        this.page = 1;
        this.itemsPerPage = 5;
        this.result = [];
    }
    ngOnInit() {
        this.getTotalCount();
        this.loadData(1);
    }
    loadData(page) {
        let params = new BaseParamsModel.BaseParams();
        params.skip = (page - 1) * this.itemsPerPage;
        params.take = this.itemsPerPage;
        this.reportService.GetReportSites(params).subscribe((result) => {
            this.result = result;
        }, (error) => {
            this.hasError = true;
            console.log(error);
        }, () => {
            console.log(`Completed!`);
        });
    }
    getTotalCount() {
        this.reportService.GetReportSitesTotalCount().subscribe((result) => {
            this.totalCount = result;
        }, (error) => {
            console.log(error);
        }, () => {
            console.log(`Completed!`);
        });
    }
    onPagingChange(page) {
        this.loadData(page);
    }
};
ReportSiteComponent = __decorate([
    Component({
        selector: 'app-report-site',
        templateUrl: './report-site.component.html',
        styleUrls: ['./report-site.component.css'],
    })
], ReportSiteComponent);
export { ReportSiteComponent };
//# sourceMappingURL=report-site.component.js.map