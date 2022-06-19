import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Injectable, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Cena } from '../_models/cena';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatSort, Sort } from '@angular/material/sort';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token,
  }),
};
@Injectable({ providedIn: 'root' })
@Component({
  selector: 'app-data-table2',
  templateUrl: './data-table2.component.html',
  styleUrls: ['./data-table2.component.css'],
})
export class DataTable2Component implements OnInit {
  @ViewChild('paginator') paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  displayedColumns = ['id', 'kod', 'nazwa', 'rodzajTowaru', 'rok', 'wartosc'];

  dane: any;

  dataSource: MatTableDataSource<Cena>;

  constructor(
    private http: HttpClient,
    private _liveAnnouncer: LiveAnnouncer
  ) {}

  ngOnInit(): void {
    this.getDane();
  }
  getDane() {
    return this.http
      .get('https://localhost:5001/api/ceny/getCenyBaza/',httpOptions)
      .subscribe((res) => {
        this.dane = res;

        console.log(this.dane);
        this.dataSource = new MatTableDataSource(this.dane);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  announceSortChange(sortState: Sort) {
    // This example uses English messages. If your application supports
    // multiple language, you would internationalize these strings.
    // Furthermore, you can customize the message to add additional
    // details about the values being sorted.
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }
}
