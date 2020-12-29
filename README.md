# Microservice

# Product service
1.Technology: Microsoft ASP .NET Core Framework

2.Database: SQL server

# Rating Service
1.Technology: Node.js

2.Database: mysql

# To run product service
1.go to productService folder and open Microservices.sln with visual studio.

2.to setup sql server, go to DatabaseContext.cs and change the value of datasource and database name according to your sql server in the connection string.

3.delete the migration folder. 

4.run the following commands in nuget package manager console:

add-migration initial

update-database

5.this will create the necessary tables for the entities.

6.run the solution

7.https://localhost:5001/product/list  this link would open on your brower.

8.Open Postman. Send a GET request to https://localhost:5001/product/list to get product list.

9.Send a POST request to https://localhost:5001/product/add to add a product with the inputs in the form body. 

10.Send a POST request to https://localhost:5001/product/updateCategory to update the category of the product. specify the product id and category id in the body of request.

11.Send a DELETE request to https://localhost:5001/product/remove/{id} to remove a product.


 
# to run rating service

1.open the ratingService folder with vs code.

2.run the following command in the terminal-

npm install --save express mysql body-parser

3.run the query.sql file and this will create the database and table required for the service.

4.make changes in the mysqlconnection according to your username and password of mysql server and database name ratingdb.

5.run the project with this command

node index.js

6."connection established!Express server is runnig at port no : 3001!" should be displayed in console.

7.open postman. send a POST request with url http://localhost:3001/rate along with input datas to add rating to a product. specify the productId,rating,raterId.

8.see the list with a GET request to thiis url http://localhost:3001/ratings





