import { __decorate } from "tslib";
import { Component } from '@angular/core';
import * as Models from '../../models/site';
let AddSiteComponent = class AddSiteComponent {
    constructor(service, router, ShareDataService) {
        this.service = service;
        this.router = router;
        this.ShareDataService = ShareDataService;
        this.hasError = false;
        this.siteModel = new Models.CreateSite();
    }
    ngOnInit() { }
    onSubmit() {
        this.service.addSite(this.siteModel).subscribe((result) => {
            // this.ShareDataService.setAddSiteData(result, '');
            this.router.navigate(['/site/t']);
            console.log(result);
        }, (error) => {
            this.hasError = true;
        }, () => {
            console.log(`Completed!`);
        });
    }
    //just for check the form values
    get diagnostic() {
        return JSON.stringify(this.siteModel);
    }
};
AddSiteComponent = __decorate([
    Component({
        selector: 'app-add-site',
        templateUrl: './add-site.component.html',
        styleUrls: ['./add-site.component.css'],
    })
], AddSiteComponent);
export { AddSiteComponent };
//# sourceMappingURL=add-site.component.js.map