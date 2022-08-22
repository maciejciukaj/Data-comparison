# Data comparison website 📊

Website with a comparison of Poles salaries in relation to the average prices of food products over 10 years.

## Functionalities

1. There are two charts ([Chartjs](https://www.chartjs.org/)) on the home page that you can use to view your data
2. Data can be displayed based on the region or the name of the grocery item
3. Website offers access to two subpages with data disaplayed in [table](https://material.angular.io/components/table/overview)
4. Tables have a data sorting function
5. In each of the subpages there is an option to add a record or delete it based on the ID
6. Using the website is possible after creating an account and logging in
7. [JWT](https://jwt.io/introduction)-based service authorization
8. Data stored using [SQLite](https://www.sqlite.org/index.html)


## Setup

Open two terminals and run following scripts:

*Server* :

```shell
> cd API
> dotnet watch run
```

*Client* :

```shell
> cd client
> ng serve
```
*Url* :
```shell
https://localhost:4200
```
## Technologies
<ul>

**.NET**:  6.0

**Angular**: 12.2.17

</ul>

