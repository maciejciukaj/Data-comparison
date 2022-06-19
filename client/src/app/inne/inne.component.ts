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
  selector: 'app-inne',
  templateUrl: './inne.component.html',
  styleUrls: ['./inne.component.css'],
})
export class InneComponent implements OnInit {
  dane: any;
  model: any = {};
  idDelete: any;

  constructor(private http: HttpClient, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.getDaneWyn();
  }

  getDaneWyn() {
    return this.http
      .get('https://localhost:5001/api/wynagrodzenia/getWynagrodzeniaBaza/')
      .subscribe({
        next: (response) => (this.dane = response),
        error: (error) => console.log(error),
      });
  }

  addDane(model: any) {
    return this.http
      .post(
        'https://localhost:5001/api/db/dodajCeneProduktu',
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
        'https://localhost:5001/api/db/usunProdukt/' + this.idDelete,
        httpOptions
      )
      .subscribe(
        (res) => {
          console.log(res);
          this.toastr.error('Usunięto rekord z bazy');
        },
        (error) => {
          this.toastr.error('Brak uprawnien');
        }
      );
  }
}
