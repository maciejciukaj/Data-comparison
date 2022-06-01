import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dane',
  templateUrl: './dane.component.html',
  styleUrls: ['./dane.component.css'],
})
export class DaneComponent implements OnInit {
  dane: any;
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getDane();
  }

  getDane() {
    return this.http.get('https://localhost:5001/api/dane/').subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error),
    });
  }
}
