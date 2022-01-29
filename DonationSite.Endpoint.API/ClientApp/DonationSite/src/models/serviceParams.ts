import {
  ReportSiteServiceParam,
  BaseServiceParam,
} from '../interfaces/serviceParam';

export class BaseParams implements BaseServiceParam {
  public take: number = 0;
  public skip: number = 0;
}

export class ReportSiteServiceModel implements ReportSiteServiceParam {
  public siteId: number = 0;
  public take: number = 0;
  public skip: number = 0;
}
