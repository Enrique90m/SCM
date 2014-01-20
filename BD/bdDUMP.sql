CREATE DATABASE  IF NOT EXISTS `bd` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `bd`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: bd
-- ------------------------------------------------------
-- Server version	5.6.14

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `equipos`
--

DROP TABLE IF EXISTS `equipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `equipos` (
  `NumEquipo` varchar(10) NOT NULL,
  `Marca` varchar(20) DEFAULT NULL,
  `NumSerie` varchar(45) DEFAULT NULL,
  `Sala` varchar(3) DEFAULT NULL,
  `Estado` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`NumEquipo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipos`
--

LOCK TABLES `equipos` WRITE;
/*!40000 ALTER TABLE `equipos` DISABLE KEYS */;
INSERT INTO `equipos` VALUES ('11F','DELL','098764','C','Habilitado'),('11U','TOSHIBA','23782378','U','Habilitado'),('12E','COMPACT','4328489','E','Habilitado'),('12F','TOSHIBA','372646','E','Desabilitado'),('14A','COMPACT','764672367','A',NULL),('15F','ASUS','12367123671367','F',NULL),('15U','COMPACT','636','33','Habilitado'),('16R','DELL','09876','C','Habilitado'),('17V','TOSHIBA','65562922','V',NULL),('18I','TOHSIBA','387278237','TT','Habilitado'),('19M','TOSHIBA','63276234','P',NULL),('19T','COMPACT','782378237','T','Habilitado'),('20M','TOSHIBA','3272378387','M','Habilitado'),('2A','TOSHIBA','4234789','A',NULL),('34R','COMPACT','327726732','R','Habilitado'),('3E','E-MACHINES','234778','E',NULL),('46U','COMPACT','765444666','U','Habilitado'),('56','COMPACT','2349234','E',NULL),('56E','TOSHIBA','5634523456','E','Habilitado'),('56T','TOSHIBA','3246246','T',NULL),('5B','TOSHIBA','123456','B',NULL),('5G','COMPACT','47278922','G',NULL),('6b','TOSHIBA','123456','B',NULL),('78R','COMPACT','832328','R','Desabilitado'),('7B','TOSHIBA','123456','B',NULL),('7P','ASUS','234254356','P',NULL),('8B','TOSHIBA','123456','B',NULL),('8R','ACER','5234562365','R',NULL),('90I','TOSHIBA','782378378','F','Habilitado'),('9C','DELL','09876','C',NULL),('9D','COMPACT','6423647','D',NULL),('F8','HP','24378536','F',NULL);
/*!40000 ALTER TABLE `equipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fallas`
--

DROP TABLE IF EXISTS `fallas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fallas` (
  `idFalla` int(11) NOT NULL,
  `NumComputadora` varchar(45) DEFAULT NULL,
  `DescripcionFalla` varchar(150) DEFAULT NULL,
  `FechaAlta` date DEFAULT NULL,
  `FechaBaja` date DEFAULT NULL,
  `Solucionada` varchar(2) DEFAULT NULL,
  `Categoria` varchar(20) DEFAULT NULL,
  `Eliminada` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`idFalla`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fallas`
--

