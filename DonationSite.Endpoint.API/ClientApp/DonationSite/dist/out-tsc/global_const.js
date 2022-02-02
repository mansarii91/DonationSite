import { HttpHeaders } from '@angular/common/http';
export class GlobalConst {
}
GlobalConst.MAIN_URL_Site = 'https://localhost:8080/api/Site';
GlobalConst.MAIN_URL_Donate = 'https://localhost:8080/api/Donate';
GlobalConst.MAIN_URL_Report = 'https://localhost:8080/api/Report';
GlobalConst.HTTP_OPTION = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};
//# sourceMappingURL=global_const.js.map