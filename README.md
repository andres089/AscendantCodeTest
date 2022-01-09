# AscendantCodeTest
Se creo algunos métodos, los cuales recibe un token en el Header, este token se genera por medio del consumo del método Token/Get() y el cual es creado por medio de Json Web Token (JWT) el cual recibe un usuario y contraseña y retorna el token y el cual expira en 5 minutos, el cual se podrá cambiar a más tiempo según sea la solicitud. 

#Ejemplo para consumo del token
Login

Usuario: Ascendant
Contraseña: Ascendant

Url

https://localhost:44351/token 

Request

{ "Name": "Ascendant", "Pasword": "Ascendant" }

Response

{ "message": "", "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFzY2VuZGFudCIsIm5iZiI6MTY0MTc2NTA3OCwiZXhwIjoxNjQxNzY1NDM4LCJpYXQiOjE2NDE3NjUwNzh9.Ug2VHGxrcPKweXDz1_z8EE7X7IvRFkCEjGQYffAFciE", "type": "Bearer", "expira": 5 }

Luego de tener el token se crearon dos métodos los cuales son CalculateTaxesOrder() y GetTaxRatesLocation() los cuales se recibe en el Header la "Authorization" el cual es el token Generado anteriormente con la palaba Bearer

#Ejemplo de GetTaxRatesLocation()

Url
https://localhost:44351/GetTaxRatesLocation?zip=90404
Request
https://localhost:44351/GetTaxRatesLocation?zip=90404
Response
{
   "message": null,
   "rate":    {
      "city": "SANTA MONICA",
      "city_rate": 0,
      "combined_district_rate": 0.03,
      "combined_rate": 0.1025,
      "country": "US",
      "country_rate": 0,
      "county": "LOS ANGELES",
      "county_rate": 0.01,
      "freight_taxable": false,
      "state": "CA",
      "state_rate": 0.0625,
      "zip": "90404"
   }
}

#Ejemplo de CalculateTaxesOrder ()

Url

https://localhost:44351/CalculateTaxesOrder 

Request
{
	"to_country": "US",
	"to_zip": "90002",
	"to_state": "CA",
	"amount": 15,
	"shipping": 1.5
}
Response
{
   "message": null,
   "tax":    {
      "amount_to_collect": 0,
      "freight_taxable": false,
      "has_nexus": false,
      "jurisdictions": null,
      "order_total_amount": 16.5,
      "rate": 0,
      "shipping": 1.5,
      "tax_source": null,
      "taxable_amount": 0
   }
}

Para la creación de este proyecto solo se vio necesario el manejo de 2 capas, la capa de usuario y la capa de negocio, aunque en la capa de negocio se divide los modelos de los servicios externos y el manejo de HttpClient.

En este último se implementó un patrón fabrica el cual si tuviéramos varias Calculadoras de impuestos, el servicio de impuestos podrá decidir cuál usar en función del Cliente.



