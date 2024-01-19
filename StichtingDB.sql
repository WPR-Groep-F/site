-- Gebruiker tabel
CREATE TABLE GEBRUIKER (
    g_id INT PRIMARY KEY IDENTITY(1,1),
    voornaam VARCHAR(255) NOT NULL,
    achternaam VARCHAR(255) NOT NULL,
    emailAdres VARCHAR(255) UNIQUE NOT NULL,
    telNr VARCHAR(20) NOT NULL,
    adres VARCHAR(255) NOT NULL
);

-- Bedrijf Portaal tabel
CREATE TABLE BEDRIJF_PORTAAL (
    bedrijf_naam VARCHAR(255) PRIMARY KEY,
    bedrijf_adres VARCHAR(255) NOT NULL,
    bedrijf_informatie VARCHAR(1000) NOT NULL,
    g_id INT REFERENCES GEBRUIKER(g_id) ON DELETE CASCADE
);

-- Onderzoek tabel
CREATE TABLE ONDERZOEK (
    onderzoek_id INT PRIMARY KEY IDENTITY(1,1),
    titel VARCHAR(255) NOT NULL,
    beschrijving TEXT NOT NULL,
    datum_geplaatst DATE NOT NULL,
    IsGekeurd BIT NOT NULL,
    bedrijf_naam VARCHAR(255) REFERENCES BEDRIJF_PORTAAL(bedrijf_naam) ON DELETE CASCADE
);

-- Website Onderzoek tabel (Extend Onderzoek)
CREATE TABLE WEBSITE_ONDERZOEK (
    onderzoek_id INT PRIMARY KEY,
    url VARCHAR(255) NOT NULL,
    FOREIGN KEY (onderzoek_id) REFERENCES ONDERZOEK(onderzoek_id) ON DELETE CASCADE
);

-- Tracking tabel (Extend Website Onderzoek)
CREATE TABLE TRACKING (
    onderzoek_id INT PRIMARY KEY,
    s_id INT,
    script TEXT,
    uitslag TEXT,
    FOREIGN KEY (onderzoek_id) REFERENCES WEBSITE_ONDERZOEK(onderzoek_id) ON DELETE CASCADE
);

-- Uitnodiging tabel (Extend Onderzoek)
CREATE TABLE UITNODIGING (
    onderzoek_id INT PRIMARY KEY,
    adres_locatie VARCHAR(255) NOT NULL,
    datum DATE NOT NULL,
    tijd TIME NOT NULL,
    route_beschrijving TEXT,
    FOREIGN KEY (onderzoek_id) REFERENCES ONDERZOEK(onderzoek_id) ON DELETE CASCADE
);

-- Vragenlijst tabel (Extend Onderzoek)
CREATE TABLE VRAGENLIJST (
    onderzoek_id INT PRIMARY KEY,
    FOREIGN KEY (onderzoek_id) REFERENCES ONDERZOEK(onderzoek_id) ON DELETE CASCADE
);

-- Vraag tabel (Extend Vragenlijst)
CREATE TABLE VRAAG (
    vraag_id INT PRIMARY KEY IDENTITY(1,1),
    titel VARCHAR(255) NOT NULL,
    type VARCHAR(50) NOT NULL,
    beschrijving TEXT,
    antwoord TEXT,
    vragenlijst_id INT REFERENCES VRAGENLIJST(onderzoek_id) ON DELETE CASCADE
);

-- Plaats tabel (Tussentabel tussen Bedrijf Portaal en Onderzoek)
CREATE TABLE PLAATS (
    plaats_id INT PRIMARY KEY IDENTITY(1,1),
    onderzoek_id INT,
    vergoeding_type VARCHAR(50) NOT NULL,
    vergoeding_waarde DECIMAL(10,2) NOT NULL,
    vergoeding_beschrijving TEXT,
    FOREIGN KEY (onderzoek_id) REFERENCES ONDERZOEK(onderzoek_id) ON DELETE CASCADE
);

-- Postcode tabel (Gelinkt met Plaats met een M:N relatie)
CREATE TABLE POSTCODE (
    postcode_id INT PRIMARY KEY IDENTITY(1,1),
    postcode_group VARCHAR(10) NOT NULL,
    plaats_id INT REFERENCES PLAATS(plaats_id) ON DELETE CASCADE
);

-- Leeftijd tabel (Gelinkt met Plaats met een M:N relatie)
CREATE TABLE LEEFTIJD (
    leeftijd_id INT PRIMARY KEY IDENTITY(1,1),
    leeftijd_group VARCHAR(10) NOT NULL,
    plaats_id INT REFERENCES PLAATS(plaats_id) ON DELETE CASCADE
);

-- Beperking tabel (Gelinkt met Ervaringsdeskundige met een M:N relatie)
CREATE TABLE BEPERKING (
    beperking_id INT PRIMARY KEY IDENTITY(1,1),
    type VARCHAR(50) NOT NULL,
    omschrijving TEXT,
    plaats_id INT,
    FOREIGN KEY (plaats_id) REFERENCES PLAATS(plaats_id) ON DELETE CASCADE
);

-- Hulpmiddel tabel (Gelinkt met Beperking met een M:N relatie)
CREATE TABLE HULPMIDDEL (
    h_id INT PRIMARY KEY IDENTITY(1,1),
    naam VARCHAR(255) NOT NULL,
    omschrijving TEXT,
    beperking_id INT REFERENCES BEPERKING(beperking_id) ON DELETE CASCADE
);

-- Ervaringsdeskundige tabel (gelinkt met Gebruiker)
CREATE TABLE ERVARINGSDESKUNDIG (
    g_id INT PRIMARY KEY,
    onderzoek_id INT REFERENCES ONDERZOEK(onderzoek_id) ON DELETE CASCADE,
    voorkeurDeelname TEXT,
    benaderingOpties TEXT,
    adres VARCHAR(255) NOT NULL,
    FOREIGN KEY (g_id) REFERENCES GEBRUIKER(g_id) ON DELETE NO ACTION
);

-- Voogd tabel (Gelinkt met Ervaringsdeskundige met een M:N relatie)
CREATE TABLE VOOGD (
    voogd_id INT PRIMARY KEY IDENTITY(1,1),
    naam VARCHAR(255) NOT NULL,
    telNR VARCHAR(20) NOT NULL,
    emailAdres VARCHAR(255) NOT NULL,
    ervaringsdeskundige_id INT REFERENCES ERVARINGSDESKUNDIG(g_id) ON DELETE CASCADE
);