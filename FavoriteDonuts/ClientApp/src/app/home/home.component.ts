import { Component } from '@angular/core';
import { DonutApiService } from '../donut-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  username: string = '';

  donutService: DonutApiService = null;
  constructor(theDService: DonutApiService) {
    this.donutService = theDService;
  }
  clickLogin() {
    //Window['d_username'] = this.username;
    this.donutService.username = this.username;
    alert(this.username);
  }
}