LOCK TABLES `fallas` WRITE;
/*!40000 ALTER TABLE `fallas` DISABLE KEYS */;
INSERT INTO `fallas` VALUES (1,'12','NORMAL','2013-11-28',NULL,'No','Software','No'),(2,'12','ELIMINADA','2013-11-28',NULL,'No','Software','No'),(3,'12','SOLUCIONADA','2013-11-28','2013-11-28','Si','Hardware','No'),(4,'12','ELIMINADA Y SOLUCIONADA','2013-11-28','2013-11-28','Si','Hardware','Si'),(5,'2A','PROBLEMAS CON MEMORA ROM','2013-12-02',NULL,'No','Hardware','No'),(6,'9C','FALLA RAM','2013-12-02',NULL,'No','Hardware','No'),(7,'10C','FALLA SISTEMA OPERATIVO','2013-12-02',NULL,'No','Software','No'),(8,'11C','FALLA FUENTE DE PODER','2013-12-02',NULL,'No','Hardware','No'),(9,'11C','FALLA PANTALLA','2013-12-02',NULL,'No','Hardware','No'),(10,'6B','NO TIENE MOUSE','2013-12-02',NULL,'No','Hardware','No'),(11,'7B','FALTA DE HERRAMIENTAS','2013-12-02',NULL,'No','Software','Si'),(12,'11F','PROBLEMAS CON MONITOR','2013-12-02','2013-12-05','Si','Hardware','No'),(13,'11e','PROBLEMA CON DISCO DURO','2013-12-03','2013-12-03','Si','Hardware','No'),(14,'11U','PROBLEMA CON MONITOR','2013-12-05',NULL,'No','Hardware','No'),(15,'11F','PROBLEMA CON TECLADO','2013-12-05','2013-12-05','Si','Hardware','No'),(16,'12F','ERROR PANTALLA AZUL','2013-12-05',NULL,'No','Software','No'),(17,'12F','PROBLEMAS MOUSE','2013-12-05',NULL,'No','Hardware','Si'),(18,'16R','16R ','2013-12-05',NULL,'No','Hardware','Si'),(19,'16R','ERROR DE WINDOWS','2013-12-05',NULL,'No','Hardware','Si'),(20,'12f','problema monitor','2013-12-08','2013-12-08','Si','Hardware','No'),(21,'12f','problema teclado','2013-12-08',NULL,'No','Hardware','No'),(22,'12f','problema 1','2013-12-08','2013-12-08','Si','Hardware','No'),(23,'12f','problema 2','2013-12-08','2013-12-08','Si','Hardware','No'),(24,'12f','problema 1','2013-12-08','2013-12-08','Si','Hardware','No'),(25,'12f','problema 1','2013-12-08','2013-12-08','Si','Hardware','No'),(26,'12f','prob 1','2013-12-08','2013-12-08','Si','Hardware','No'),(27,'12f','prob sol','2013-12-08',NULL,'No','Hardware','Si'),(28,'12f','prob sol','2013-12-08','2013-12-08','Si','Hardware','No'),(29,'12f','error de windows 8','2013-12-10','2013-12-12','No','Hardware','Si'),(30,'12f','PROBLEMA CON MOUSE5','2013-12-11','2013-12-11','No','Hardware','Si'),(31,'19T','PROBLEMA CON PANTALLA','2013-12-11','2013-12-12','No','Hardware','Si'),(32,'20M','PROBLEMA CON MEMORIA RAM','2013-12-12',NULL,'Si','Hardware','No'),(33,'34R','NO ENCIENDE MONITOR','2013-12-12',NULL,'Si','Hardware','No'),(34,'46U','FALLA MEMORIA  RAM','2013-12-12','2013-12-12','Si','Hardware','No');
/*!40000 ALTER TABLE `fallas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'bd'
--
/*!50003 DROP PROCEDURE IF EXISTS `BuscaFallaEntreFechas` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `BuscaFallaEntreFechas`(in fech1 date, in fech2 date, in bandera varchar(10))
begin
	CASE 
	WHEN bandera = '0' THEN Select * From fallas Where Eliminada = 'No' AND Solucionada = 'No' AND FechaAlta between(fech1) and (fech2);
	WHEN bandera = '1' THEN Select * From fallas Where Solucionada = 'No' AND FechaAlta between(fech1) and (fech2);
	WHEN bandera = '2' THEN Select * From fallas Where Eliminada = 'No' AND FechaAlta between(fech1) and (fech2);
	else
	Select * From fallas WHERE FechaAlta ;
    END CASE;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `BuscaFallaPorNumComp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `BuscaFallaPorNumComp`(in numcomp varchar(10), in bandera varchar(10))
begin

	CASE 
		WHEN bandera = '0' THEN SELECT * FROM fallas WHERE NumComputadora = numcomp AND Eliminada = 'No' AND Solucionada = 'No' AND FechaAlta between(fech1) and (fech2);
		WHEN bandera = '1' THEN SELECT * FROM fallas WHERE NumComputadora = numcomp AND Solucionada = 'No' AND FechaAlta between(fech1) and (fech2);
		WHEN bandera = '2' THEN SELECT * FROM fallas WHERE NumComputadora = numcomp AND Eliminada = 'No' AND FechaAlta between(fech1) and (fech2);
		else
		SELECT * FROM FALLAS WHERE NumComputadora = numcomp;
    END CASE;

end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SeleccionarTodos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SeleccionarTodos`()
begin
SELECT * FROM fallas where Eliminada = 'No';
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-01-17 19:20:58
