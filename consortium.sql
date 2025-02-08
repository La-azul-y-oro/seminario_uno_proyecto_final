-- Create database
CREATE DATABASE IF NOT EXISTS consortium;
USE consortium;

-- Table: user
CREATE TABLE user (
    id INT AUTO_INCREMENT PRIMARY KEY,
    document_type ENUM('cuil', 'cuit', 'dni') NOT NULL,
    document_number BIGINT NOT NULL,
    email VARCHAR(255) NOT NULL,
    role ENUM('admin', 'usuario') NOT NULL,
    password VARCHAR(255) NOT NULL,
    phone VARCHAR(20),
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    active BOOLEAN NOT NULL DEFAULT TRUE
);

-- Table: consortium
CREATE TABLE consortium (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    address VARCHAR(255) NOT NULL,
    active BOOLEAN NOT NULL DEFAULT TRUE
);

-- Table: functional_unit
CREATE TABLE functional_unit (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    balance DECIMAL(12, 2) NOT NULL,
    factor DECIMAL(5, 2) NOT NULL,
    consortium_id INT NOT NULL,
    active BOOLEAN NOT NULL DEFAULT TRUE,
    FOREIGN KEY (consortium_id) REFERENCES consortium(id),
    CONSTRAINT unit_consortium UNIQUE (name, consortium_id)
);

-- Table: user_unit
CREATE TABLE user_unit (
    user_id INT NOT NULL,
    functional_unit_id INT NOT NULL,
    PRIMARY KEY (user_id, functional_unit_id),
    FOREIGN KEY (user_id) REFERENCES user(id),
    FOREIGN KEY (functional_unit_id) REFERENCES functional_unit(id),
    active BOOLEAN NOT NULL DEFAULT TRUE
);

-- Table: supplier
CREATE TABLE supplier (
    cuit BIGINT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    phone VARCHAR(20) NOT NULL,
    email VARCHAR(255) NOT NULL,
    active BOOLEAN NOT NULL DEFAULT TRUE
);

-- Table: concept
CREATE TABLE concept (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    active BOOLEAN NOT NULL DEFAULT TRUE
);

-- Table: movement
CREATE TABLE movement (
    id INT AUTO_INCREMENT PRIMARY KEY,
    date DATETIME NOT NULL,
    amount DECIMAL(12, 2) NOT NULL,
    type ENUM('ingreso', 'egreso') NOT NULL,
    receipt VARCHAR(255),
    consortium_id INT NOT NULL,
    supplier_cuit BIGINT NOT NULL,
    concept_id INT NOT NULL,
    functional_unit_id INT NOT NULL,
    FOREIGN KEY (consortium_id) REFERENCES consortium(id),
    FOREIGN KEY (supplier_cuit) REFERENCES supplier(cuit),
    FOREIGN KEY (concept_id) REFERENCES concept(id),
    FOREIGN KEY (functional_unit_id) REFERENCES functional_unit(id),
    active BOOLEAN NOT NULL DEFAULT TRUE
);

DELIMITER //

-- Trigger to validate document_number in user (before insert)
CREATE TRIGGER check_doc_number_before_insert 
BEFORE INSERT ON user 
FOR EACH ROW 
BEGIN
    IF (NEW.document_type = 'dni' AND (NEW.document_number < 10000000 OR NEW.document_number > 99999999)) THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'DNI number must contain 8 digits';
    END IF;
    
    IF (NEW.document_type IN ('cuil', 'cuit') AND (NEW.document_number < 10000000000 OR NEW.document_number > 99999999999)) THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'CUIL/CUIT number must contain 8 digits';
    END IF;
END;
//

-- Trigger to validate document_number in user (before update)
CREATE TRIGGER check_doc_number_before_update 
BEFORE UPDATE ON user 
FOR EACH ROW 
BEGIN
    IF (NEW.document_type = 'dni' AND (NEW.document_number < 10000000 OR NEW.document_number > 99999999)) THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'DNI number must contain 8 digits';
    END IF;
    
    IF (NEW.document_type IN ('cuil', 'cuit') AND (NEW.document_number < 10000000000 OR NEW.document_number > 99999999999)) THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'CUIL/CUIT number must contain 8 digits';
    END IF;
END;

-- Trigger to validate cuit in supplier (before insert)
CREATE TRIGGER check_cuit_before_insert 
BEFORE INSERT ON supplier 
FOR EACH ROW 
BEGIN
    IF NEW.cuit < 10000000000 OR NEW.cuit > 99999999999 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'CUIT must contain 11 digits';
    END IF;
END;
//

-- Trigger to validate cuit in supplier (before update)
CREATE TRIGGER check_cuit_before_update 
BEFORE UPDATE ON supplier 
FOR EACH ROW 
BEGIN
    IF NEW.cuit < 10000000000 OR NEW.cuit > 99999999999 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'CUIT must contain 11 digits';
    END IF;
END;
//

DELIMITER ;
