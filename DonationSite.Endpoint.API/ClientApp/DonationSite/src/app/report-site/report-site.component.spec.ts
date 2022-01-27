import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportSiteComponent } from './report-site.component';

describe('ReportSiteComponent', () => {
  let component: ReportSiteComponent;
  let fixture: ComponentFixture<ReportSiteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportSiteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportSiteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
