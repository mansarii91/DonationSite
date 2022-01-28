import * as Interfaces from './../../interfaces/site';
import { Component, OnInit } from '@angular/core';
import { SiteService } from '../../services/site.service';
import { ShareDataService } from 'src/services/shareData.service';

@Component({
  selector: 'app-site',
  templateUrl: './site.component.html',
  styleUrls: ['./site.component.css'],
})
export class SiteComponent implements OnInit {
  public siteList: Interfaces.Site[] = [];
  public error: string = '';
  constructor(
    private service: SiteService,
    private sharedDataService: ShareDataService
  ) {}
  public isAddSuccess: boolean = false;
  public errAddMsg: string = '';

  ngOnInit(): void {
    this.service.getAllSiteList(100, 0).subscribe(
      (result: Interfaces.Site[]) => {
        this.siteList = result;
        // this.sharedDataService.sharedData.subscribe((c) => {
        //   this.isAddSuccess = c.;
        // });
      },
      (error: string) => {
        this.error = error;
        console.log(error);
        // this.errAddMsg = this.sharedDataService.getAddSiteData().siteAddErrorMsg;
      },
      () => {
        console.log(`Completed!`);
      }
    );
  }
}
