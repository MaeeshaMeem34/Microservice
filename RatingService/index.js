const bodyparser = require("body-parser");
const mysql = require("mysql");
const express = require("express");
var app = express();

app.use(bodyparser.json());
const axios = require("axios");

var mysqlConnection = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "",
  database: "ratingdb",
  multipleStatements: true,
});

mysqlConnection.connect((error) => {
  if (!error) {
    console.log("Connection established!");
  } else {
    console.log("Connection failed \n Error: " + JSON.stringify(error));
  }
});

app.listen(3001, () =>
  console.log("Express server is runnig at port no : 3001")
);

//get all ratings

app.get("/ratings", (req, res) => {
  mysqlConnection.query("SELECT * FROM rating", (err, rows, fields) => {
    if (!err) res.send(rows);
    else console.log(err);
  });
});



app.post("/rate", (req, res) => {
  let rating = req.body;
  var sql =
    "SET @product_id=? ; SET @value=? ; SET @rater_id=?;\
    CALL store_rating(@product_id,@value, @rater_id);";


    mysqlConnection.query(
      sql,
      [rating.productId, rating.rating, rating.raterId],
      (err, rows) => {
        if (!err) {
          res.send(rows);
        } else console.log(err);
      }
    );
  
});
