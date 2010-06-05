-- MySQL dump 10.11
--
-- Host: localhost    Database: dbscanalyzer_testdata
-- ------------------------------------------------------
-- Server version	5.0.51a-24+lenny3

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
-- Table structure for table `test_false`
--

DROP TABLE IF EXISTS `test_false`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
CREATE TABLE `test_false` (
  `id` int(11) NOT NULL auto_increment,
  `email` char(100) NOT NULL,
  `sex` char(100) NOT NULL,
  `city` char(100) NOT NULL,
  `first_name` char(100) NOT NULL,
  `last_name` char(100) NOT NULL,
  `address` char(100) NOT NULL,
  `website` char(100) NOT NULL,
  `phone` char(100) NOT NULL,
  `post_code` char(4) NOT NULL,
  `country` char(2) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
SET character_set_client = @saved_cs_client;

--
-- Dumping data for table `test_false`
--

LOCK TABLES `test_false` WRITE;
/*!40000 ALTER TABLE `test_false` DISABLE KEYS */;
INSERT INTO `test_false` VALUES (2,'huba[at]buba.com','X','bla','first_name','last_name','address','website','phone','post','ZZ');
/*!40000 ALTER TABLE `test_false` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `test_true`
--

DROP TABLE IF EXISTS `test_true`;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
CREATE TABLE `test_true` (
  `id` int(11) NOT NULL auto_increment,
  `email` char(100) NOT NULL,
  `sex` char(100) NOT NULL,
  `city` char(100) NOT NULL,
  `birthday` date NOT NULL,
  `first_name` char(100) NOT NULL,
  `last_name` char(100) NOT NULL,
  `address` char(100) NOT NULL,
  `website` char(100) NOT NULL,
  `phone` char(100) NOT NULL,
  `post_code` char(4) NOT NULL,
  `country` char(2) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
SET character_set_client = @saved_cs_client;

--
-- Dumping data for table `test_true`
--

LOCK TABLES `test_true` WRITE;
/*!40000 ALTER TABLE `test_true` DISABLE KEYS */;
INSERT INTO `test_true` VALUES (1,'test@gmail.ch','m','Zug','1985-05-24','Hans','Muster','Luzernerstrasse','http://startseite.ch','041 712 55 66','6300','CH'),(2,'test@gmail.ch','f','Zug','1986-04-06','Hans','Muster','Baarerstrasse','http://google.ch','041 748 56 65','6300','CH');
/*!40000 ALTER TABLE `test_true` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2010-06-02  6:00:21
