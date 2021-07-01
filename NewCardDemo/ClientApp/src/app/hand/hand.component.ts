import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
    selector: 'app-hand',
    templateUrl: './hand.component.html',
    styleUrls: ['./hand.component.css']
})
/** hand component*/
export class HandComponent {

  http: HttpClient = null;
  myHand = null;

  /** hand ctor */
  constructor(theHttp: HttpClient) {
    this.http = theHttp;
  }

  getNewHand() {
    if (!window["deck_id"]) {
      alert('Please create a deck first!');
      return;
    }

    console.log(window["deck_id"]);
    this.http.get<any>(`/card/gethand/${window["deck_id"]}`).subscribe(result => {
      console.log(result);
      this.myHand = result.cards;
    }, error => {
      console.log(error);
    });
  }

}
