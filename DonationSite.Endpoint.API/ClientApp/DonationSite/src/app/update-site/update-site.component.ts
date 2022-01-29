import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SiteService } from 'src/services/site.service';
import * as Interfaces from './../../interfaces/site';
import * as Models from './../../models/site';

@Component({
  selector: 'app-update-site',
  templateUrl: './update-site.component.html',
  styleUrls: ['./update-site.component.css'],
})
export class UpdateSiteComponent implements OnInit {
  model: Interfaces.UpdateSite;
  hasError: boolean = false;
  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private service: SiteService
  ) {
    this.model = new Models.UpdateSite();
  }

  ngOnInit(): void {
    if (
      (this.activatedRoute.snapshot.params['id'] != undefined ||
        this.activatedRoute.snapshot.params['id'] == null) &&
      this.activatedRoute.snapshot.params['id'] > 0
    )
      this.loadData();
    else this.hasError = true;
  }

  loadData() {
    let siteId: number = this.activatedRoute.snapshot.params['id'];
    this.service.getSiteById(siteId).subscribe(
      (result: Interfaces.UpdateSite) => {
        this.model = result;
        console.log('get site using getSiteById is ok');
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

  onSubmit() {
    this.service.updateSite(this.model).subscribe(
      (result: boolean) => {
        this.router.navigate(['/site/t']);
        console.log(result);
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
