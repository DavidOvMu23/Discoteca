CREATE DATABASE IF NOT EXISTS biblioteca_vinilos;
USE biblioteca_vinilos;

CREATE TABLE ARTISTAS (
    id_artista INT AUTO_INCREMENT PRIMARY KEY,
    nombre_artista VARCHAR(100) NOT NULL,
    nacionalidad VARCHAR(50)
);

CREATE TABLE GENEROS (
    id_genero INT AUTO_INCREMENT PRIMARY KEY,
    nombre_genero VARCHAR(50) NOT NULL
);

CREATE TABLE USUARIOS (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE,
    telefono VARCHAR(20),
    fecha_registro DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE VINILOS (
    id_vinilo INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(150) NOT NULL,
    anio_lanzamiento INT,
    estado VARCHAR(50) DEFAULT 'Bueno',
    id_artista INT,
    id_genero INT,
    -- Relaciones (Llaves Foráneas)
    FOREIGN KEY (id_artista) REFERENCES ARTISTAS(id_artista),
    FOREIGN KEY (id_genero) REFERENCES GENEROS(id_genero)
);


CREATE TABLE ALQUILERES (
    id_alquiler INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT NOT NULL,
    id_vinilo INT NOT NULL,
    fecha_salida DATE NOT NULL,
    fecha_entrega_prevista DATE NOT NULL,
    fecha_devolucion_real DATE, 
    FOREIGN KEY (id_usuario) REFERENCES USUARIOS(id_usuario),
    FOREIGN KEY (id_vinilo) REFERENCES VINILOS(id_vinilo)
);