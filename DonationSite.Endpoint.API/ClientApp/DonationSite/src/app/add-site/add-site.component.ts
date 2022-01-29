import { ShareDataService } from './../../services/shareData.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import * as Models from '../../models/createSite';
import * as Interfaces from '../../interfaces/site';
import { SiteService } from 'src/services/site.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-site',
  templateUrl: './add-site.component.html',
  styleUrls: ['./add-site.component.css'],
})
export class AddSiteComponent implements OnInit {
  constructor(
    private service: SiteService,
    private router: Router,
    private ShareDataService: ShareDataService
  ) {
    this.siteModel = new Models.CreateSite();
  }

  ngOnInit(): void {}

  public siteModel: Interfaces.Site;

  public onSubmit(): void {
    this.service.addSite(this.siteModel).subscribe(
      (result: boolean) => {
        // this.ShareDataService.setAddSiteData(result, '');
        this.router.navigate(['/site']);
        console.log(result);
      },
      (error: string) => {
        // this.ShareDataService.setAddSiteData(false, error);
      },
      () => {
        console.log(`Completed!`);
      }
    );
  }

  //just for check the form values
  public get diagnostic() {
    return JSON.stringify(this.siteModel);
  }
}
