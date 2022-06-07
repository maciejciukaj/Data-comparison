import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import * as rxjs from 'rxjs';
import * as rxops from 'rxjs/operators';

@Component({
  selector: 'app-dane',
  templateUrl: './dane.component.html',
  styleUrls: ['./dane.component.css'],
})
export class DaneComponent implements OnInit {
  dane: any;
  arr = [];
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getDane();
  }

  getDane() {
    return this.http
      .get('https://localhost:5001/api/ceny/getCenyBaza/')
      .subscribe((res) => {
        this.dane = res;
      });
  }
}
