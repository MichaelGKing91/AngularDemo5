import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class DonutApiService {
  username: string = null;
  http: HttpClient = null;

  constructor(theHttp: HttpClient) {
    this.http = theHttp;
  }

  getAllDonuts(cb) {
    this.http.get<any>('/donut').subscribe(donuts => {
      console.log(donuts);
      cb(donuts);
    });

    // Optional way for after I understand how the above function works 
    //this.http.get<any>('/donut').subscribe(cb);
  }

  getDonutDetail(id, cb) {
    this.http.get<any>(`/donut/${id}`).subscribe(detail => {
      console.log(detail);
      cb(detail);
    });
  }

  addFavorite(id) {
    this.http.post<any>(`/favorite/add?username=${this.username}&donut=${id}`, {}).subscribe(results => {
      console.log(results);
    })
  }


  removeFavorite(id) {

  }

  isFavorite(username, id, cb) {
    

  }
}
