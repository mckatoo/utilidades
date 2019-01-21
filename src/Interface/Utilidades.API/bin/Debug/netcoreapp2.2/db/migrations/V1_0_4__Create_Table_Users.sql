CREATE TABLE IF NOT EXISTS `utilidades`.`users` (
  `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) CHARACTER SET 'utf8mb4' NOT NULL,
  `email` VARCHAR(255) CHARACTER SET 'utf8mb4' NOT NULL,
  `username` VARCHAR(255) CHARACTER SET 'utf8mb4' NOT NULL,
  `password` VARCHAR(255) CHARACTER SET 'utf8mb4' NOT NULL,
  `remember_token` VARCHAR(100) CHARACTER SET 'utf8mb4' NULL DEFAULT NULL,
  `created_at` TIMESTAMP NULL DEFAULT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL,
  `users_type_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `users_email_unique` (`email` ASC),
  INDEX `fk_users_users_type1_idx` (`users_type_id` ASC),
  CONSTRAINT `fk_users_users_type1`
    FOREIGN KEY (`users_type_id`)
    REFERENCES `utilidades`.`users_type` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;