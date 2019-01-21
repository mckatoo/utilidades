CREATE TABLE IF NOT EXISTS `utilidades`.`autorizacoes` (
  `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `aluno` VARCHAR(255) CHARACTER SET 'utf8mb4' NOT NULL,
  `ra` VARCHAR(255) CHARACTER SET 'utf8mb4' NOT NULL,
  `data` TIMESTAMP NOT NULL,
  `validade` TIMESTAMP NOT NULL,
  `created_at` TIMESTAMP NULL DEFAULT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL,
  `cursos_id` INT NOT NULL,
  `qrcode` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_autorizacoes_cursos_idx` (`cursos_id` ASC),
  CONSTRAINT `fk_autorizacoes_cursos`
    FOREIGN KEY (`cursos_id`)
    REFERENCES `utilidades`.`cursos` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;