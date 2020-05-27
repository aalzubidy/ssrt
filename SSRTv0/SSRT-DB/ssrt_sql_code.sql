-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema SSRT
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema SSRT
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `SSRT` DEFAULT CHARACTER SET utf8 ;
USE `SSRT` ;

-- -----------------------------------------------------
-- Table `SSRT`.`User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `User` (
  `userName` VARCHAR(100) NOT NULL,
  `userEmail` VARCHAR(100) NOT NULL,
  `userPassword` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`userEmail`),
  UNIQUE INDEX `user_email_UNIQUE` (`userEmail` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SSRT`.`Query`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Query` (
  `queryId` INT NOT NULL AUTO_INCREMENT,
  `queryQuery` VARCHAR(500) NOT NULL,
  `queryDB` VARCHAR(45) NOT NULL,
  `queryUser` VARCHAR(100) NOT NULL,
  `queryDownload` INT NOT NULL,
  `queryDate` VARCHAR(45) NOT NULL,
  `queryTotalResults` VARCHAR(45) NULL,
  `queryurl` TEXT NULL,
  PRIMARY KEY (`queryId`),
  UNIQUE INDEX `query_id_UNIQUE` (`queryId` ASC),
  INDEX `query_user_user_idx` (`queryUser` ASC),
  CONSTRAINT `queryUserUser`
    FOREIGN KEY (`queryUser`)
    REFERENCES `User` (`userEmail`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SSRT`.`QueryConverter`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `QueryConverter` (
  `qcId` INT NOT NULL AUTO_INCREMENT,
  `qcInputQuery` VARCHAR(500) NOT NULL,
  `qcOutputQuery` TEXT NULL,
  `qcUser` VARCHAR(100) NULL,
  `qcDate` VARCHAR(45) NULL,
  PRIMARY KEY (`qcId`),
  UNIQUE INDEX `qcId_UNIQUE` (`qcId` ASC),
  INDEX `qcUserUser_idx` (`qcUser` ASC),
  CONSTRAINT `qcUserUser`
    FOREIGN KEY (`qcUser`)
    REFERENCES `User` (`userEmail`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SSRT`.`Publication`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Publication` (
  `publicationID` INT NOT NULL AUTO_INCREMENT,
  `publicationQueryID` INT NULL,
  `type` VARCHAR(100) NULL,
  `author` VARCHAR(100) NULL,
  `editor` VARCHAR(100) NULL,
  `title` VARCHAR(100) NULL,
  `booktitle` VARCHAR(100) NULL,
  `year` VARCHAR(45) NULL,
  `publisher` VARCHAR(100) NULL,
  `address` TEXT NULL,
  `pages` VARCHAR(45) NULL,
  `isbn` VARCHAR(45) NULL,
  `doi` VARCHAR(45) NULL,
  `url` VARCHAR(100) NULL,
  `journal` VARCHAR(100) NULL,
  `volume` VARCHAR(100) NULL,
  `abstract` TEXT NULL,
  `issn` VARCHAR(45) NULL,
  `location` VARCHAR(100) NULL,
  `keywords` VARCHAR(100) NULL,
  `month` VARCHAR(45) NULL,
  PRIMARY KEY (`publicationID`),
  UNIQUE INDEX `publicationID_UNIQUE` (`publicationID` ASC),
  INDEX `PublicationQueryID_idx` (`publicationQueryID` ASC),
  CONSTRAINT `PublicationQueryID`
    FOREIGN KEY (`publicationQueryID`)
    REFERENCES `Query` (`queryId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
