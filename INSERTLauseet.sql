INSERT INTO Kirjailija (kirtunnus, enimi, snimi) VALUES 
    ("KTSEBM01", "Henning", "Mankell"), 
    ("KTFIBH01", "Simo", "Hämäläinen"), 
    ("KTFICA01", "Kati", "Aksila-Konnos"),
    ("KTFICK01", "Reetta", "Koivisto"), 
    ("KTGBAT01", "J.R.R.", "Tolkien"), 
    ("KTUSBH01", "Thomas", "Harris"), 
    ("KTUSBR01", "Anne", "Rice"), 
    ("KTGBBC01", "Arthur", "Clarke"), 
    ("KTUSBM01", "Thomas", "Madden"), 
    ("KTFIBN01", "Miika", "Nousiainen"), 
    ("KTXXXXXX", "Tuntematon", "Kirjailija"), 
    ("KTCNXT01", "Sun", "Tzu"), 
    ("KTUSBG01", "Tess", "Gerritsen"), 
    ("KTUSBK01", "Stephen", "King"), 
    ("KTGBCR01", "J.K.", "Rowling"), 
    ("KTITAA01", "Marcus", "Aurelius");


INSERT INTO Kirja (isbn, kirtu, nimi, genre, julkaistu, kustantaja, sivut, img, kuvaus) VALUES 
    ("9789512080618", "KTFIBH01", "Kätkäläisen tarina", "huumori", 2009, "Gummerus", 557, "KätkäläisenTarina.png", "KätkäläisenTarina.txt"), 
    ("9789512080619", "KTGBAT01", "Taru sormusten herrasta", "fantasia", 1954, "WSOY", 1221, "TaruSormustenHerrasta.png", "TaruSormustenHerrasta.txt"), 
    ("9789512080625", "KTGBBC01", "Avaruusseikkailu", "tiede", 2015, "Trevi", 320, "Avaruusseikkailu.png", "Avaruusseikkailu.txt"), 
    ("9789526938127", "KTFICA01", "Kaverusten lorukirja", "lastenkirjallisuus", 2021, "KirpunKoti", 26, "KaverustenLorukirja.png", "KaverustenLorukirja.txt"), 
    ("9789526938110", "KTFICK01", "Kaverusten tunnekirja", "lastenkirjallisuus", 2021, "KirpunKoti", 64, "KaverustenTunnekirja.png", "KaverustenTunnekirja.txt"), 
    ("9789516439900", "KTSEBM01", "Pyramidi", "rikokset", 2002, "Otava", 400, "Pyramidi.png", "Pyramidi.txt"), 
    ("9789511205999", "KTSEBM01", "Daisy Sisters", "aikakausiromaani", 2006, "Otava", 651, "DaisySisters.png", "DaisySisters.txt"), 
    ("9789511214700", "KTSEBM01", "Kadonneiden miesten metsä", "aikakausiromaani", 2007, "Otava", 157, "KadonneidenMiestenMetsä.png", "KadonneidenMiestenMetsä.txt"), 
    ("9789511231776", "KTSEBM01", "Panokset", "Yhteiskunta", 2009, "Otava", 271, "Panokset.png", "Panokset.txt"), 
    ("9789512080627", "KTUSBM01", "Historian käännekohtia", "Historia", 2005, "ei tiedossa", 400, "ImageNotFound.png", "ImageNotFound.txt"), 
    ("9780385339483", "KTUSBH01", "Hannibal", "Kauhu", 2000, "Gummerus", 547, "Hannibal.png", "Hannibal.txt"), 
    ("9789511127338", "KTUSBR01", "Vampyyri Lestat", "Kauhu", 1993, "Forum", 572, "VampyyriLestat.png", "VampyyriLestat.txt"), 
    ("9789516629561", "KTCNXT01", "Sodankäynnin taito", "psykologia", 2005, "Basam Books", 148, "ArtOfWar.png", "ArtOfWar.txt"), 
    ("9789511225959", "KTUSBG01", "Luutarha", "rikokset", 2008, "Otava", 383, "Luutarha.png", "Luutarha.txt"), 
    ("9789501243745", "KTUSBK01", "Uinu, uinu, lemmikkini", "kauhu", 1983, "Bra Böcker", 416, "UinuUinuLemmikkini.png", "UinuUinuLemmikkini.txt"), 
    ("9789512080611", "KTXXXXXX", "Kätkäläisen tarinat jatkuvat", "huumori", 2010, "Gummerus", 439, "ImageNotFound.png", "KätkäläisenTarinatJatkuvat.txt"), 
    ("9789511354031", "KTFIBN01", "Pintaremontti", "huumori", 2020, "Otava", 365, "Pintaremontti.png", "Pintaremontti.txt"), 
    ("9513135071111", "KTGBCR01", "Harry Potter ja puoliverinen prinssi", "Fantasia", 2006, "Tammi", 698, "HarryPotterJaPuoliverinenPrinssi.png", "HarryPotterJaPuoliverinenPrinssi.txt"), 
    ("9780340608456", "KTUSBK01", "Uneton yö", "kauhu", 1997, "Bra Böcker", 912, "UnetonYö.png", "UnetonYö.txt"), 
    ("9780141395869", "KTITAA01", "Meditaatiot", "filosofia", 2014, "Basam Books", 416, "Meditaatiot.png", "Meditaatiot.txt"), 
    ("9789520426392", "KTGBCR01", "Harry Potter ja Viisasten Kivi", "fantasia", 1998, "Tammi", 335, "HarryPotterjaViisastenKivi.png", "HarryPotterjaViisastenKivi.txt");


