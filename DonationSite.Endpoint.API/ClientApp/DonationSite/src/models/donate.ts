import * as Interfaces from './../interfaces/donate';
export class Donate implements Interfaces.Donate {
  public donatorName: string = '';
  public value: number = 0;
  public fkSiteID: number = 0;
  constructor(siteId: number, donatorName: string, value: number) {
    this.fkSiteID = siteId;
    this.donatorName = donatorName;
    this.value = value;
  }
}
