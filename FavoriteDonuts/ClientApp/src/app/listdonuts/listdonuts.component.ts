import { Component, ViewChild } from '@angular/core';
import { DonutApiService } from '../donut-api.service';
import { DonutdetailComponent } from '../donutdetail/donutdetail.component';

@Component({
    selector: 'app-listdonuts',
    templateUrl: './listdonuts.component.html',
    styleUrls: ['./listdonuts.component.css']
})
/** listdonuts component*/
export class ListdonutsComponent {

  donutservice: DonutApiService = null;
  donuts = null;
  @ViewChild('MyDonutDetail', { static: false }) detailComp: DonutdetailComponent = null;

  constructor(theDService: DonutApiService) {
    this.donutservice = theDService;
    this.donutservice.getAllDonuts(donuts => {
      this.donuts = donuts.results;
      console.log(this.donuts);
    });
  }

  showDetail(id) {
    this.donutservice.getDonutDetail(id, det_result => {
      console.log(det_result);
      this.detailComp.detail = det_result;
    });
  }
}
