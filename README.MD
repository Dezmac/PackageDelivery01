# Package Delivery Application

This is a **Package Delivery Application** that allows users to track their packages, view package details, and see the customer information associated with each package.

## Features
- **Package Lookup**: Users can search for package details by entering the package ID.
- **Customer Information**: View customer details such as name and address associated with each package.
- **Tracking Information**: View tracking details, including the package's current location and status.
  
## Getting Started

Follow these instructions to set up and run the application on your local machine.

### Prerequisites
Before you begin, ensure you have the following software installed:
- **.NET SDK**: Version 6.0 or later. You can download it from [here](https://dotnet.microsoft.com/download).
- **MySQL**: Make sure MySQL is installed and running on your machine. You can download it from [here](https://dev.mysql.com/downloads/).

Usage
To use the application:

1. Enter a Package ID in the provided search field. 
2. Click the Search button.
3. The app will display the package details, customer information, and tracking information, if available.

Database Schema:
Customer Table
CustomerID: INT (Primary Key)
Name: VARCHAR(100) (Customer name)
Address: VARCHAR(255) (Customer address)
Package Table
PackageID: INT (Primary Key)
CustomerID: INT (Foreign Key from Customer table)
Weight: DECIMAL (Package weight in kg)
ServiceType: VARCHAR(50) (Package service type like Standard, Second Day, etc.)
Status: VARCHAR(50) (Package status like In Transit, Delivered, Pending)
Tracking Table
TrackingID: INT (Primary Key)
PackageID: INT (Foreign Key from Package table)
Location: VARCHAR(255) (Current location of the package)
Status: VARCHAR(50) (Current status of the package, e.g., In Transit, Delivered)
Timestamp: DATETIME (Timestamp of the status update)

Test Data:
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
