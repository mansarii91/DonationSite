import { __decorate } from "tslib";
import { GlobalConst } from '../global_const';
import { Injectable } from '@angular/core';
let DonateService = class DonateService {
    constructor(http) {
        this.http = http;
        this.mainUrl = GlobalConst.MAIN_URL_Donate;
    }
    Submit(model) {
        let url = `${this.mainUrl}`;
        return this.http
            .post(url, JSON.stringify(model), GlobalConst.HTTP_OPTION)
            .pipe();
    }
};
DonateService = __decorate([
    Injectable({
        providedIn: 'root',
    })
], DonateService);
export { DonateService };
//# sourceMappingURL=donate.service.js.map