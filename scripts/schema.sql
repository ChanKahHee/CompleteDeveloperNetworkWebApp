CREATE TABLE `Users` (
    `Id` BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Username` VARCHAR(255),
    `Mail` VARCHAR(255),
    `PhoneNumber` VARCHAR(20),
    `Hobby` VARCHAR(255)
);

CREATE TABLE `Skills` (
    `Id` BIGINT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` VARCHAR(255) NOT NULL,
    `UserId` BIGINT,
    CONSTRAINT `FK_Skills_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users`(`Id`) ON DELETE CASCADE
);
