import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.css'],
})
export class DataTableComponent implements OnInit {
  //displayedColumns = ['id', 'kod', 'nazwa', 'rok', 'wartosc'];
  displayedColumns = ['seqNo', 'description', 'duration'];
  dane: any;
  arrDane = [];

  lessons = [
    {
      id: 120,
      description: 'Introduction to Angular Material',
      duration: '4:17',
      seqNo: 1,
      courseId: 11,
    },
    {
      id: 105,
      description: 'Introduction to Material',
      duration: '4:50',
      seqNo: 2,
      courseId: 1,
    },
  ];
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getDane();
  }

  getDane() {
    return this.http
      .get('https://localhost:5001/api/ceny/getCenyBaza/')
      .subscribe((res) => {
        this.dane = res;
        this.arrDane = [this.dane];
        console.log(this.arrDane);
      });
  }
}
