export interface CreateSite {
  createdDateTime: Date;
  name: string;
  url: string;
}

export interface UpdateSite extends CreateSite {
  createdDateTime: Date;
  name: string;
  url: string;
}

export interface Site extends UpdateSite {}




