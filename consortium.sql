-- Create database
CREATE DATABASE IF NOT EXISTS consortium;
USE consortium;

-- Table: user
CREATE TABLE user (
    id INT AUTO_INCREMENT PRIMARY KEY,
    email VARCHAR(255) NOT NULL,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    role ENUM('admin', 'usuario') NOT NULL,
    password VARCHAR(255) NOT NULL,
    phone VARCHAR(20),
    active boolean NOT NULL default true
);

-- Table: consortium
CREATE TABLE consortium (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    address VARCHAR(255),
    active boolean NOT NULL default true
);

-- Table: functional_unit
CREATE TABLE functional_unit (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    balance DECIMAL(12, 2) NOT NULL,
    factor DECIMAL(5, 2) NOT NULL,
    consortium_id INT NOT NULL,
    FOREIGN KEY (consortium_id) REFERENCES consortium(id),
    active boolean NOT NULL default true
);

-- Table: user_unit
CREATE TABLE user_unit (
    user_id INT NOT NULL,
    functional_unit_id INT NOT NULL,
    PRIMARY KEY (user_id, functional_unit_id),
    FOREIGN KEY (user_id) REFERENCES user(id),
    FOREIGN KEY (functional_unit_id) REFERENCES functional_unit(id),
    active boolean NOT NULL default true
);

-- Table: supplier
CREATE TABLE supplier (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    phone VARCHAR(20),
    email VARCHAR(255),
    active boolean NOT NULL default true
);

-- Table: concept
CREATE TABLE concept (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    active boolean NOT NULL default true
);

-- Table: movement
CREATE TABLE movement (
    id INT AUTO_INCREMENT PRIMARY KEY,
    date DATETIME NOT NULL,
    amount DECIMAL(12, 2) NOT NULL,
    type ENUM('ingreso', 'egreso') NOT NULL,
    receipt VARCHAR(255),
    consortium_id INT NOT NULL,
    supplier_id INT,
    concept_id INT NOT NULL,
    functional_unit_id INT NOT NULL,
    FOREIGN KEY (consortium_id) REFERENCES consortium(id),
    FOREIGN KEY (supplier_id) REFERENCES supplier(id),
    FOREIGN KEY (concept_id) REFERENCES concept(id),
    FOREIGN KEY (functional_unit_id) REFERENCES functional_unit(id),
    active boolean NOT NULL default true
);
