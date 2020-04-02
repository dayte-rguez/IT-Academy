-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema ej-bbdd
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema ej-bbdd
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ej-bbdd` DEFAULT CHARACTER SET utf8 ;
USE `ej-bbdd` ;

-- -----------------------------------------------------
-- Table `ej-bbdd`.`Plane`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Plane` (
  `idPlane` INT NOT NULL AUTO_INCREMENT COMMENT 'Id number of the plane',
  `NumPplPlane` INT UNSIGNED NOT NULL COMMENT 'Number of people that fits in the plane',
  `ModelPlane` VARCHAR(45) NOT NULL COMMENT 'Model of the plane',
  PRIMARY KEY (`idPlane`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Seat`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Seat` (
  `idSeat` INT NOT NULL AUTO_INCREMENT COMMENT 'Serial number of the seat',
  `Plane_idPlane` INT NULL,
  PRIMARY KEY (`idSeat`),
  INDEX `fk_Seat_Plane1_idx` (`Plane_idPlane` ASC) VISIBLE,
  CONSTRAINT `fk_Seat_Plane1`
    FOREIGN KEY (`Plane_idPlane`)
    REFERENCES `ej-bbdd`.`Plane` (`idPlane`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Buyer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Buyer` (
  `idBuyer` INT NOT NULL AUTO_INCREMENT,
  `nameBuyer` VARCHAR(45) NOT NULL,
  `dniBuyer` VARCHAR(9) NOT NULL,
  PRIMARY KEY (`idBuyer`),
  UNIQUE INDEX `dniBuyer_UNIQUE` (`dniBuyer` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Painter`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Painter` (
  `idPainter` INT NOT NULL AUTO_INCREMENT COMMENT 'Painter identifier',
  `namePainter` VARCHAR(45) NOT NULL COMMENT 'Name of the painter',
  PRIMARY KEY (`idPainter`),
  INDEX `idx_painter` (`namePainter` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Painting`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Painting` (
  `idPainting` INT NOT NULL AUTO_INCREMENT COMMENT 'Painting identifier',
  `pricePainting` DECIMAL NOT NULL COMMENT 'Price of the painting',
  `Buyer_idBuyer` INT NULL,
  `Painter_idPainter` INT NULL,
  PRIMARY KEY (`idPainting`),
  INDEX `fk_Painting_Buyer1_idx` (`Buyer_idBuyer` ASC) VISIBLE,
  INDEX `fk_Painting_Painter1_idx` (`Painter_idPainter` ASC) VISIBLE,
  CONSTRAINT `fk_Painting_Buyer1`
    FOREIGN KEY (`Buyer_idBuyer`)
    REFERENCES `ej-bbdd`.`Buyer` (`idBuyer`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Painting_Painter1`
    FOREIGN KEY (`Painter_idPainter`)
    REFERENCES `ej-bbdd`.`Painter` (`idPainter`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Creator`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Creator` (
  `idCreator` INT NOT NULL AUTO_INCREMENT COMMENT 'User identifier',
  `nicknameCreator` VARCHAR(45) NOT NULL COMMENT 'Nickname of the user (must be unique)',
  `nameCreator` VARCHAR(45) NULL COMMENT 'Real name of the user',
  `emailCreator` VARCHAR(45) NULL COMMENT 'email of the user',
  `passwordCreator` VARCHAR(45) NOT NULL COMMENT 'Password of the user',
  UNIQUE INDEX `nickUser_UNIQUE` (`nicknameCreator` ASC) VISIBLE,
  PRIMARY KEY (`idCreator`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Video`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Video` (
  `idVideo` INT NOT NULL AUTO_INCREMENT COMMENT 'Video identifier',
  `titlelVideo` VARCHAR(45) NULL COMMENT 'Title of the video',
  `descriptionVideo` VARCHAR(45) NULL COMMENT 'Description of the video',
  `urlVideo` VARCHAR(45) NOT NULL COMMENT 'URL of the video',
  `Creator_idCreator` INT NOT NULL,
  PRIMARY KEY (`idVideo`),
  INDEX `fk_Video_Creator1_idx` (`Creator_idCreator` ASC) VISIBLE,
  CONSTRAINT `fk_Video_Creator1`
    FOREIGN KEY (`Creator_idCreator`)
    REFERENCES `ej-bbdd`.`Creator` (`idCreator`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Author`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Author` (
  `idAuthor` INT NOT NULL AUTO_INCREMENT COMMENT 'Author identifier',
  `nameAuthor` VARCHAR(45) NOT NULL COMMENT 'Name of the author',
  `addressAuthor` VARCHAR(45) NULL COMMENT 'Address of the author',
  PRIMARY KEY (`idAuthor`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Book`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Book` (
  `idBook` INT NOT NULL AUTO_INCREMENT COMMENT 'Book identifier',
  `Author_idAuthor` INT NOT NULL,
  `nameBook` VARCHAR(45) NOT NULL COMMENT 'Name of the book',
  `priceBook` DECIMAL NOT NULL COMMENT 'Price of the book',
  `stockBook` INT UNSIGNED NOT NULL COMMENT 'Titles in stock',
  PRIMARY KEY (`idBook`),
  INDEX `fk_Book_Author1_idx` (`Author_idAuthor` ASC) VISIBLE,
  CONSTRAINT `fk_Book_Author1`
    FOREIGN KEY (`Author_idAuthor`)
    REFERENCES `ej-bbdd`.`Author` (`idAuthor`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Reader`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Reader` (
  `idReader` INT NOT NULL AUTO_INCREMENT COMMENT 'User identifier',
  `nicknameReader` VARCHAR(45) NOT NULL COMMENT 'User name',
  `emailReader` VARCHAR(45) NULL COMMENT 'email of the user',
  `passwordReader` VARCHAR(45) NOT NULL COMMENT 'Password of the user',
  PRIMARY KEY (`idReader`),
  UNIQUE INDEX `nicknameUser_UNIQUE` (`nicknameReader` ASC) VISIBLE,
  UNIQUE INDEX `emailUser_UNIQUE` (`emailReader` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`User` (
  `idUser` INT NOT NULL AUTO_INCREMENT COMMENT 'User identifier',
  `nicknameUser` VARCHAR(45) NOT NULL COMMENT 'User name',
  `nameUser` VARCHAR(45) NULL COMMENT 'Real name of the user',
  `emailUser` VARCHAR(45) NULL COMMENT 'email of the user',
  `passwordUser` VARCHAR(45) NOT NULL COMMENT 'Password of the user',
  PRIMARY KEY (`idUser`),
  UNIQUE INDEX `nicknameUser_UNIQUE` (`nicknameUser` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Friendship`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Friendship` (
  `User_idUser` INT NOT NULL,
  `User_idUser1` INT NOT NULL,
  `descriptionFriendship` VARCHAR(45) NOT NULL COMMENT 'How did they met',
  PRIMARY KEY (`User_idUser`, `User_idUser1`),
  INDEX `fk_User_has_User_User2_idx` (`User_idUser1` ASC) VISIBLE,
  INDEX `fk_User_has_User_User1_idx` (`User_idUser` ASC) VISIBLE,
  CONSTRAINT `fk_User_has_User_User1`
    FOREIGN KEY (`User_idUser`)
    REFERENCES `ej-bbdd`.`User` (`idUser`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_User_has_User_User2`
    FOREIGN KEY (`User_idUser1`)
    REFERENCES `ej-bbdd`.`User` (`idUser`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Picture`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Picture` (
  `idPicture` INT NOT NULL AUTO_INCREMENT COMMENT 'Picture identifier',
  `locationPicture` VARCHAR(45) NULL COMMENT 'Address of the picture',
  `urlPicture` VARCHAR(45) NOT NULL COMMENT 'URL of the picture',
  `User_idUser` INT NOT NULL,
  PRIMARY KEY (`idPicture`),
  INDEX `fk_Picture_User1_idx` (`User_idUser` ASC) VISIBLE,
  CONSTRAINT `fk_Picture_User1`
    FOREIGN KEY (`User_idUser`)
    REFERENCES `ej-bbdd`.`User` (`idUser`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Sale`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Sale` (
  `idSale` INT NOT NULL AUTO_INCREMENT,
  `dateSale` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `Reader_idReader` INT NOT NULL,
  PRIMARY KEY (`idSale`),
  INDEX `fk_Sale_Reader1_idx` (`Reader_idReader` ASC) VISIBLE,
  CONSTRAINT `fk_Sale_Reader1`
    FOREIGN KEY (`Reader_idReader`)
    REFERENCES `ej-bbdd`.`Reader` (`idReader`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Supplier`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Supplier` (
  `idSupplier` INT NOT NULL AUTO_INCREMENT,
  `nameSupplier` VARCHAR(45) NOT NULL COMMENT 'Name of the supplier',
  `streetSupplier` VARCHAR(45) NULL COMMENT 'Address of the supplier (street)',
  `numberSupplier` INT NULL COMMENT 'Address of the supplier (number)',
  `floorSupplier` INT NULL COMMENT 'Address of the supplier (floor)',
  `doorSupplier` VARCHAR(5) NULL COMMENT 'Address of the supplier (door)',
  `citySupplier` VARCHAR(45) NULL COMMENT 'Address of the supplier (city)',
  `zipSupplier` INT NULL COMMENT 'Address of the supplier (postal code)',
  `countrySupplier` VARCHAR(45) NULL COMMENT 'Address of the supplier (country)',
  `telSupplier` INT NULL COMMENT 'Telephone of the supplier',
  `faxSupplier` INT NULL COMMENT 'Fax of the supplier',
  `nifSupplier` VARCHAR(9) NULL COMMENT 'NIF of the supplier',
  PRIMARY KEY (`idSupplier`),
  UNIQUE INDEX `nameSupplier_UNIQUE` (`nameSupplier` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Brand`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Brand` (
  `idBrand` INT NOT NULL AUTO_INCREMENT,
  `nameBrand` VARCHAR(45) NULL COMMENT 'Name of the brand',
  `Supplier_idSupplier` INT NOT NULL,
  PRIMARY KEY (`idBrand`),
  INDEX `fk_Brand_Supplier1_idx` (`Supplier_idSupplier` ASC) VISIBLE,
  CONSTRAINT `fk_Brand_Supplier1`
    FOREIGN KEY (`Supplier_idSupplier`)
    REFERENCES `ej-bbdd`.`Supplier` (`idSupplier`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Glasses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Glasses` (
  `idGlasses` INT NOT NULL AUTO_INCREMENT,
  `rightGraduation` DECIMAL NOT NULL COMMENT 'Graduation of the right lense of the glasses',
  `leftGraduation` DECIMAL NOT NULL COMMENT 'Graduation of the left lense of the glasses',
  `frameGlasses` ENUM('flotant', 'pasta', 'metàl·lica') NOT NULL COMMENT 'Kind of frame. elegible from this set of values: flotant, pasta, metàl·lica',
  `frameColor` VARCHAR(45) NOT NULL COMMENT 'Color of the frame',
  `rightColor` VARCHAR(45) NOT NULL COMMENT 'Color of the right lense',
  `leftColor` VARCHAR(45) NOT NULL COMMENT 'Color of the left lense',
  `priceGlasses` DECIMAL NULL COMMENT 'Price of the glasses',
  `Brand_idBrand` INT NOT NULL,
  PRIMARY KEY (`idGlasses`),
  INDEX `fk_Glasses_Brand1_idx` (`Brand_idBrand` ASC) VISIBLE,
  CONSTRAINT `fk_Glasses_Brand1`
    FOREIGN KEY (`Brand_idBrand`)
    REFERENCES `ej-bbdd`.`Brand` (`idBrand`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Client` (
  `idClient` INT NOT NULL AUTO_INCREMENT,
  `nameClient` VARCHAR(45) NULL COMMENT 'Name of the client',
  `addressClient` VARCHAR(45) NULL COMMENT 'Address of the client',
  `telClient` INT NULL COMMENT 'Telephone of the client',
  `emailClient` VARCHAR(45) NULL COMMENT 'email of the client',
  `timestampClient` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT 'Date of registry',
  PRIMARY KEY (`idClient`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Recomendation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Recomendation` (
  `Client_idClient` INT NOT NULL,
  `Client_idClient1` INT NOT NULL,
  PRIMARY KEY (`Client_idClient`, `Client_idClient1`),
  INDEX `fk_Client_has_Client_Client2_idx` (`Client_idClient1` ASC) VISIBLE,
  INDEX `fk_Client_has_Client_Client1_idx` (`Client_idClient` ASC) VISIBLE,
  CONSTRAINT `fk_Client_has_Client_Client1`
    FOREIGN KEY (`Client_idClient`)
    REFERENCES `ej-bbdd`.`Client` (`idClient`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Client_has_Client_Client2`
    FOREIGN KEY (`Client_idClient1`)
    REFERENCES `ej-bbdd`.`Client` (`idClient`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Employee`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Employee` (
  `idEmployee` INT NOT NULL AUTO_INCREMENT,
  `nameEmployee` VARCHAR(45) NULL COMMENT 'Name of the employee',
  PRIMARY KEY (`idEmployee`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Salecheck`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Salecheck` (
  `Client_idClient` INT NOT NULL,
  `Glasses_idGlasses` INT NOT NULL,
  `Employee_idEmployee` INT NOT NULL,
  `dateSale` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Client_idClient`, `Glasses_idGlasses`, `Employee_idEmployee`),
  INDEX `fk_Client_has_Glasses_Glasses1_idx` (`Glasses_idGlasses` ASC) VISIBLE,
  INDEX `fk_Client_has_Glasses_Client1_idx` (`Client_idClient` ASC) VISIBLE,
  INDEX `fk_Client_has_Glasses_Employee1_idx` (`Employee_idEmployee` ASC) VISIBLE,
  CONSTRAINT `fk_Client_has_Glasses_Client1`
    FOREIGN KEY (`Client_idClient`)
    REFERENCES `ej-bbdd`.`Client` (`idClient`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Client_has_Glasses_Glasses1`
    FOREIGN KEY (`Glasses_idGlasses`)
    REFERENCES `ej-bbdd`.`Glasses` (`idGlasses`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Client_has_Glasses_Employee1`
    FOREIGN KEY (`Employee_idEmployee`)
    REFERENCES `ej-bbdd`.`Employee` (`idEmployee`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ej-bbdd`.`Sale_has_Book`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ej-bbdd`.`Sale_has_Book` (
  `Sale_idSale` INT NOT NULL,
  `Book_idBook` INT NOT NULL,
  `numBooks` INT NOT NULL,
  PRIMARY KEY (`Sale_idSale`, `Book_idBook`),
  INDEX `fk_Sale_has_Book_Book1_idx` (`Book_idBook` ASC) VISIBLE,
  CONSTRAINT `fk_Sale_has_Book_Sale1`
    FOREIGN KEY (`Sale_idSale`)
    REFERENCES `ej-bbdd`.`Sale` (`idSale`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Sale_has_Book_Book1`
    FOREIGN KEY (`Book_idBook`)
    REFERENCES `ej-bbdd`.`Book` (`idBook`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
