INSERT INTO admin (Admin_Name, Pass) VALUES
('Alice_Admin', 'admin123'),
('Bob_Admin', 'securepass');
SELECT * FROM admin;
-- //////////////////////////////////////////// --
INSERT INTO vendor (Vendor_Name, Pass, Admin_ID) VALUES
('EA Games', 'vendor456', 2),
('Nintendo', 'vendor789', 1),
('Ubisoft', 'vendor123', 1),
('Rockstar Games', 'vendor999', 2); 
SELECT * FROM vendor;
-- //////////////////////////////////////////// --
INSERT INTO client (Client_Name, Pass, Admin_ID) VALUES
('John_Doe', 'client123', 1),
('Jane_Smith', 'pass456', 2),
('Michael_Brown', 'pass789', 1);
SELECT * FROM client;
-- //////////////////////////////////////////// --
INSERT INTO game (Game_Name, Category, Add_Date, Price, Admin_ID, Vendor_ID) VALUES
('Assassin Creed', 'Action', DATE_SUB(CURDATE(), INTERVAL 70 DAY), 59.99, 1, 1),
('FIFA 23', 'Sports', DATE_SUB(CURDATE(), INTERVAL 300 DAY), 49.99, 1, 1),
('Mario Kart', 'Racing', DATE_SUB(CURDATE(), INTERVAL 280 DAY), 39.99, 2, 2),
('Call of Duty', 'Shooter', DATE_SUB(CURDATE(), INTERVAL 30 DAY), 69.99, 2, 1),
('The Sims 4', 'Simulation', DATE_SUB(CURDATE(), INTERVAL 400 DAY), 29.99, 1, 3),
('Elden Ring', 'RPG', DATE_SUB(CURDATE(), INTERVAL 180 DAY), 59.99, 2, 4),
('Minecraft', 'Sandbox', DATE_SUB(CURDATE(), INTERVAL 380 DAY), 26.99, 1, 3),
('Fortnite', 'Battle Royale', DATE_SUB(CURDATE(), INTERVAL 140 DAY), 0.00, 1, 1),
('Cyberpunk 2077', 'RPG', DATE_SUB(CURDATE(), INTERVAL 50 DAY), 49.99, 2, 2),
('GTA V', 'Action', DATE_SUB(CURDATE(), INTERVAL 100 DAY), 39.99, 1, 4);
SELECT * FROM game;
-- //////////////////////////////////////////// --
INSERT INTO rent (Client_ID, Game_ID, Rent_Date, Return_Date, Actual_Return_Date, Status) VALUES 
(1, 1, DATE_SUB(CURDATE(), INTERVAL 10 DAY), DATE_ADD(CURDATE(), INTERVAL 10 DAY), NULL, 1), -- Ongoing rental
(2, 2, DATE_SUB(CURDATE(), INTERVAL 100 DAY), DATE_SUB(CURDATE(), INTERVAL 95 DAY), DATE_SUB(CURDATE(), INTERVAL 94 DAY), 0), -- Returned 1 day late
(1, 4, DATE_SUB(CURDATE(), INTERVAL 25 DAY), DATE_SUB(CURDATE(), INTERVAL 20 DAY), DATE_SUB(CURDATE(), INTERVAL 18 DAY), 0), -- Returned 2 days late
(2, 5, DATE_SUB(CURDATE(), INTERVAL 15 DAY), DATE_ADD(CURDATE(), INTERVAL 5 DAY), NULL, 1), -- Ongoing rental
(3, 6, DATE_SUB(CURDATE(), INTERVAL 300 DAY), DATE_SUB(CURDATE(), INTERVAL 290 DAY), DATE_SUB(CURDATE(), INTERVAL 289 DAY), 0), -- Returned 1 day late
(1, 8, DATE_SUB(CURDATE(), INTERVAL 15 DAY), DATE_SUB(CURDATE(), INTERVAL 12 DAY), DATE_SUB(CURDATE(), INTERVAL 10 DAY), 0), -- Returned 2 days late
(1, 3, DATE_SUB(CURDATE(), INTERVAL 5 DAY), DATE_ADD(CURDATE(), INTERVAL 5 DAY), NULL, 1), -- Ongoing rental
(3, 5, DATE_SUB(CURDATE(), INTERVAL 3 DAY), DATE_ADD(CURDATE(), INTERVAL 7 DAY), NULL, 1), -- Ongoing rental
(3, 9, DATE_SUB(CURDATE(), INTERVAL 60 DAY), DATE_SUB(CURDATE(), INTERVAL 55 DAY), DATE_SUB(CURDATE(), INTERVAL 54 DAY), 0), -- Returned 1 day late
(3, 6, DATE_SUB(CURDATE(), INTERVAL 14 DAY), DATE_ADD(CURDATE(), INTERVAL 7 DAY), NULL, 1); -- Ongoing rental
SELECT * FROM rent;
-- //////////////////////////////////////////// --
SELECT * FROM game_uploads;
SELECT * FROM game_updates;