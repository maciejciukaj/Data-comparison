import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Injectable, OnInit } from '@angular/core';
import { Chart } from 'node_modules/chart.js';
import { registerables } from 'node_modules/chart.js';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + JSON.parse(localStorage.getItem('user'))?.token,
  }),
};
@Injectable({ providedIn: 'root' })
@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css'],
})
export class ChartComponent implements OnInit {
  wynagrodzeniaChartDane: any;
  wynagrodzenieWartosci: any;
  selectedWoj: any;
  value: any;
  myChart: any;

  wojewodztwa = [
    { name: 'LUBELSKIE' },
    { name: 'MAZOWIECKIE' },
    { name: 'DOLNOŚLĄSKIE' },
    { name: 'ŚWIĘTOKRZYSKIE' },
    { name: 'KUJAWSKO-POMORSKIE' },
    { name: 'LUBUSKIE' },
    { name: 'MAŁOPOLSKIE' },
    { name: 'PODKARPACKIE' },
    { name: 'POMORSKIE' },
    { name: 'ŁÓDZKIE' },
    { name: 'OPOLSKIE' },
    { name: 'PODLASKIE' },
    { name: 'ŚLĄSKIE' },
    { name: 'WARMIŃSKO-MAZURSKIE' },
    { name: 'WIELKOPOLSKIE' },
    { name: 'ZACHODNIOPOMORSKIE' },
  ];

  constructor(private http: HttpClient) {
    Chart.register(...registerables);
  }

  ngOnInit(): void {
    this.value = 'LUBELSKIE';
    this.getDaneWynLata(this.value);
  }

  generateChart() {
    console.log(this.value);
    this.myChart.destroy();
    this.getDaneWynLata(this.value);
  }

  getDaneWynLata(value: any) {
    this.http
      .get(
        'https://localhost:5001/api/wynagrodzenia/getWynagrodzeniaBaza/' +
          value,
        httpOptions
      )
      .subscribe((response) => {
        this.wynagrodzeniaChartDane = response;
        let tablicaL = [];
        let tablicaW = [];
        let nazwaWoj = value;
        for (let item of this.wynagrodzeniaChartDane) {
          tablicaL.push(item.rok);
        }
        for (let item of this.wynagrodzeniaChartDane) {
          tablicaW.push(item.wartosc);
        }
        this.getChart(tablicaL, tablicaW, nazwaWoj);
      });
  }

  getChart(daneL: any, daneW: any, nazwaWoj: any) {
    const ctx = document.getElementById('myChart');
    this.myChart = new Chart('myChart', {
      type: 'line',
      data: {
        labels: /* [
          '2011',
          '2012',
          '2013',
          '2014',
          '2015',
          '2016',
          '2017',
          '2018',
          '2019',
          '2020',
          '2021',
        ]*/ daneL,

        datasets: [
          {
            label: 'Wynagrodzenia --- ' + nazwaWoj,
            data: daneW,
            backgroundColor: [
              'rgba(255, 99, 132, 0.2)',
              'rgba(54, 162, 235, 0.2)',
              'rgba(255, 206, 86, 0.2)',
              'rgba(75, 192, 192, 0.2)',
              'rgba(153, 102, 255, 0.2)',
              'rgba(255, 159, 64, 0.2)',
            ],
            borderColor: [
              'rgba(255, 99, 132, 1)',
              'rgba(54, 162, 235, 1)',
              'rgba(255, 206, 86, 1)',
              'rgba(75, 192, 192, 1)',
              'rgba(153, 102, 255, 1)',
              'rgba(255, 159, 64, 1)',
            ],
            borderWidth: 1,
          },
        ],
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
            title: {
              display: true,
              text: 'Wynagrodzenie w zł',
            },
          },
          x: {
            title: {
              display: true,
              text: 'Lata',
            },
          },
        },
      },
    });
  }
}
