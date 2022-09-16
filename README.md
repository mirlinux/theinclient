# theinclient
장비관리 클라이언트 앱



## Overview
![1](https://user-images.githubusercontent.com/19258598/190535255-cbb8b5d7-b9fb-41d0-8843-86bdf1a11503.PNG)

## System Structure

![캡처](https://user-images.githubusercontent.com/19258598/190535375-ee671aa4-9c04-4ec7-a02c-50af661d008f.PNG)

## Database Table Schema
### Member Table
```
CREATE TABLE `thein`.`member` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `userid` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NULL,
  `name` VARCHAR(45) NULL,
  `ip` VARCHAR(45) NULL,
  PRIMARY KEY (`id`));
```
### machine Table
```
CREATE TABLE `thein`.`machine` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `ip` VARCHAR(45) NULL,
  PRIMARY KEY (`id`));
```
### log Table
```
CREATE TABLE `thein`.`log` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `time` DATETIME NULL,
  `machine_id` INT NULL,
  `ip` VARCHAR(45) NULL,
  `cpu` DOUBLE NULL,
  `mem` INT NULL,
  `mem_usage` DOUBLE NULL,
  PRIMARY KEY (`id`));
```
