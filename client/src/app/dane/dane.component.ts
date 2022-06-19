import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Injectable, OnInit } from '@angular/core';

import { ToastrService } from 'ngx-toastr';
const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token,
  }),
};
@Injectable({ providedIn: 'root' })
@Component({
  selector: 'app-dane',
  templateUrl: './dane.component.html',
  styleUrls: ['./dane.component.css'],
})
export class DaneComponent implements OnInit {
  dane: any;
  arr = [];
  model: any = {};
  idDelete: any;
  constructor(private http: HttpClient, private toastr: ToastrService) {}

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

  addDane() {
    return this.http
      .post(
        'https://localhost:5001/api/db/dodajWynagrodzenie',
        this.model,
        httpOptions
      )
      .subscribe(
        (res) => {
          console.log(res);
          this.toastr.info('Dodano rekord do bazy');
        },
        (error) => {
          this.toastr.error('Brak uprawnien');
        }
      );
  }

  deleteDane() {
    return this.http
      .delete(
        'https://localhost:5001/api/db/usunWynagrodzenie/' + this.idDelete,
        httpOptions
      )
      .subscribe(
        (res) => {
          console.log(res);
          this.toastr.error('Usunięto rekord z bazy');
          this.ngOnInit();
        },
        (error) => {
          this.toastr.error('Brak uprawnien');
        }
      );
  }
  refresh(): void {
    window.location.reload();
  }
}
