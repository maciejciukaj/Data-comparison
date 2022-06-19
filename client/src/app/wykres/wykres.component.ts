import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Injectable, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Chart } from 'node_modules/chart.js';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token,
  }),
};
@Injectable({ providedIn: 'root' })
@Component({
  selector: 'app-wykres',
  templateUrl: './wykres.component.html',
  styleUrls: ['./wykres.component.css'],
})
export class WykresComponent implements OnInit {
  constructor(private http: HttpClient, private toastr: ToastrService) {}

  ngOnInit(): void {}

  toJson() {
    return this.http
      .get('https://localhost:5001/api/db/saveJson', httpOptions)
      .subscribe(
        (res) => {
          this.toastr.info('Dodano plik json');
        },
        (error) => {
          this.toastr.error('Brak dostępu');
        }
      );
  }

  toXML() {
    return this.http
      .get('https://localhost:5001/api/db/saveXML', httpOptions)
      .subscribe(
        (res) => {
          this.toastr.info('Dodano plik XML');
        },
        (error) => {
          this.toastr.error('Brak dostępu');
        }
      );
  }
}
