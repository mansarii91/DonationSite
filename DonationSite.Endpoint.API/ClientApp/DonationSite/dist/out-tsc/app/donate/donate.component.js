import { __decorate } from "tslib";
import { Component } from '@angular/core';
import * as Models from './../../models/donate';
let DonateComponent = class DonateComponent {
    constructor(activatedRoute, service, router) {
        this.activatedRoute = activatedRoute;
        this.service = service;
        this.router = router;
        this.model = new Models.Donate(12, '12323', 123123);
        this.isFailed = false;
        let siteID = 0;
        if (activatedRoute.snapshot.paramMap.get('id') != null)
            siteID = activatedRoute.snapshot.params['id'];
        this.model = new Models.Donate(siteID, '', 0);
    }
    ngOnInit() { }
    onSubmit() {
        this.service.Submit(this.model).subscribe((result) => {
            this.router.navigate(['/site/t']);
            console.log(result);
        }, (error) => {
            this.isFailed = true;
            console.log(error);
        }, () => {
            console.log(`Completed!`);
        });
    }
};
DonateComponent = __decorate([
    Component({
        selector: 'app-donate',
        templateUrl: './donate.component.html',
        styleUrls: ['./donate.component.css'],
    })
], DonateComponent);
export { DonateComponent };
//# sourceMappingURL=donate.component.js.map