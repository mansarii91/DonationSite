import { __decorate } from "tslib";
import { Component } from '@angular/core';
let SiteComponent = class SiteComponent {
    //****************************************** */
    constructor(service, rout) {
        this.service = service;
        this.rout = rout;
        //variables
        this.siteList = [];
        this.isAddSuccess = false;
        this.hasError = false;
        this.isSuccess = false;
        this.totalCount = 0;
        this.page = 1;
        this.itemsPerPage = 5;
    }
    ngOnInit() {
        this.getTotalCount();
        this.loadData(1); // pass 1 for first load
        // prop for show success message
        this.isSuccess =
            this.rout.snapshot.params['result'] != undefined &&
                this.rout.snapshot.params['result'] == 't';
    }
    loadData(page) {
        let take = this.itemsPerPage;
        let skip = (page - 1) * this.itemsPerPage;
        this.service.getAllSiteList(take, skip).subscribe((result) => {
            this.siteList = result;
        }, (error) => {
            this.hasError = true;
            console.log(error);
        }, () => {
            console.log(`Completed!`);
        });
    }
    deleteSite(siteId, currentPage) {
        this.service.deleteSite(siteId).subscribe((result) => {
            console.log('delete result: ' + result);
            this.loadData(currentPage);
        }, (error) => {
            this.hasError = true;
            console.log(error);
        }, () => {
            console.log(`Completed!`);
        });
    }
    getTotalCount() {
        this.service.getTotalCount().subscribe((result) => {
            this.totalCount = result;
        }, (error) => {
            this.hasError = true;
            console.log(error);
        }, () => {
            console.log(`Completed!`);
        });
    }
    onPagingChange(page) {
        this.loadData(page);
    }
};
SiteComponent = __decorate([
    Component({
        selector: 'app-site',
        templateUrl: './site.component.html',
        styleUrls: ['./site.component.css'],
    })
], SiteComponent);
export { SiteComponent };
//# sourceMappingURL=site.component.js.map