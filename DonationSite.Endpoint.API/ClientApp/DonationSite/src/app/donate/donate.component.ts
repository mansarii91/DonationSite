import { DonateService } from './../../services/donate.service';
import { Component, OnInit, Input } from '@angular/core';
import * as Interfaces from './../../interfaces/donate';
import * as Models from './../../models/donate';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-donate',
  templateUrl: './donate.component.html',
  styleUrls: ['./donate.component.css'],
})
export class DonateComponent implements OnInit {
  public model: Interfaces.Donate = new Models.Donate(12, '12323', 123123);
  isFailed = false;
  constructor(
    private activatedRoute: ActivatedRoute,
    private service: DonateService,
    private router: Router
  ) {
    let siteID: number = 0;
    if (activatedRoute.snapshot.paramMap.get('id') != null)
      siteID = activatedRoute.snapshot.params['id'];
    this.model = new Models.Donate(siteID, '', 0);
  }

  ngOnInit(): void {}

  onSubmit() {
    this.service.Submit(this.model).subscribe(
      (result: boolean) => {
        this.router.navigate(['/site/t']);
        console.log(result);
      },
      (error: string) => {
        this.isFailed = true;
        console.log(error);
      },
      () => {
        console.log(`Completed!`);
      }
    );
  }
}
