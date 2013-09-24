delimiter $$

CREATE TABLE articulo (
  id int(11) primary key NOT NULL AUTO_INCREMENT,
  nombre varchar(45)  NOT NULL,
  categoria int(11), 
  precio decimal(10,2)  
)


CREATE TABLE categoria (
  id int(11) primary key NOT NULL AUTO_INCREMENT,
  nombre varchar(45)  NOT NULL
 
)
