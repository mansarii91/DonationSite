export interface BaseServiceParam {
  take: number;
  skip: number;
}

export interface ReportSiteServiceParam extends BaseServiceParam {
  siteId: number;
}
