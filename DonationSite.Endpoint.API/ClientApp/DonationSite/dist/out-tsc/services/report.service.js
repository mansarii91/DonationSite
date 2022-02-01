import { __decorate } from "tslib";
import { GlobalConst } from '../global_const';
import { Injectable } from '@angular/core';
let ReportService = class ReportService {
    constructor(http) {
        this.http = http;
        this.mainUrl = GlobalConst.MAIN_URL_Report;
    }
    /// view list of donation for a site
    GetDonationSiteReport(params) {
        let url = `${this.mainUrl}/${params.siteId}/${params.take}/${params.skip}`;
        return this.http.get(url).pipe();
    }
    //get count
    GetDonationSiteReportTotalCount(siteId) {
        let url = `${this.mainUrl}/${siteId}`;
        return this.http.get(url).pipe();
    }
    //=============================================================================================== */
    /// view list of all sites with his total donation
    GetReportSites(params) {
        let url = `${this.mainUrl}/${params.take}/${params.skip}`;
        return this.http.get(url).pipe();
    }
    //get count
    GetReportSitesTotalCount() {
        let url = `${this.mainUrl}/`;
        return this.http.get(url).pipe();
    }
};
ReportService = __decorate([
    Injectable({
        providedIn: 'root',
    })
], ReportService);
export { ReportService };
//# sourceMappingURL=report.service.js.map