import { __decorate } from "tslib";
import { GlobalConst } from './../global_const';
import { Injectable } from '@angular/core';
let SiteService = class SiteService {
    constructor(http) {
        this.http = http;
        this.mainUrl = GlobalConst.MAIN_URL_Site;
    }
    getAllSiteList(take, skip) {
        let url = `${this.mainUrl}/${take}/${skip}`;
        return this.http.get(url).pipe();
    }
    getTotalCount() {
        let url = `${this.mainUrl}`;
        return this.http.get(url).pipe();
    }
    getSiteById(id) {
        let url = `${this.mainUrl}/${id}`;
        return this.http.get(url).pipe();
    }
    deleteSite(id) {
        let url = `${this.mainUrl}/${id}`;
        return this.http.delete(url).pipe();
    }
    addSite(model) {
        let url = `${this.mainUrl}`;
        return this.http
            .post(url, JSON.stringify(model), GlobalConst.HTTP_OPTION)
            .pipe();
    }
    updateSite(model) {
        let url = `${this.mainUrl}`;
        return this.http
            .put(url, JSON.stringify(model), GlobalConst.HTTP_OPTION)
            .pipe();
    }
};
SiteService = __decorate([
    Injectable({
        providedIn: 'root',
    })
], SiteService);
export { SiteService };
//# sourceMappingURL=site.service.js.map