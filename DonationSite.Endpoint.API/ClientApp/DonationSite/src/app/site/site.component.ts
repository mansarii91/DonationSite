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
  totalCount: number = 0;
  page = 1;
  itemsPerPage = 5;
  //****************************************** */
  constructor(private service: SiteService, private rout: ActivatedRoute) {}

  ngOnInit(): void {
    this.getTotalCount();
    this.loadData(1); // pass 1 for first load
    // prop for show success message
    this.isSuccess =
      this.rout.snapshot.params['result'] != undefined &&
      this.rout.snapshot.params['result'] == 't';
  }

  loadData(page: number) {
    let take = this.itemsPerPage;
    let skip = (page - 1) * this.itemsPerPage;
    this.service.getAllSiteList(take, skip).subscribe(
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

  deleteSite(siteId: number, currentPage: number) {
    this.service.deleteSite(siteId).subscribe(
      (result: boolean) => {
        console.log('delete result: ' + result);
        this.loadData(currentPage);
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

  getTotalCount() {
    this.service.getTotalCount().subscribe(
      (result: number) => {
        this.totalCount = result;
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

  onPagingChange(page: any) {
    this.loadData(page);
  }
}
