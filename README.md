# theinclient
장비관리 클라이언트 앱

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
### machineTable
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