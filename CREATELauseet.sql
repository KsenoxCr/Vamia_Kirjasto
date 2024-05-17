DROP TABLE IF EXISTS asiakas, henkilokunta, kirja, kirjailija, lainakohde, lainarivi, lainaus, ehdotukset, Tiketit, palautteet;

CREATE TABLE Asiakas( 
   asnum CHAR(7), 
   enimi VARCHAR(15), 
   snimi VARCHAR(30), 
   loso VARCHAR(45), 
   pno CHAR(5), 
   ptp VARCHAR(30), 
   puh VARCHAR(20), 
   kayttajatunnus VARCHAR(20),
   salasana VARCHAR(128),
   salt VARCHAR(128),
   PRIMARY KEY (asnum))
; 

CREATE TABLE henkilokunta(
   tyonum CHAR(6),
   enimi VARCHAR(15), 
   snimi VARCHAR(30), 
   tyonim VARCHAR(30), 
   ptp VARCHAR(30), 
   puh VARCHAR(20), 
   kayttajatunnus VARCHAR(20), 
   salasana VARCHAR(128), 
   salt VARCHAR(128), 
   PRIMARY KEY (tyonum))
;

CREATE TABLE Kirjailija( 
   kirtunnus CHAR(8), 
   enimi VARCHAR(15), 
   snimi VARCHAR(30), 
   PRIMARY KEY (kirtunnus))
; 

CREATE TABLE Kirja( 
   isbn CHAR(13), 
   kirtu CHAR(8),
   nimi VARCHAR(55), 
   genre VARCHAR(30),
   julkaistu INTEGER, 
   kustantaja VARCHAR(30),
   sivut INTEGER,
   img VARCHAR(55),
   kuvaus VARCHAR(55),
   PRIMARY KEY (isbn), 
   FOREIGN KEY (kirtu) 
   REFERENCES Kirjailija(kirtunnus))
; 

CREATE TABLE Lainakohde( 
   tunnus CHAR(15), 
   ktun CHAR(13), 
   tila VARCHAR(13),
   PRIMARY KEY (tunnus), 
   FOREIGN KEY (ktun) REFERENCES Kirja(isbn))
; 

CREATE TABLE Lainaus(
   lainanum CHAR(7),
   astun CHAR(7),
   tyonum CHAR(6),
   pvm TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
   PRIMARY KEY (lainanum),
   FOREIGN KEY (astun)
   REFERENCES Asiakas(asnum),
   FOREIGN KEY (tyonum)
   REFERENCES henkilokunta(tyonum))  
; 

CREATE TABLE Lainarivi(
   rivinum CHAR (9),
   ltunnus CHAR(7),
   kohdetun CHAR(15),
   PRIMARY KEY (rivinum),
   FOREIGN KEY (ltunnus) 
   REFERENCES Lainaus(lainanum),
   FOREIGN KEY (kohdetun)
   REFERENCES Lainakohde(tunnus)); 

CREATE TABLE Palautteet(
   id INTEGER AUTO_INCREMENT, 
   astun CHAR(7),
   aihe VARCHAR(30),
   sisalto VARCHAR(250),
   pvm TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
   PRIMARY KEY (id),
   FOREIGN KEY (astun)
   REFERENCES Asiakas(asnum)
);

CREATE TABLE Tiketit(
   id INTEGER AUTO_INCREMENT, 
   astun CHAR(7),
   aihe VARCHAR(30),
   sisalto VARCHAR(250),
   pvm TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
   tila VARCHAR(30) DEFAULT "Ratkaisematta",
   PRIMARY KEY (id),
   FOREIGN KEY (astun)
   REFERENCES Asiakas(asnum)
);

CREATE TABLE Ehdotukset(
   id INTEGER AUTO_INCREMENT,
   astun CHAR(7),
   ehdotus VARCHAR(50),
   pvm TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
   PRIMARY KEY (id),
   FOREIGN KEY (astun)
   REFERENCES Asiakas(asnum)
);