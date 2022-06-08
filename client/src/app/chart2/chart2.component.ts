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

  chosenProduct: any;
  chosenRegion: any;
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
  towary = [
    { name: 'ryż - za 1kg' },
    { name: 'bułka pszenna - za 50g' },
    { name: 'chleb żytni razowy zwykły - za 1kg' },
    { name: 'mąka pszenna - za 1kg' },
    { name: 'kasza jęczmienna - za 0,5kg' },
    { name: 'mięso wołowe z kością (rostbef) - za 1kg' },
    { name: 'kiełbasa wędzona - za 1kg' },
    { name: 'boczek wędzony - za 1kg' },
  ];

  constructor(private http: HttpClient) {
    Chart.register(...registerables);
  }

  ngOnInit(): void {
    this.chosenProduct = 'kiełbasa wędzona - za 1kg';
    this.chosenRegion = 'LUBELSKIE';
    this.getDaneCenyLata(this.chosenRegion, this.chosenProduct);
  }

  generateChart() {
    console.log(this.chosenProduct + this.chosenRegion);
    let costam = `https://localhost:5001/api/ceny/getCenyBaza/LUBELSKIE/${this.chosenProduct}`;
    costam = encodeURI(costam);
    console.log(costam);
    this.myChart.destroy();
    this.getDaneCenyLata(this.chosenRegion, this.chosenProduct);
  }

  getDaneCenyLata(chosenProduct: any, chosenRegion: any) {
    let encoded = encodeURI(
      `https://localhost:5001/api/ceny/getCenyBaza/${this.chosenRegion}/${this.chosenProduct}`
    );
    this.http.get(encoded).subscribe((response) => {
      this.cenyChartDane = response;
      let tablicaL = [];
      let tablicaW = [];
      let nazwaTowaru = chosenProduct;
      let nazwaWoj = chosenRegion;
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
    this.myChart = new Chart('myChart2', {
      type: 'line',
      data: {
        labels: daneL,
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
