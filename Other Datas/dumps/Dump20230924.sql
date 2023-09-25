-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: started
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `heroes`
--

DROP TABLE IF EXISTS `heroes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `heroes` (
  `hero_id` int NOT NULL,
  `hero_name` varchar(255) DEFAULT NULL,
  `iscomplete` tinyint DEFAULT NULL,
  `hero_address` varchar(255) DEFAULT NULL,
  `hero_secret` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`hero_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `heroes`
--

LOCK TABLES `heroes` WRITE;
/*!40000 ALTER TABLE `heroes` DISABLE KEYS */;
INSERT INTO `heroes` VALUES (1,'moe',1,'string','string');
/*!40000 ALTER TABLE `heroes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_admin`
--

DROP TABLE IF EXISTS `tbl_admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_admin` (
  `admin_id` int NOT NULL AUTO_INCREMENT,
  `admin_name` varchar(50) DEFAULT NULL,
  `admin_email` varchar(100) DEFAULT NULL,
  `login_name` varchar(50) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `inactive` tinyint DEFAULT NULL,
  `customer_level_id` int DEFAULT NULL,
  `AdminPhoto` varchar(100) DEFAULT NULL,
  `salt` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`admin_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_admin`
--

LOCK TABLES `tbl_admin` WRITE;
/*!40000 ALTER TABLE `tbl_admin` DISABLE KEYS */;
INSERT INTO `tbl_admin` VALUES (1,'nyein','chann@gmail.com','moe','oooooo',1,321,'5f454161-4855-439a-8d09-02c650b11733.jpg',NULL),(2,'nyein','chann@gmail.com','moe','qqqqqq',1,234,'5f454161-4855-439a-8d09-02c650b11733.jpg',NULL),(3,'Oohe','oohe@gmail.com','OoOo','oooooo',1,90,'JgKlhHup60LECgXrGS/PO5PBtTukgS8RIIl7orqUCrTFfZH5VMpxArR5HFIf3ed5/vvIq7ndgsirqEMnA7KCdw==',NULL),(4,'PoPo','popo@gmail.com','PoLay','popopo',0,45,'4zyHYX9rrCkxhlFWuW3eazwuTTwvdcXKh1rB5cPVuak=',NULL),(5,'nyeinchann','nyeinchann2001moe@gmail.com','nyeinchann','nyeinchann',1,33,'admin.png','moe'),(6,'moemoe','moemoe@gmail.com','moemoe','Gl+4UgG7c6LL2HgNkLMbrR/MW+5NsSjr',0,1,'','pKCg58++8Ksd6zJP/SLcF/LFqJKOjcpm'),(7,'nyeinchan','nyeinchann2001moe@gmail.com','channmoe','UDvCQtrUtsHKUcLDqpOWCtJhqHV0fhc7',0,1,'','gzmuDYPEKPH6usGebUmq3nZKOYKCTkOA'),(8,'OoOoOo','nyeinchann2001moe@gmail.com','OoOoOo','385WNmInn/AGtB6QJIcWxYmEYLxaNyHG',0,1,'','layKiyLREjBGbzYvlwLQPiP03u6csarm'),(9,'moemoe','nyeinchann2001moe@gmail.com','moemoe','5lw45wFaHpf2CGmdFSn9tIJkpjFfgN/C',0,1,'','uptnwCxRi6pTBBQlSMflHjiSVAVM7TKs');
/*!40000 ALTER TABLE `tbl_admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_admin5`
--

DROP TABLE IF EXISTS `tbl_admin5`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_admin5` (
  `admin_id` int NOT NULL AUTO_INCREMENT,
  `admin_name` varchar(50) DEFAULT NULL,
  `admin_email` varchar(100) DEFAULT NULL,
  `login_name` varchar(50) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `salt` varchar(45) DEFAULT NULL,
  `inactive` tinyint DEFAULT NULL,
  `admin_level_id` int DEFAULT NULL,
  `AdminPhoto` varchar(225) DEFAULT NULL,
  PRIMARY KEY (`admin_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_admin5`
--

LOCK TABLES `tbl_admin5` WRITE;
/*!40000 ALTER TABLE `tbl_admin5` DISABLE KEYS */;
INSERT INTO `tbl_admin5` VALUES (1,'nyein','nyein@gamil.com','nyein','nyein',NULL,0,11,'fdc0e93b-ee55-4b11-8cae-60bf9e3f6cbe.jpg'),(2,'nyein','nyein@gamil.com','nyein','nyein',NULL,1,11,'fdc0e93b-ee55-4b11-8cae-60bf9e3f6cbe.jpg'),(3,'nyein','nyein@gamil.com','nyein','nyein',NULL,1,121,'fdc0e93b-ee55-4b11-8cae-60bf9e3f6cbe.jpg'),(4,'channmoe','channmoe@gmail.com','channmoe','moemoe',NULL,0,123,'fdc0e93b-ee55-4b11-8cae-60bf9e3f6cbe.jpg'),(5,'nyein','nyein@gmail.com','nyein','nyein','moe',1,11,'fdc0e93b-ee55-4b11-8cae-60bf9e3f6cbe.jpg'),(6,'nyeinchannmoe','nyeinchann2001moe@gamil.com','nyeinchannmoe','JuUy70DIkPJhtqOMi8tAmxtQ1cJFFyli','13ajRA2QS7q5Tyft9xE9DrF/BluQqdfk',0,8,'87c00f2c-918a-49cb-a922-355af3517be9.jpg');
/*!40000 ALTER TABLE `tbl_admin5` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_adminlevel`
--

DROP TABLE IF EXISTS `tbl_adminlevel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_adminlevel` (
  `adminlevel_id` int NOT NULL,
  `adminlevel_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`adminlevel_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_adminlevel`
--

LOCK TABLES `tbl_adminlevel` WRITE;
/*!40000 ALTER TABLE `tbl_adminlevel` DISABLE KEYS */;
INSERT INTO `tbl_adminlevel` VALUES (45,'eleven'),(90,'Ten'),(234,'four'),(321,'three');
/*!40000 ALTER TABLE `tbl_adminlevel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_adminlevel5`
--

DROP TABLE IF EXISTS `tbl_adminlevel5`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_adminlevel5` (
  `adminlevel_id` int NOT NULL,
  `adminlevel_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`adminlevel_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_adminlevel5`
--

LOCK TABLES `tbl_adminlevel5` WRITE;
/*!40000 ALTER TABLE `tbl_adminlevel5` DISABLE KEYS */;
INSERT INTO `tbl_adminlevel5` VALUES (11,'admin'),(121,'admin');
/*!40000 ALTER TABLE `tbl_adminlevel5` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_customer`
--

DROP TABLE IF EXISTS `tbl_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_customer` (
  `customer_id` int NOT NULL AUTO_INCREMENT,
  `customer_name` varchar(50) DEFAULT NULL,
  `customer_address` varchar(100) DEFAULT NULL,
  `customer_type_id` int DEFAULT NULL,
  `CustomerPhoto` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1037 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_customer`
--

LOCK TABLES `tbl_customer` WRITE;
/*!40000 ALTER TABLE `tbl_customer` DISABLE KEYS */;
INSERT INTO `tbl_customer` VALUES (3,'Test Customer','Test Address',NULL,''),(18,'Thiri','Magway',NULL,''),(90,'Thiri','Magway',NULL,''),(101,'sweetheart','heart',NULL,''),(115,'orgd','orjmg',119,'0dd5932d-211b-4123-af5f-d1256bd1b4a1.jpg'),(122,'moee','tororr',88,'b59d11cb-3be6-49a0-8d42-245c1566e181.jpg'),(221,'gkfd','pgkhf',232,'5f454161-4855-439a-8d09-02c650b11733.jpg'),(227,'ofkf','lgjf',421,'5f454161-4855-439a-8d09-02c650b11733.jpg'),(453,'mmm','oiaa',846,'b59d11cb-3be6-49a0-8d42-245c1566e181.jpg'),(743,'lodhf','yura',314,'0dd5932d-211b-4123-af5f-d1256bd1b4a1.jpg'),(1001,'ldoda','dfgds',1002,NULL),(1002,'string','string',1003,'string'),(1003,'odiajd','kdhf',555,'b59d11cb-3be6-49a0-8d42-245c1566e181.jpg'),(1004,'odiajd','kdhf',455,'faaca88c-10d4-4034-8c89-a68ebc552a70.jpg'),(1005,'odiajd','kdhf',845,'faaca88c-10d4-4034-8c89-a68ebc552a70.png'),(1006,'poadr','lojfa',123,'b59d11cb-3be6-49a0-8d42-245c1566e181.png'),(1009,'ofjr','lajd',173,'5f454161-4855-439a-8d09-02c650b11733.jpg'),(1011,'ofjr','lajd',133,'a95f1d76-e580-46ac-9b16-103485e0e49d'),(1012,'ofjr','lajd',233,'nyein'),(1013,'oridf','lgjaf',23,'pwint-tun.jpg'),(1014,'string','string',1006,'string'),(1015,'moee','luaw',43,'KPxzy2KcBtA2GS7M80T+cLtULdx2Oh4lsIMAZcbhfT0='),(1016,'moemoe','orjff',NULL,''),(1017,'Nyein','Yangon',NULL,''),(1018,'photo','customer',92,'AoFL5IY95UgyT3Pk5Bpm/dxLJ8J7+UDZnk4jbXlCb7oBKHhUJ4gkZoamU9IKIaypTwT2rIBToJkQq9Gc3UEBcg=='),(1019,'sweetheart','haehea',NULL,''),(1020,'haehae','sweetheart',NULL,''),(1021,'Kyaw','Yangon',NULL,''),(1022,'Aye','Mandalay And Yangon',NULL,''),(1023,'Kyaw Kyaw','Yangon',NULL,''),(1025,'Bo Bo','United States',NULL,''),(1026,'Yadanar','ShweBo',NULL,''),(1028,'Yadanar','ShweBo',NULL,''),(1029,'Ei Ei','ShweBo',NULL,''),(1030,'Yadanar','ShweBo',NULL,''),(1031,'Test Customer','Test Address',NULL,''),(1032,'Test Customer','Test Address',NULL,''),(1033,'Test Customer','Test Address',NULL,''),(1035,'Yadanar','ShweBo',NULL,''),(1036,'Yadanar','ShweBo',NULL,'');
/*!40000 ALTER TABLE `tbl_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_customer5`
--

DROP TABLE IF EXISTS `tbl_customer5`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_customer5` (
  `customer_id` int NOT NULL AUTO_INCREMENT,
  `customer_name` varchar(50) DEFAULT NULL,
  `customer_address` varchar(100) DEFAULT NULL,
  `customer_type_id` int DEFAULT NULL,
  `CustomerPhoto` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_customer5`
--

LOCK TABLES `tbl_customer5` WRITE;
/*!40000 ALTER TABLE `tbl_customer5` DISABLE KEYS */;
INSERT INTO `tbl_customer5` VALUES (1,'mmmmm','ppppp',111,'7b62c73b-59b1-45e7-a570-f60ed46f23e0.jpg'),(2,'ooooo','ooooo',11,'de62f5c5-486b-4eb3-88c8-3467e7033170.jpg'),(3,'naing','string',23,'nyein'),(4,'moe','oj;fr',1,'h/bJhbohBVh4PDupIF/2u6OK4OYDnJO6z1MEGcLDid88gRpaueMwmlNfPwGD9y68OJ3iKJb+KRB3/eoBIuZCZg==');
/*!40000 ALTER TABLE `tbl_customer5` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_customertype`
--

DROP TABLE IF EXISTS `tbl_customertype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_customertype` (
  `custype_id` int NOT NULL AUTO_INCREMENT,
  `custype_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`custype_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1007 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_customertype`
--

LOCK TABLES `tbl_customertype` WRITE;
/*!40000 ALTER TABLE `tbl_customertype` DISABLE KEYS */;
INSERT INTO `tbl_customertype` VALUES (23,'lgadf'),(43,'lyoo'),(88,'mmdm'),(92,'pho'),(98,'mmdm'),(110,'kgjfkr'),(115,'pogjf'),(119,'kgjfkr'),(123,'udr'),(133,'pfasd'),(173,'pfasd'),(231,'lgjfa'),(232,'ojflg'),(233,'pfasd'),(314,'pofae'),(421,'pforjf'),(455,'odpajd'),(555,'odpajd'),(845,'odpajd'),(846,'poasw'),(1002,'ifofjjjja'),(1003,'string'),(1004,'string'),(1005,'string'),(1006,'string');
/*!40000 ALTER TABLE `tbl_customertype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_customertype5`
--

DROP TABLE IF EXISTS `tbl_customertype5`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_customertype5` (
  `custype_id` int NOT NULL,
  `custype_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`custype_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_customertype5`
--

LOCK TABLES `tbl_customertype5` WRITE;
/*!40000 ALTER TABLE `tbl_customertype5` DISABLE KEYS */;
INSERT INTO `tbl_customertype5` VALUES (1,'poekf'),(11,'cute'),(23,'lollol'),(111,'cute');
/*!40000 ALTER TABLE `tbl_customertype5` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_department`
--

DROP TABLE IF EXISTS `tbl_department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_department` (
  `dept_id` int NOT NULL,
  `dept_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`dept_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_department`
--

LOCK TABLES `tbl_department` WRITE;
/*!40000 ALTER TABLE `tbl_department` DISABLE KEYS */;
INSERT INTO `tbl_department` VALUES (33,'fldjfffjdufhyfklsdnfjgdf'),(64,'juk juk'),(90,'soft'),(100,'prom prom'),(2003,'sweet'),(3333,'ueurur');
/*!40000 ALTER TABLE `tbl_department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_department5`
--

DROP TABLE IF EXISTS `tbl_department5`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_department5` (
  `dept_id` int NOT NULL,
  `dept_name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`dept_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_department5`
--

LOCK TABLES `tbl_department5` WRITE;
/*!40000 ALTER TABLE `tbl_department5` DISABLE KEYS */;
INSERT INTO `tbl_department5` VALUES (111,'software');
/*!40000 ALTER TABLE `tbl_department5` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_employee`
--

DROP TABLE IF EXISTS `tbl_employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_employee` (
  `employee_id` int NOT NULL AUTO_INCREMENT,
  `employee_name` varchar(50) DEFAULT NULL,
  `employee_address` varchar(10) DEFAULT NULL,
  `employee_department_id` int DEFAULT NULL,
  PRIMARY KEY (`employee_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2223 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_employee`
--

LOCK TABLES `tbl_employee` WRITE;
/*!40000 ALTER TABLE `tbl_employee` DISABLE KEYS */;
INSERT INTO `tbl_employee` VALUES (10,'kyaw','orrpfd',90),(45,'moe nyein','string',64),(50,'kyaw kyaw','string',100),(77,'sflhfdshfsdf','string',33);
/*!40000 ALTER TABLE `tbl_employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_employee5`
--

DROP TABLE IF EXISTS `tbl_employee5`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_employee5` (
  `employee_id` int NOT NULL AUTO_INCREMENT,
  `employee_name` varchar(50) DEFAULT NULL,
  `employee_address` varchar(100) DEFAULT NULL,
  `employee_department_id` int DEFAULT NULL,
  PRIMARY KEY (`employee_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_employee5`
--

LOCK TABLES `tbl_employee5` WRITE;
/*!40000 ALTER TABLE `tbl_employee5` DISABLE KEYS */;
INSERT INTO `tbl_employee5` VALUES (1,'moeoe','string',111);
/*!40000 ALTER TABLE `tbl_employee5` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_eventlog`
--

DROP TABLE IF EXISTS `tbl_eventlog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_eventlog` (
  `ID` bigint NOT NULL AUTO_INCREMENT,
  `LogType` int NOT NULL,
  `LogDateTime` datetime NOT NULL,
  `Source` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `FormName` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `LogMessage` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `ErrMessage` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `UserID` int NOT NULL,
  `UserType` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `ipAddress` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_eventlog`
--

LOCK TABLES `tbl_eventlog` WRITE;
/*!40000 ALTER TABLE `tbl_eventlog` DISABLE KEYS */;
INSERT INTO `tbl_eventlog` VALUES (6,5,'2023-03-16 20:53:43','api','AdminController.PostAdmin ','Updated :\r\n','',6,'web','::1'),(7,4,'2023-03-16 20:53:43','api','AdminController.PostAdmin ','Created :\r\nAdminId : 8\r\nAdminName : OoOoOo\r\nAdminEmail : nyeinchann2001moe@gmail.com\r\nLoginName : OoOoOo\r\nPassword : 385WNmInn/AGtB6QJIcWxYmEYLxaNyHG\r\nSalt : layKiyLREjBGbzYvlwLQPiP03u6csarm\r\nInactive : False\r\nAdminLevelId : 1\r\nAdminLevel : \r\nAdminPhoto : \r\n','',6,'web','::1'),(8,3,'2023-03-16 20:56:04','api','ForgotPasswordController.ChangePasswordByOTP ','Change Password Fail: Password must be longer than 8 characters.','',0,'public','::1'),(9,3,'2023-03-16 20:56:50','api','ForgotPasswordController.ChangePasswordByOTP ','Change Password Fail: Password must include at least one numeric character.','',0,'public','::1'),(10,2,'2023-03-16 20:57:13','api','ForgotPasswordController.ChangePasswordByOTP ','Change Password Fail','\'TodoApi.Models.OTP\' does not contain a definition for \'SetEventLogMessage\'',0,'public','::1'),(11,5,'2023-03-16 20:59:19','api','AdminController.PostAdmin ','Updated :\r\n','',6,'web','::1'),(12,4,'2023-03-16 20:59:19','api','AdminController.PostAdmin ','Created :\r\nAdminId : 9\r\nAdminName : moemoe\r\nAdminEmail : nyeinchann2001moe@gmail.com\r\nLoginName : moemoe\r\nPassword : 5lw45wFaHpf2CGmdFSn9tIJkpjFfgN/C\r\nSalt : uptnwCxRi6pTBBQlSMflHjiSVAVM7TKs\r\nInactive : False\r\nAdminLevelId : 1\r\nAdminLevel : \r\nAdminPhoto : \r\n','',6,'web','::1'),(13,5,'2023-04-03 20:24:26','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 101 >>> 101\r\nCustomerAddress : orjmg >>> moenyein\r\nCustomerName : orgd >>> moemoe\r\nCustomerPhoto : dfaee1ee-fe5e-4beb-851e-cd6ca6e7568d.jpg >>> \r\nCustomerTypeId : 110 >>> \r\n','',6,'web','192.168.100.21'),(14,5,'2023-04-03 20:58:49','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 101 >>> 101\r\nCustomerAddress : moenyein >>> sweet\r\n','',6,'web','192.168.100.21'),(15,5,'2023-04-03 21:04:46','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 110 >>> 110\r\nCustomerAddress : lgjf >>> moemoe\r\nCustomerName : ogjkf >>> moenyein\r\nCustomerPhoto : cJEVBVHdZc7Cy5r9M/MBOoyU6jc7ZP47R3w4DwAH9BqioDocUM1g3fM/CJdCKy1iGAdCz2B29iWaIUExQZZQVg== >>> \r\nCustomerTypeId : 115 >>> \r\n','',6,'web','192.168.100.21'),(16,5,'2023-04-03 21:07:50','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 110 >>> 110\r\n','',6,'web','192.168.100.21'),(17,5,'2023-04-03 21:15:11','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 110 >>> 110\r\n','',6,'web','192.168.100.21'),(18,5,'2023-04-03 21:16:57','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 110 >>> 110\r\n','',6,'web','192.168.100.21'),(19,5,'2023-04-03 21:23:41','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 101 >>> 101\r\nCustomerName : moemoe >>> sweet\r\n','',6,'web','192.168.100.21'),(20,5,'2023-04-03 21:24:19','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 110 >>> 110\r\n','',6,'web','192.168.100.21'),(21,5,'2023-04-03 21:24:43','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 101 >>> 101\r\nCustomerAddress : sweet >>> sweetheart\r\nCustomerName : sweet >>> sweetheart\r\n','',6,'web','192.168.100.21'),(22,5,'2023-04-10 08:59:20','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1022 >>> 1022\r\nCustomerAddress : Yangon >>> Mandalay\r\n','',6,'web','192.168.100.21'),(23,5,'2023-04-10 09:01:10','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1022 >>> 1022\r\n','',6,'web','192.168.100.21'),(24,5,'2023-04-10 16:31:14','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1024 >>> 1024\r\nCustomerAddress : Magway >>> Yangon\r\n','',6,'web','192.168.100.21'),(25,5,'2023-04-10 16:31:14','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1024 >>> 1024\r\nCustomerAddress : Magway >>> Yangon\r\n','',6,'web','192.168.100.21'),(26,5,'2023-04-10 16:31:34','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1024 >>> 1024\r\n','',6,'web','192.168.100.21'),(27,5,'2023-04-10 16:53:20','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1024 >>> 1024\r\nCustomerAddress : Yangon >>> Magway\r\n','',6,'web','192.168.100.21'),(28,5,'2023-04-10 16:57:14','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1024 >>> 1024\r\nCustomerAddress : Magway >>> Yangon\r\n','',6,'web','192.168.100.21'),(29,5,'2023-04-10 16:57:14','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1024 >>> 1024\r\nCustomerAddress : Magway >>> Yangon\r\n','',6,'web','192.168.100.21'),(30,5,'2023-04-10 16:59:08','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1024 >>> 1024\r\n','',6,'web','192.168.100.21'),(31,5,'2023-04-10 16:59:08','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1024 >>> 1024\r\n','',6,'web','192.168.100.21'),(32,5,'2023-04-10 17:03:14','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 101 >>> 101\r\nCustomerAddress : sweetheart >>> heart\r\n','',6,'web','192.168.100.21'),(33,5,'2023-04-10 17:07:28','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1024 >>> 1024\r\nCustomerAddress : Yangon >>> Magway\r\n','',6,'web','192.168.100.21'),(34,5,'2023-04-10 17:07:57','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1022 >>> 1022\r\nCustomerAddress : Mandalay >>> Mandalay And Yangon\r\n','',6,'web','192.168.100.21'),(35,5,'2023-04-10 17:12:28','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1022 >>> 1022\r\n','',6,'web','192.168.100.21'),(36,5,'2023-04-11 19:35:34','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1 >>> 1\r\nCustomerAddress : Test Address >>> Updated Address\r\nCustomerName : Test Customer >>> Updated Customer\r\n','',6,'web','192.168.100.21'),(37,5,'2023-04-11 20:48:37','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1025 >>> 1025\r\nCustomerName : BOO BOo >>> Bo Bo\r\n','',6,'web','192.168.100.21'),(38,5,'2023-04-11 21:06:39','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1 >>> 1\r\n','',6,'web','192.168.100.21'),(39,5,'2023-04-11 21:06:39','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1 >>> 1\r\nCustomerAddress : Test Address >>> Updated Address\r\nCustomerName : Test Customer >>> Updated Customer\r\n','',6,'web','192.168.100.21'),(40,5,'2023-04-11 21:20:13','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1029 >>> 1029\r\nCustomerName : Aye Aye >>> Aye Aye Aung\r\n','',6,'web','192.168.100.21'),(41,5,'2023-04-12 07:49:08','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1029 >>> 1029\r\nCustomerName : Aye Aye Aung >>> Ei Ei\r\n','',6,'web','192.168.100.21'),(42,5,'2023-04-12 07:55:21','api','CustomerController.UpdateCustomer ','Updated :\r\nCustomerId : 1029 >>> 1029\r\nCustomerAddress : Magway >>> ShweBo\r\n','',6,'web','192.168.100.21');
/*!40000 ALTER TABLE `tbl_eventlog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_eventlog5`
--

DROP TABLE IF EXISTS `tbl_eventlog5`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_eventlog5` (
  `ID` bigint NOT NULL AUTO_INCREMENT,
  `LogType` int NOT NULL,
  `LogDateTime` datetime NOT NULL,
  `Source` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `FormName` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `LogMessage` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `ErrMessage` text CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `UserID` int NOT NULL,
  `UserType` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `ipAddress` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_eventlog5`
--

LOCK TABLES `tbl_eventlog5` WRITE;
/*!40000 ALTER TABLE `tbl_eventlog5` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_eventlog5` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_ge_otp`
--

DROP TABLE IF EXISTS `tbl_ge_otp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_ge_otp` (
  `otpid` bigint NOT NULL AUTO_INCREMENT,
  `emailphone` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '959xxxxxxxxx,xxxxx@gmail.com',
  `loginname` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `passcode` varchar(20) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL COMMENT 'G-xxxxxx',
  `ipaddress` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `otptoken` varchar(20) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `senddatetime` datetime NOT NULL,
  `failcount` int NOT NULL DEFAULT '0',
  `retrycount` int NOT NULL DEFAULT '0',
  `lastmodifieddate` datetime NOT NULL,
  `createddate` datetime NOT NULL,
  PRIMARY KEY (`otpid`),
  UNIQUE KEY `phone_uniquekey` (`emailphone`,`loginname`),
  KEY `phone_index` (`emailphone`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_ge_otp`
--

LOCK TABLES `tbl_ge_otp` WRITE;
/*!40000 ALTER TABLE `tbl_ge_otp` DISABLE KEYS */;
INSERT INTO `tbl_ge_otp` VALUES (2,'nyeinchann2001moe@gmail.com','channmoe','N-344965','::1','otptoken','2023-03-16 14:00:05',0,1,'2023-03-16 14:00:05','2023-03-16 14:00:05'),(3,'nyeinchann2001moe@gmail.com','nyeinchann','M-201896','::1','otptoken','2023-03-16 20:25:09',0,1,'2023-03-16 20:25:09','2023-03-16 20:25:09'),(4,'nyeinchann2001moe@gmail.com','OoOoOo','D-952353','::1','otptoken','2023-03-16 20:54:12',0,0,'2023-03-16 20:57:13','2023-03-16 20:54:12');
/*!40000 ALTER TABLE `tbl_ge_otp` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbl_ge_otp5`
--

DROP TABLE IF EXISTS `tbl_ge_otp5`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tbl_ge_otp5` (
  `otpid` bigint NOT NULL AUTO_INCREMENT,
  `emailphone` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '959xxxxxxxxx,xxxxx@gmail.com',
  `loginname` varchar(100) CHARACTER SET utf8 COLLATE utf8_unicode_ci DEFAULT NULL,
  `passcode` varchar(20) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL COMMENT 'G-xxxxxx',
  `ipaddress` varchar(50) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `otptoken` varchar(20) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `senddatetime` datetime NOT NULL,
  `failcount` int NOT NULL DEFAULT '0',
  `retrycount` int NOT NULL DEFAULT '0',
  `lastmodifieddate` datetime NOT NULL,
  `createddate` datetime NOT NULL,
  PRIMARY KEY (`otpid`),
  UNIQUE KEY `phone_uniquekey` (`emailphone`,`loginname`),
  KEY `phone_index` (`emailphone`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbl_ge_otp5`
--

LOCK TABLES `tbl_ge_otp5` WRITE;
/*!40000 ALTER TABLE `tbl_ge_otp5` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbl_ge_otp5` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `todoitems`
--

DROP TABLE IF EXISTS `todoitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `todoitems` (
  `todoitem_id` int NOT NULL,
  `todoitem_name` varchar(30) DEFAULT NULL,
  `todoapi_address` varchar(45) DEFAULT NULL,
  `iscomplete` tinyint DEFAULT NULL,
  `todoitem_secrect` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`todoitem_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `todoitems`
--

LOCK TABLES `todoitems` WRITE;
/*!40000 ALTER TABLE `todoitems` DISABLE KEYS */;
/*!40000 ALTER TABLE `todoitems` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-09-24 19:11:40
