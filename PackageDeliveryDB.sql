-- Create a new database
CREATE DATABASE PackageDelivery01;


-- Create Customer table
CREATE TABLE Customer (
    CustomerID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Address VARCHAR(255) NOT NULL
);


-- Create Package table
CREATE TABLE Package (
    PackageID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT NOT NULL,
    Weight DECIMAL(10, 2) NOT NULL,
    ServiceType VARCHAR(50) NOT NULL,
    Status VARCHAR(50) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);


-- Create Tracking table
CREATE TABLE Tracking (
    TrackingID INT AUTO_INCREMENT PRIMARY KEY,
    PackageID INT NOT NULL,
    Location VARCHAR(255) NOT NULL,
    Status VARCHAR(50) NOT NULL,
    Timestamp DATETIME NOT NULL,
    FOREIGN KEY (PackageID) REFERENCES Package(PackageID)
);





--Sample Customers
INSERT INTO customer (Name, Address)
VALUES 
('Craig Johnson', '123 Main St, Hattiesburg'),
('Tori Keys', '75 Garland Dr, Jackson'),
('Tristian Keys', '55 GreyHound Ave, Seminary');

-- Insert data into Package table
INSERT INTO package (CustomerID, Weight, ServiceType, Status)
VALUES 
(1, 2.5, 'Standard', 'In Transit'),
(2, 3.2, 'Second Day', 'Delivered'),
(3, 1.8, 'Overnight', 'Pending');


-- Insert data into tracking table
INSERT INTO Tracking (PackageID, Location, Status, Timestamp)
VALUES 
(1, 'Hattiesburg Hub', 'In Transit', '2024-12-01 08:00:00'),
(2, 'Jackson Distribution Center', 'Delivered', '2024-12-02 14:00:00'),
(3, 'Laurel Mail Hub', 'Pending', '2024-12-05 10:00:00');


