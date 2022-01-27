import * as Interfaces from './../../interfaces/site';
import { Component, OnInit } from '@angular/core';
import { SiteService } from '../../services/site.service';

@Component({
  selector: 'app-site',
  templateUrl: './site.component.html',
  styleUrls: ['./site.component.css'],
})
export class SiteComponent implements OnInit {
  public siteList: Interfaces.Site[] = [];
  public error: string = '';
  constructor(private service: SiteService) {}

  ngOnInit(): void {
    this.service.getAllSiteList(100, 0).subscribe(
      (result: Interfaces.Site[]) => {
        this.siteList = result;
      },
      (error: string) => {
        this.error = error;
      },
      () => {
        console.log(`Completed!`);
      }
    );
  }
}
