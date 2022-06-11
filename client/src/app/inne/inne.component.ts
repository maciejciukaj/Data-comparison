import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

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
      .post('https://localhost:5001/api/db/dodajCeneProduktu', this.model)
      .subscribe((res) => {
        console.log(res);
        this.toastr.info('Dodano rekord do bazy');
      });
  }
  deleteDane() {
    return this.http
      .delete('https://localhost:5001/api/db/usunProdukt/' + this.idDelete)
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
