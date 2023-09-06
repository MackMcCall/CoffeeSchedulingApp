/*
CREATE DATABASE IF NOT EXISTS CoffeeSchedulerDB;
USE CoffeeSchedulerDB;

CREATE TABLE Coffees (
    CoffeeID INT AUTO_INCREMENT PRIMARY KEY,
    Roaster VARCHAR(50) NOT NULL,
    Producer VARCHAR(100),
    Country VARCHAR(50),
    Region VARCHAR(50),
    Variety VARCHAR(50),
    Process VARCHAR(50),
    RoastDate DATE,
    DaysRestNeeded INT,
    ReadyToDrink BOOL,
    Grams DECIMAL(5, 1)
);

INSERT INTO Coffees (Roaster, Producer, Country, Region, Variety, Process, RoastDate, DaysRestNeeded, ReadyToDrink, Grams)
VALUES
    ('Sey', 'Kangurumai', 'Kenya', 'Muranga', 'Field Blend', 'Washed', '2023-08-15', 18, 1, 89.0),
    ('Sey', 'Paxtle', 'Mexico', 'San Mateo, Yoloxochitlán', 'Typica & Bourbon', 'Washed', '2023-08-15', 18, 1, 34.5),
    ('Passenger', 'Tulio Cotacio', 'Colombia', 'La Plata, Huila', 'Var. Colombia', 'Washed', '2023-08-21', 18, 0, 285.0);

CREATE TABLE Users (
	UserID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(50)
);

INSERT INTO Users (Name) VALUES ('Mack'), ('Isaiah');

CREATE TABLE Inventories (
	UserBagID INT AUTO_INCREMENT PRIMARY KEY,
    CoffeeID INT,
    FOREIGN KEY (CoffeeID) REFERENCES Coffees(CoffeeID),
    UserID INT, 
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

INSERT INTO Inventories (CoffeeID, UserID) VALUES (1, 1), (2, 1), (3, 1);
*/
