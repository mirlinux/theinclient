# Client App
장비관리 클라이언트 앱



## Overview
![1](https://user-images.githubusercontent.com/19258598/190535255-cbb8b5d7-b9fb-41d0-8843-86bdf1a11503.PNG)

## System Structure

![캡처](https://user-images.githubusercontent.com/19258598/190535375-ee671aa4-9c04-4ec7-a02c-50af661d008f.PNG)


## 실행화면 Screen Shot

### 로그인 화면
![캡처10](https://user-images.githubusercontent.com/19258598/190535927-8b133a4d-95aa-403d-a26b-fd40147057cc.PNG)

### 회원가입 화면
![캡처11](https://user-images.githubusercontent.com/19258598/190535933-1b47f3ed-78e3-4423-8471-1f89fd8ed03d.PNG)

### 메인화면
![캡처3](https://user-images.githubusercontent.com/19258598/191162835-cf8f2e63-2aeb-4c5d-9514-963ada4c861c.PNG)

## 실행 동영상
https://user-images.githubusercontent.com/19258598/191189016-f9d51c6b-a609-4ece-9898-8130ca1da9fd.mp4

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
