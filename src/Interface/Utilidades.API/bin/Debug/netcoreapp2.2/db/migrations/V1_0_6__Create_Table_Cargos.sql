CREATE TABLE IF NOT EXISTS `utilidades`.`cargos` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `cargo` VARCHAR(45) NOT NULL,
    `setores_id` INT NOT NULL,
    `created_at` TIMESTAMP NULL DEFAULT NULL,
    `updated_at` TIMESTAMP NULL DEFAULT NULL,
    PRIMARY KEY (`id`),
    INDEX `fk_cargos_setores1_idx` (`setores_id` ASC),
    CONSTRAINT `fk_cargos_setores1` FOREIGN KEY (`setores_id`) REFERENCES `utilidades`.`setores` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE = InnoDB;