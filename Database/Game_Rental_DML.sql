-- a. What was the most interesting game that had maximum number of renters (clients)? 
SELECT rent.Game_ID ,
game.Game_Name ,
COUNT(rent.Client_ID) Renters
FROM rent
JOIN game
ON rent.Game_ID = game.Game_ID
GROUP BY rent.Game_ID
HAVING Renters = (
SELECT MAX(Rents) FROM (
SELECT COUNT(rent.Client_ID) Rents FROM rent GROUP BY rent.Game_ID
) SubQ
);
-- b. What were the games that hadn't any renters (clients) last month?
SELECT game.Game_ID, game.Game_Name
FROM game 
LEFT JOIN rent ON game.Game_ID = rent.Game_ID 
AND rent.Rent_Date >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
WHERE rent.Game_ID IS NULL;
-- c. Who was the renter (client) with the maximum renting last month? 
SELECT rent.Client_ID ,
client.Client_Name ,
COUNT(rent.Client_ID) Rents
FROM rent
JOIN client
ON rent.Client_ID = client.Client_ID
AND rent.Rent_Date >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
GROUP BY rent.Client_ID
HAVING Rents = (
SELECT MAX(Rentings) FROM (
SELECT COUNT(rent.Client_ID) Rentings FROM rent GROUP BY rent.Client_ID 
) SubQ
);
-- d. Who was the vendor with the maximum renting out last month? 
SELECT game.Vendor_ID ,
vendor.Vendor_Name,
COUNT(rent.Game_ID) Rents
FROM vendor
JOIN game
ON vendor.Vendor_ID = game.Vendor_ID
JOIN rent
ON game.Game_ID = rent.Game_ID
AND rent.Rent_Date >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
GROUP BY game.Vendor_ID
HAVING Rents = ( SELECT MAX(SubRent) FROM (
SELECT COUNT(rent.Game_ID) SubRent  FROM vendor JOIN game ON vendor.Vendor_ID = game.Vendor_ID JOIN rent ON game.Game_ID = rent.Game_ID AND rent.Rent_Date >= DATE_SUB(CURDATE(), INTERVAL 30 DAY) GROUP BY game.Vendor_ID
) SubQ
);
-- e.Who were the vendors whose games hadn't any renting last month? 
SELECT vendor.Vendor_ID,
vendor.Vendor_Name
FROM vendor
WHERE vendor.Vendor_ID NOT IN (
SELECT DISTINCT game.Vendor_ID
FROM game
JOIN rent
ON game.Game_ID = rent.Game_ID 
WHERE rent.Rent_Date >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
);
-- f.Who were the vendors who didn't add any game last year?
SELECT DISTINCT vendor.Vendor_ID,
vendor.Vendor_Name
FROM vendor
LEFT JOIN game
ON vendor.Vendor_ID = game.Vendor_ID
WHERE game.Add_Date <= DATE_SUB(CURDATE(), INTERVAL 365 DAY)
OR game.Add_Date IS NULL;