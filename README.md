# AscendantCodeTest
Se crea solucion el cual recibe un token este token se genera por medio del consumo del metodo Token Get() el cual recibe un usuario y retorna el token y el cual expira en 5 minutos, el cual se podra cambiar a mas tiempo.
 #Ejemplo para consumo del token 

{
"Name": "Ascendant",
"Pasword": "Ascendant"
}

#Ejemplo de resultado del consumo del token 

{
   "message": "",
   "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFzY2VuZGFudCIsIm5iZiI6MTY0MTc2NTA3OCwiZXhwIjoxNjQxNzY1NDM4LCJpYXQiOjE2NDE3NjUwNzh9.Ug2VHGxrcPKweXDz1_z8EE7X7IvRFkCEjGQYffAFciE",
   "type": "Bearer",
   "expira": 5
}

Luego de tener el token se crearon dos metodos los cuales son CalculateTaxesOrder() y GetTaxRatesLocation() los cuales se recibe en el Header la "Authorization" el token Generado enteriormente con la palaba Bearer antes del token:

##Metodo GetTaxRatesLocation()

#Ejemplo de url con el parametro 

https://localhost:44351/GetTaxRatesLocation?zip=90404

#Ejemplo de retorno del consumo del metodo 

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

##Metodo GetTaxRatesLocation()

#Ejemplo de url con el parametro 

https://localhost:44351/GetTaxRatesLocation?zip=90404

#Ejemplo de retorno del consumo del metodo 

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

##Metodo CalculateTaxesOrder()

#Ejemplo de url de request 

{
	"to_country": "US",
	"to_zip": "90002",
	"to_state": "CA",
	"amount": 15,
	"shipping": 1.5
}

#Ejemplo de retorno del consumo del metodo 

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

Para la creacion de este proyecto solo se vio necesario el manejo de 2 capas, la capa de usuario y la capa de negocio, aunque en la capa de negocio se dividio los modelos de los servicios externos y el manejo de HttpClient  
en este ultimo se implento un patron fabrica el cual si tendríamos varias Calculadoras de impuestos, el servicio de impuestos podra decidir cuál usar en función del Cliente.



