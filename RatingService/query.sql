use ratingdb;

DROP table if exists rating;
CREATE TABLE rating (
    id int not null auto_increment primary key,
    productId varchar(50) NULL,
    rating INT ,
    raterId varchar(50)  NULL
);

drop procedure if exists store_rating;
CREATE PROCEDURE store_rating(in product_ID varchar(50), in value int, in rater_ID varchar(50))

BEGIN
    DECLARE Rater_Count INT;
    SELECT  COUNT(rating.raterId)
    INTO Rater_Count
     FROM rating
    WHERE productId = product_ID AND raterId = rater_ID;
    IF Rater_Count = 0 THEN
        insert into rating (productId, rating,raterId)
  value (product_ID, value, rater_ID);
    ELSE
        UPDATE rating SET rating =value  WHERE productId = product_ID AND raterId = rater_ID;
    END IF;

END;

call store_rating(2,5, 1);