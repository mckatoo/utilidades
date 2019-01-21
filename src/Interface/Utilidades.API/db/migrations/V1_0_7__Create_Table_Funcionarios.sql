CREATE TABLE IF NOT EXISTS `utilidades`.`funcionarios` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `nome` VARCHAR(45) NOT NULL,
    `funcional` VARCHAR(45) NOT NULL,
    `rg` VARCHAR(45) NOT NULL,
    `cargos_id` INT NOT NULL,
    `file_photo` VARCHAR(255) NULL,
    `created_at` TIMESTAMP NULL DEFAULT NULL,
    `updated_at` TIMESTAMP NULL DEFAULT NULL,
    PRIMARY KEY (`id`),
    INDEX `fk_funcionarios_cargos1_idx` (`cargos_id` ASC),
    CONSTRAINT `fk_funcionarios_cargos1` FOREIGN KEY (`cargos_id`) REFERENCES `utilidades`.`cargos` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;