import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import * as Interfaces from '../interfaces/sharedData';
import * as Models from 'src/models/sharedData';

@Injectable({
  providedIn: 'root',
})
export class ShareDataService {
  //   public sharedData: BehaviorSubject<Interfaces.SharedData>;
  //   isAddSuccess: boolean = false;
  //   constructor() {}
  //   setAddSiteData(isAddSuccess: boolean, siteAddErrorMsg: string) {
  //     let model = new Models.SharedData();
  //     model.isAddSuccess = isAddSuccess;
  //     model.siteAddErrorMsg = siteAddErrorMsg;
  //     this.sharedData = new BehaviorSubject(model);
  //   }
  //   setData(isAddSuccess: boolean) {}
}
