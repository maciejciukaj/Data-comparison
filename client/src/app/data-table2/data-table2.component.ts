import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-data-table2',
  templateUrl: './data-table2.component.html',
  styleUrls: ['./data-table2.component.css'],
})
export class DataTable2Component implements OnInit {
  displayedColumns = ['id', 'kod', 'nazwa', 'rodzajTowaru', 'rok', 'wartosc'];
  //displayedColumns = ['seqNo', 'description', 'duration'];
  dane: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getDane();
  }
  getDane() {
    return this.http
      .get('https://localhost:5001/api/ceny/getCenyBaza/')
      .subscribe((res) => {
        this.dane = res;

        console.log(this.dane);
      });
  }
}
