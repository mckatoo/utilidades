CREATE TABLE IF NOT EXISTS `utilidades`.`users_type` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `type` VARCHAR(45) NOT NULL,
  `level` INT NOT NULL COMMENT 'Quanto menor o nível mais acesso tem.',
  `description` VARCHAR(255) NOT NULL,
  `created_at` TIMESTAMP NULL DEFAULT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;