INSERT INTO Asiakas (asnum, enimi, snimi, loso, pno, ptp, puh, kayttajatunnus, salasana, salt) VALUES 
    ("TTXXXXX", "XXX", "XXX", "XXX", "XXXXX", "XXX", "XXX", "XXXX", "XXXX", "NoSalt"),
    ("AS00123", "Olli", "Lainaaja", "Kotikatu 1 A2", "65100", "Vaasa", "040 123 4567", "Olli_L", "Salasana1234", "noSalt"), 
    ("AS00223", "Maija", "Mehiläinen", "Katunumero 1 A3", "00100", "Helsinki", "0401122334", "Maija_M", "Salasana1234", "noSalt"), 
    ("AS00323", "Matti", "Meikäläinen", "Katunumero 4 A5", "00370", "Espoo", "040 112 2555", "Matti_M", "Salasana1234", "noSalt"), 
    ("AS00124", "Leena", "Luonto", "Rantatie 1 A6", "04130", "Sipoo", "040 044 5678", "Leena_L", "Salasana1234", "noSalt"), 
    ("AS00224", "Teppo", "Tietäjä", "Majakatu 3 C4", "33100", "Tampere", "050 112 2334", "Teppo_T", "Salasana1234", "noSalt"), 
    ("AS00324", "Milla", "Magia", "Katutie 3 B5", "00100", "Helsinki", "0407654321", "Milla_M", "Salasana1234", "noSalt"), 
    ("AS00424", "Oliver", "Oraakkeli", "Tontuntie 2 G5", "90100", "Oulu", "0409876543", "Oliver_O", "Salasana1234", "noSalt"), 

    ("AS00524", "Ville", "Vallaton", "Lauritsalantie 20 D15", "53300", "Lappeenranta",  
    "0459846227", "Ville_V", "Salasana1234", "noSalt"), 

    ("AS00624", "Oskari", "Ohjelmistola", "Ohjelmointikatu 10", "13100", "Hämeenlinna", "0500123456", "Oskari_O", "Salasana1234", "noSalt"), 

    ("AS00724", "Tauno", "Tavallinen", "Oksasenkatu 4 A8", "53100", "Lappeenranta", "0442456378", "Tauno_T", "Salasana1234", "noSalt");


INSERT INTO henkilokunta (tyonum, enimi, snimi, tyonim, ptp, puh, kayttajatunnus, salasana, salt) VALUES
    ("TTXXXX", "XXX", "XXX", "XXX", "XXX", "XXX", "XXXX", "XXXX", "noSalt"),
    ("TT0501", "Akseli", "Muhonen", "Ohjelmistokehittäjä", "Lappeenranta", "044 983 7575", "Akseli_M", "Työntekijä0501!", "noSalt"),
    ("TT0101", "Ossi", "Omistaja", "Omistaja", "Helsinki", "050 151 2367", "Omistaja", "Omistaja24", "noSalt"),
    ("TT1001", "Silja", "Silkki", "Kirjastotyöntekijä", "Vaasa", "045 236 7348", "Silja_S", "Työntekijä1001!", "noSalt");


