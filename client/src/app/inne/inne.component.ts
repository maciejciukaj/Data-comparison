import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-inne',
  templateUrl: './inne.component.html',
  styleUrls: ['./inne.component.css'],
})
export class InneComponent implements OnInit {
  dane: any;

  constructor(private http: HttpClient) {}

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
}
