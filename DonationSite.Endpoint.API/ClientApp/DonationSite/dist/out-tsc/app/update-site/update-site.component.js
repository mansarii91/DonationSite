import { __decorate } from "tslib";
import { Component } from '@angular/core';
import * as Models from './../../models/site';
let UpdateSiteComponent = class UpdateSiteComponent {
    constructor(router, activatedRoute, service) {
        this.router = router;
        this.activatedRoute = activatedRoute;
        this.service = service;
        this.hasError = false;
        this.model = new Models.UpdateSite();
    }
    ngOnInit() {
        if ((this.activatedRoute.snapshot.params['id'] != undefined ||
            this.activatedRoute.snapshot.params['id'] == null) &&
            this.activatedRoute.snapshot.params['id'] > 0)
            this.loadData();
        else
            this.hasError = true;
    }
    loadData() {
        let siteId = this.activatedRoute.snapshot.params['id'];
        this.service.getSiteById(siteId).subscribe((result) => {
            this.model = result;
            console.log('get site using getSiteById is ok');
        }, (error) => {
            this.hasError = true;
            console.log(error);
        }, () => {
            console.log(`Completed!`);
        });
    }
    onSubmit() {
        this.service.updateSite(this.model).subscribe((result) => {
            this.router.navigate(['/site/t']);
            console.log(result);
        }, (error) => {
            this.hasError = true;
            console.log(error);
        }, () => {
            console.log(`Completed!`);
        });
    }
};
UpdateSiteComponent = __decorate([
    Component({
        selector: 'app-update-site',
        templateUrl: './update-site.component.html',
        styleUrls: ['./update-site.component.css'],
    })
], UpdateSiteComponent);
export { UpdateSiteComponent };
//# sourceMappingURL=update-site.component.js.map