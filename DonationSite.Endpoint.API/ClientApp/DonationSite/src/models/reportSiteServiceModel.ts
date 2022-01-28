import { ReportSiteServiceParam } from './../interfaces/baseServiceParam';
export class ReportSiteServiceModel implements ReportSiteServiceParam {
  public siteId: number = 0;
  public take: number = 0;
  public skip: number = 0;
}
