import * as Interfaces from '../interfaces/site';

export class CreateSite implements Interfaces.CreateSite {
  public createdDateTime: Date = new Date();
  public name: string = '';
  public url: string = '';
}
