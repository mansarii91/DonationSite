import { HttpHeaders } from '@angular/common/http';

export class GlobalConst {
  public static MAIN_URL_Site = 'https://localhost:44337/api/Site';
  public static MAIN_URL_Donate = 'https://localhost:44337/api/Donate';
  public static MAIN_URL_Report = 'https://localhost:44337/api/Report';
  public static HTTP_OPTION = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
}
