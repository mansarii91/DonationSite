import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-report-site-donation',
  templateUrl: './report-site-donation.component.html',
  styleUrls: ['./report-site-donation.component.css'],
})
export class ReportSiteDonationComponent implements OnInit {
  constructor() {}
  @Input() public siteId: number = 0;

  ngOnInit(): void {}

  showID() {
    alert(this.siteId);
  }
}
