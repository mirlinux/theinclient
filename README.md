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