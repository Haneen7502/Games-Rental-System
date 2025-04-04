SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
-- ////////////////////////////////////////////////////// --
CREATE SCHEMA IF NOT EXISTS Game_Rental DEFAULT CHARACTER SET utf8mb4;
USE Game_Rental;
-- ////////////////////////////////////////////////////// --
CREATE TABLE IF NOT EXISTS Admin (
Admin_ID INT AUTO_INCREMENT PRIMARY KEY,
Admin_Name VARCHAR(255) NOT NULL,
Pass VARCHAR(255) NOT NULL
);
-- ////////////////////////////////////////////////////// --
CREATE TABLE IF NOT EXISTS Vendor (
Vendor_ID INT AUTO_INCREMENT PRIMARY KEY,
Vendor_Name VARCHAR(255) NOT NULL,
Pass VARCHAR(255) NOT NULL,
Admin_ID INT,
CONSTRAINT FK_V_A FOREIGN KEY (Admin_ID) 
REFERENCES Admin (Admin_ID)
ON DELETE SET NULL
ON UPDATE CASCADE
);
-- ////////////////////////////////////////////////////// --
CREATE TABLE IF NOT EXISTS Client (
Client_ID INT AUTO_INCREMENT PRIMARY KEY,
Client_Name VARCHAR(255) NOT NULL,
Pass VARCHAR(255) NOT NULL,
Admin_ID INT,
CONSTRAINT FK_C_A FOREIGN KEY (Admin_ID)
REFERENCES Admin (Admin_ID)
ON DELETE SET NULL
ON UPDATE CASCADE 
);
-- ////////////////////////////////////////////////////// --
CREATE TABLE IF NOT EXISTS Game (
Game_ID INT AUTO_INCREMENT PRIMARY KEY,
Game_Name VARCHAR(255) NOT NULL,
Category VARCHAR(255) NOT NULL,
Add_Date DATE NOT NULL,
Price DECIMAL(10,2) NOT NULL DEFAULT 0.00,
Admin_ID INT,
Vendor_ID INT NOT NULL,
CONSTRAINT FK_G_A FOREIGN KEY (Admin_ID)
REFERENCES Admin (Admin_ID)
ON DELETE SET NULL
ON UPDATE CASCADE,
CONSTRAINT FK_G_V FOREIGN KEY (Vendor_ID)
REFERENCES Vendor (Vendor_ID)
ON DELETE CASCADE
ON UPDATE CASCADE
);
-- ////////////////////////////////////////////////////// --
CREATE TABLE IF NOT EXISTS Rent (
Rent_Date DATE NOT NULL,
Return_Date DATE NOT NULL,
CHECK (Rent_Date < Return_Date),
Actual_Return_Date DATE DEFAULT NULL,
Status TINYINT NOT NULL,
Game_ID INT ,
Client_ID INT,
CONSTRAINT PRIMARY KEY (Client_ID,Game_ID,Rent_Date),
CONSTRAINT FK_R_G FOREIGN KEY (Game_ID)
REFERENCES Game (Game_ID)
ON DELETE CASCADE
ON UPDATE CASCADE,
CONSTRAINT FK_R_C FOREIGN KEY (Client_ID)
REFERENCES Client (Client_ID)
ON DELETE CASCADE
ON UPDATE CASCADE
);
-- ////////////////////////////////////////////////////// --
CREATE TABLE Game_Uploads (
Upload_ID INT AUTO_INCREMENT PRIMARY KEY,
Game_Name VARCHAR(255) UNIQUE NOT NULL,
Category VARCHAR(255) NOT NULL,
Price DECIMAL(10,2) NOT NULL DEFAULT 0.00,
Add_Date DATE NOT NULL DEFAULT (CURRENT_DATE),
Vendor_ID INT NOT NULL,
Approval_Status ENUM('Pending', 'Approved', 'Rejected') NOT NULL DEFAULT 'Pending',
Approval_Date DATE DEFAULT NULL,
CONSTRAINT FK_GU_V FOREIGN KEY (Vendor_ID)
REFERENCES vendor(Vendor_ID) 
ON DELETE CASCADE
ON UPDATE CASCADE
);
-- ////////////////////////////////////////////////////// --
CREATE TABLE Game_Updates (
Update_ID INT AUTO_INCREMENT PRIMARY KEY, 
Game_ID INT NOT NULL,                      
Updated_Name VARCHAR(255) DEFAULT NULL,    
Updated_Category VARCHAR(100) DEFAULT NULL,
Updated_Price DECIMAL(10,2) DEFAULT NULL,  
Updated_Description TEXT NOT NULL ,    
Update_Date DATE NOT NULL DEFAULT (CURRENT_DATE), 
Approval_Status ENUM('Pending', 'Approved', 'Rejected') NOT NULL DEFAULT 'Pending',  
Approval_Date DATE DEFAULT NULL,                     
Vendor_ID INT NOT NULL,                   
CONSTRAINT FK_GU_G FOREIGN KEY (Game_ID)
REFERENCES game(Game_ID)
ON DELETE CASCADE
ON UPDATE CASCADE,
CONSTRAINT FK_GUP_V FOREIGN KEY (Vendor_ID) 
REFERENCES vendor(Vendor_ID) 
ON DELETE CASCADE
ON UPDATE CASCADE
);
-- ////////////////////////////////////////////////////// --
ALTER TABLE admin ADD CONSTRAINT UQ_Admin_Name UNIQUE (Admin_Name);
ALTER TABLE vendor ADD CONSTRAINT UQ_Vendor_Name UNIQUE (Vendor_Name);
ALTER TABLE client ADD CONSTRAINT UQ_Client_Name UNIQUE (Client_Name);
ALTER TABLE game ADD CONSTRAINT UQ_Game_Name UNIQUE (Game_Name);
ALTER TABLE rent 
MODIFY COLUMN Game_ID INT NOT NULL,
MODIFY COLUMN Client_ID INT NOT NULL;
ALTER TABLE Client DROP FOREIGN KEY FK_C_A;
ALTER TABLE Vendor DROP FOREIGN KEY FK_V_A;
ALTER TABLE Client DROP COLUMN Admin_ID;
ALTER TABLE Vendor DROP COLUMN Admin_ID;