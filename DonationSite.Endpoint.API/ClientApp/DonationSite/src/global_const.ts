import { HttpHeaders } from '@angular/common/http';

export class GlobalConst {
  public static MAIN_URL_Site = 'https://localhost:2001/api/Site';
  public static MAIN_URL_Donate = 'https://localhost:2001/api/Donate';
  public static MAIN_URL_Report = 'https://localhost:2001/api/Report';
  public static HTTP_OPTION = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
}
