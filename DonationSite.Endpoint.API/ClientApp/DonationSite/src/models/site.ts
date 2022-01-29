import * as Interfaces from '../interfaces/site';

export class CreateSite implements Interfaces.CreateSite {
  public createdDateTime: Date = new Date();
  public name: string = '';
  public url: string = '';
  public siteID: number = 0;
}

export class UpdateSite implements Interfaces.UpdateSite {
  public name: string = '';
  public url: string = '';
  public siteID: number = 0;
}
