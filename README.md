# Data comparison website 📊


Website presents two charts with the possibility of changing the data set.

The first chart shows the average salaries of Poles over 10 years, while the second one shows the average prices of selected food products over 10 years.

Using the website resources is possible after registering and logging in to your account.

The data resources are also presented in a table with the option of sorting records, for example by 'id' or 'voivodship name'

Data sets can be edited, I implemented the function of adding a new record and deleting an existing one by entering its id.

The website also offers the option of downloading a data set in a formatted JSON or XML version, where you can find out about the average price of products in a given year, as well as the amount of food products available for purchase in relation to the average salary.

Authorization of access to website resources is done with the use of [Json Web Token](https://jwt.io/).

The server side was created using the .NET framework, and the client part using Angular.

I used [chart.js](https://www.chartjs.org/) for the display of charts. The messages in the lower right corner come from the [toastr](https://www.npmjs.com/package/ngx-toastr) package.

The page can be launched using two terminal windows:


*Server*
```shell

> cd API

> dotnet watch run

```

*Client*
```shell

> cd client

> ng serve

```

**Website address:**
```
https://localhost:4200
```
Site was built using [.NET](https://dotnet.microsoft.com/en-us/), [Angular](https://angular.io/) and [SQLite](https://www.sqlite.org/index.html).
