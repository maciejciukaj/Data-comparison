import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Chart } from 'node_modules/chart.js';
import { registerables } from 'node_modules/chart.js';

@Component({
  selector: 'app-chart2',
  templateUrl: './chart2.component.html',
  styleUrls: ['./chart2.component.css'],
})
export class Chart2Component implements OnInit {
  cenyChartDane: any;
  cenyWartosci: any;
  wojewodztwa: [
    'LUBELSKIE',
    'MAZOWIECKIE',
    'DOLNOŚLĄSKIE',
    'ŚWIĘTOKRZYSKIE',
    'KUJAWSKO-POMORSKIE',
    'LUBUSKIE',
    'MAŁOPOLSKIE',
    'PODKARPACKIE',
    'POMORSKIE',
    'ŁÓDZKIE',
    'OPOLSKIE',
    'PODLASKIE',
    'ŚLĄSKIE',
    'WARMIŃSKO-MAZURSKIE',
    'WIELKOPOLSKIE',
    'ZACHODNIOPOMORSKIE'
  ];

  constructor(private http: HttpClient) {
    Chart.register(...registerables);
  }

  ngOnInit(): void {
    this.getDaneCenyLata();
  }

  getDaneCenyLata() {
    this.http
      .get('https://localhost:5001/api/ceny/getCenyBaza/LUBELSKIE/ryż - za 1kg')
      .subscribe((response) => {
        this.cenyChartDane = response;
        let tablicaL = [];
        let tablicaW = [];
        let nazwaTowaru = 'ryż - za 1 kg';
        let nazwaWoj = 'LUBELSKIE';
        for (let item of this.cenyChartDane) {
          tablicaL.push(item.rok);
        }
        for (let item of this.cenyChartDane) {
          tablicaW.push(item.wartosc);
        }
        this.getChart(tablicaL, tablicaW, nazwaWoj, nazwaTowaru);
      });
  }

  getChart(daneL: any, daneW: any, nazwaWoj: any, nazwaTowaru: any) {
    const ctx = document.getElementById('myChart');
    const myChart = new Chart('myChart2', {
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
            label: 'Ceny -- ' + nazwaTowaru + ' -- ' + nazwaWoj,
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
          },
        },
      },
    });
  }
}
