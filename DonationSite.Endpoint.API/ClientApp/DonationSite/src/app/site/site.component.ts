import * as Interfaces from './../../interfaces/site';
import { Component, OnInit, ViewChild } from '@angular/core';
import { SiteService } from '../../services/site.service';
import { ShareDataService } from 'src/services/shareData.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-site',
  templateUrl: './site.component.html',
  styleUrls: ['./site.component.css'],
})
export class SiteComponent implements OnInit {
  //variables
  public siteList: Interfaces.Site[] = [];
  public isAddSuccess: boolean = false;
  hasError: boolean = false;
  isSuccess: boolean = false;

  //****************************************** */
  constructor(
    private service: SiteService,
    private sharedDataService: ShareDataService,
    private rout: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadData();
    // prop for show success message
    this.isSuccess =
      this.rout.snapshot.params['result'] != undefined &&
      this.rout.snapshot.params['result'] == 't';
  }

  loadData() {
    this.service.getAllSiteList(100, 0).subscribe(
      (result: Interfaces.Site[]) => {
        this.siteList = result;
      },
      (error: string) => {
        this.hasError = true;
        console.log(error);
      },
      () => {
        console.log(`Completed!`);
      }
    );
  }

  deleteSite(siteId: number) {
    this.service.deleteSite(siteId).subscribe(
      (result: boolean) => {
        console.log('delete result: ' + result);
        this.loadData();
      },
      (error: string) => {
        this.hasError = true;
        console.log(error);
      },
      () => {
        console.log(`Completed!`);
      }
    );
  }
}
