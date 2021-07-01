import { Component } from '@angular/core';
import { DonutApiService } from '../donut-api.service';

@Component({
    selector: 'app-donutdetail',
    templateUrl: './donutdetail.component.html',
    styleUrls: ['./donutdetail.component.css']
})
/** donutdetail component*/
export class DonutdetailComponent {
  isFavorite = false;
  detail = null;

  donutService: DonutApiService = null;
  constructor(theDService: DonutApiService) {
    this.donutService = theDService;
  }

  addFavorite() {
    console.log('Adding Favorite');
    console.log(this.detail.id);
    this.donutService.addFavorite(this.detail.id);
  }

  removeFavorite() {

  }
}
