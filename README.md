# cookie-stand-api

## Overview
creating an API suitable for handling the CRUD operations for the Pat’s Salmon Cookie Stand operation

---

## ERD Diagram

![CookieStand ERD](../assets/CookieStandERD.PNG)

---

## Feature Tasks and Requirements

Creating an API, backed by a database with the following requirements:

API
1. POST: `/api/cookiestand`
* Accepts an object with the following shape:
```shell
{
   "location": "Barcelona",
   "description": "",
   "minimum_customers_per_hour": 3,
   "maximum_customers_per_hour": 7,
   "average_cookies_per_sale": 2.5,
   "owner": null
}
```

2. GET: `/api/cookiestands`

* Returns a JSON object with the following shape:
```shell
[
  {
    "id": 336,
    "location": "Barcelona",
    "description": "",
    "hourly_sales": [
      17,
      7,
      7,
      7,
      15,
      17,
      7,
      7,
      12,
      7,
      7,
      10,
      17,
      17
    ],
    "minimum_customers_per_hour": 3,
    "maximum_customers_per_hour": 7,
    "average_cookies_per_sale": 2.5,
    "owner": null
  }, ...
]
```

3. GET: `/api/cookiestand/{id}`
* Returns an object formatted as above, for a single cookie stand with the given ID

4. DELETE: `/api/cookiestand/{id}`
* Deletes a cookie stand with the given ID
* Returns no content

4. PUT: `/api/cookiestand{id}`
* Accepts a JSON Object formatted as a POST object.
* Note: Requires the ID to be included in the object
* Return the cookie stand object as saved in the database

## Depolyment

This API Project is Depolyed on Azure, and Use Swagger Documentation:

URL: https://cookiestandapi20231011112821.azurewebsites.net

![Swagger Documentation](../assets/SwaggerDocumentation.PNG)