INSERT INTO Lainaus (lainanum, astun, tyonum, pvm) VALUES 
    ("2401001", "AS00123", "TTXXXX", "2024-01-24 06:00:00"), 
    ("2401002", "AS00223", "TTXXXX", "2024-01-25 10:30:15"), 
    ("2401003", "AS00323", "TTXXXX", "2024-01-26 15:45:23"), 
    ("2401004", "AS00124", "TTXXXX", "2024-01-31 18:00:00"), 
    ("2401005", "AS00224", "TTXXXX", "2024-01-31 20:15:42"), 
    ("2401006", "AS00324", "TTXXXX", "2024-01-24 22:30:01"), 
    ("2401007", "AS00424", "TTXXXX", "2024-01-24 08:15:37"), 
    ("2401008", "AS00524", "TTXXXX", "2024-01-27 12:00:00"), 
    ("2401009", "AS00524", "TTXXXX", "2024-01-30 17:45:19"), 
    ("2401010", "AS00624", "TTXXXX", "2024-01-31 23:59:59"), 
    ("2402001", "AS00724", "TTXXXX", "2024-02-10 07:00:00"), 
    ("2402002", "AS00724", "TTXXXX", "2024-02-12 13:30:47"), 
    ("2402003", "AS00724", "TTXXXX", "2024-02-21 19:00:00"), 
    ("2403001", "AS00724", "TTXXXX", "2024-03-02 09:15:22"),
    ("2404001", "TTXXXXX", "TT0501", "2024-04-12 13:30:47"), 
    ("2404002", "TTXXXXX", "TT0501", "2024-04-15 19:00:00"), 
    ("2404003", "TTXXXXX", "TT0501", "2024-04-16 09:15:22"),
    ("2404004", "TTXXXXX", "TT0501", "2024-04-12 13:30:47"), 
    ("2404005", "TTXXXXX", "TT0501", "2024-04-15 19:00:00"), 
    ("2404006", "TTXXXXX", "TT0501", "2024-04-16 09:15:22");


INSERT INTO Lainakohde (tunnus, ktun, tila) VALUES 
    ("019789512080618", "9789512080618", "lainattu"), 
    ("029789512080619", "9789512080619", "lainattu"), 
    ("019789512080619", "9789512080619", "lainattavissa"), 
    ("029789526938127", "9789526938127", "lainattu"), 
    ("029789526938110", "9789526938110", "lainattu"), 
    ("019780385339483", "9780385339483", "lainattu"), 
    ("019789511127338", "9789511127338", "lainattu"), 
    ("019789516629561", "9789516629561", "lainattu"), 
    ("029789516629561", "9789516629561", "lainattu"), 
    ("019789501243745", "9789501243745", "lainattu"), 
    ("019789512080611", "9789512080611", "lainattu"), 
    ("019789511225959", "9789511225959", "lainattu"), 
    ("019513135071111", "9513135071111", "lainattavissa"), 
    ("019780340608456", "9780340608456", "lainattu"), 
    ("029780340608456", "9780340608456", "lainattu"), 
    ("039780340608456", "9780340608456", "lainattu"), 
    ("019780141395869", "9780141395869", "lainattu"), 
    ("019789520426392", "9789520426392", "lainattu"),
    ("019789511205999", "9789511205999", "lainattavissa"), 
    ("029789511205999", "9789511205999", "lainattavissa"), 
    ("019789511214700", "9789511214700", "lainattavissa"), 
    ("019789511231776", "9789511231776", "lainattavissa");


INSERT INTO Lainarivi (rivinum, ltunnus, kohdetun) VALUES 
    ("240100101", "2401001", "019789512080618"), 
    ("240100201", "2401002", "029789512080619"), 
    ("240100301", "2401003", "019789501243745"), 
    ("240100401", "2401004", "029789526938110"), 
    ("240100501", "2401005", "019789511225959"), 
    ("240100601", "2401006", "019780385339483"), 
    ("240100701", "2401007", "019789511127338"),     
    ("240100801", "2401008", "019789516629561"), 
    ("240100802", "2401008", "019789512080611"), 
    ("240100901", "2401009", "029789526938127"), 
    ("240101001", "2401010", "029789516629561"), 
    ("240101002", "2401010", "029780340608456"), 
    ("240200101", "2402001", "019780340608456"), 
    ("240200201", "2402002", "019780141395869"), 
    ("240200301", "2402003", "019789520426392"), 
    ("240300101", "2403001", "039780340608456");


SELECT * FROM asiakas;