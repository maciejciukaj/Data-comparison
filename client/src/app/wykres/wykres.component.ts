import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Chart } from 'node_modules/chart.js';

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
      .get('https://localhost:5001/api/db/saveJson')
      .subscribe((res) => {
        this.toastr.info('Dodano plik json');
      });
  }

  toXML() {
    return this.http
      .get('https://localhost:5001/api/db/saveXML')
      .subscribe((res) => {
        this.toastr.info('Dodano plik XML');
      });
  }
}
