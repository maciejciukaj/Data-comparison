import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
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
      .post('https://localhost:5001/api/db/dodajWynagrodzenie', this.model)
      .subscribe((res) => {
        console.log(res);
        this.toastr.info('Dodano rekord do bazy');
      });
  }

  deleteDane() {
    return this.http
      .delete(
        'https://localhost:5001/api/db/usunWynagrodzenie/' + this.idDelete
      )
      .subscribe(
        (res) => {
          console.log(res);
          this.toastr.error('Usunięto rekord z bazy');
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
