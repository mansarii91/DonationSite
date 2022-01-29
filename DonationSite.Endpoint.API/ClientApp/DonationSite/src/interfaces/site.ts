export interface CreateSite {
  createdDateTime: Date;
  name: string;
  url: string;
}

export interface Site extends CreateSite {
  siteID: number;
}

export interface UpdateSite {
  name: string;
  url: string;
  siteID: number;
}
