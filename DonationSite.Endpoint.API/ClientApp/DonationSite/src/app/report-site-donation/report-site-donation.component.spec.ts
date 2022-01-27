import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportSiteDonationComponent } from './report-site-donation.component';

describe('ReportSiteDonationComponent', () => {
  let component: ReportSiteDonationComponent;
  let fixture: ComponentFixture<ReportSiteDonationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportSiteDonationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportSiteDonationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
