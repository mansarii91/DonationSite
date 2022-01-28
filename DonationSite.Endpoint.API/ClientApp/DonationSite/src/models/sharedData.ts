import { BehaviorSubject } from 'rxjs';
import * as Interfaces from './../interfaces/sharedData';
export class SharedData implements Interfaces.SharedData {
  public isAddSuccess: boolean = false;
  public siteAddErrorMsg: string = '';
}
