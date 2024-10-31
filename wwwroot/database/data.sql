INSERT INTO public."Bolnica"("Naziv", "Adresa", "Budzet") VALUES('Ortopedska bolnica Banjica', 'Mihaila Avramovica 28, Beograd', 3000000000.00);
INSERT INTO public."Bolnica"("Naziv", "Adresa", "Budzet") VALUES('Institut za zastitu majke i deteta', 'Radoja Dakica 6-8, Beograd', 10000000000.00);
INSERT INTO public."Bolnica"("Naziv", "Adresa", "Budzet") VALUES('Klinicki centar Vojvodine', 'Hajduk Veljkova 1-9, Novi Sad', 9000000000.00);
INSERT INTO public."Bolnica"("Naziv", "Adresa", "Budzet") VALUES('KBC Zemun', 'Vukova 9, Zemun', 5000000000.00);
INSERT INTO public."Bolnica"("Naziv", "Adresa", "Budzet") VALUES('KBC Bezanijska kosa', 'Dr Zorza Matea bb, Beograd', 6000000000.00);
INSERT INTO public."Bolnica"("Naziv", "Adresa", "Budzet") VALUES('Institut za ortopedske bolesti', 'Svetog Save 13, Novi Sad', 4000000000.00);
INSERT INTO public."Bolnica"("Naziv", "Adresa", "Budzet") VALUES('Opšta bolnica Valjevo', 'Vojvode Mišića 59, Valjevo', 2000000000.00);
INSERT INTO public."Bolnica"("Naziv", "Adresa", "Budzet") VALUES('Specijalna bolnica "Sveti Sava"', 'Cara Dušana 3, Sremska Kamenica', 3500000000.00);
INSERT INTO public."Bolnica"("Naziv", "Adresa", "Budzet") VALUES('Opšta bolnica Subotica', 'Izvorska bb, Subotica', 2500000000.00);
INSERT INTO public."Bolnica"("Naziv", "Adresa", "Budzet") VALUES('Klinički centar Niš', 'Zorana Đinđića 48, Niš', 8000000000.00);

INSERT INTO public."Dijagnoza"("Naziv", "Oznaka", "Opis") VALUES('Aritmija', 'AT01', 'Aritmija je naziv za nepravilan srcani ritam i predstavlja iregularnost frekvencije i redosled otkucaja srca.');
INSERT INTO public."Dijagnoza"("Naziv", "Oznaka", "Opis") VALUES('Encefalitis', 'EF02', 'Encefalitisi su upalna stanja koja zahvataju mozak i koja su uzrokovana uglavnom virusima.');
INSERT INTO public."Dijagnoza"("Naziv", "Oznaka", "Opis") VALUES('Perikarditis', 'PK03', 'Perikarditis je zapaljenski proces koji podrazumeva otok i iritaciju srcane maramice sa vecim ili manjim izlivom tecnosti unutar srcane kese.');
INSERT INTO public."Dijagnoza"("Naziv", "Oznaka", "Opis") VALUES('Miokarditis', 'MK04', 'Miokarditis je zapaljenje miokarda - srednjeg sloja zida srca.');
INSERT INTO public."Dijagnoza"("Naziv", "Oznaka", "Opis") VALUES('Upala srednjeg uha', 'USH05', 'Infekcija srednjeg uha je najcesci uzrok bola u predelu uha.');
INSERT INTO public."Dijagnoza"("Naziv", "Oznaka", "Opis") VALUES('Pneumonija', 'PN06', 'Pneumonija je infekcija pluća koja može biti uzrokovana raznim bakterijama, virusima ili gljivicama.');
INSERT INTO public."Dijagnoza"("Naziv", "Oznaka", "Opis") VALUES('Gastritis', 'GT07', 'Gastritis je upala sluznice želuca, obično uzrokovana infekcijom bakterijom Helicobacter pylori ili dugotrajnom upotrebom nesteroidnih antiinflamatornih lijekova.');
INSERT INTO public."Dijagnoza"("Naziv", "Oznaka", "Opis") VALUES('Hipertenzija', 'HT08', 'Hipertenzija, poznata i kao visoki krvni tlak, predstavlja stanje u kojem je krvni tlak u arterijama povišen.');
INSERT INTO public."Dijagnoza"("Naziv", "Oznaka", "Opis") VALUES('Dijabetes', 'DB09', 'Dijabetes je kronična bolest koja se javlja kada tijelo ne proizvodi dovoljno inzulina ili ne koristi inzulin adekvatno, što rezultira povišenim nivoom šećera u krvi.');
INSERT INTO public."Dijagnoza"("Naziv", "Oznaka", "Opis") VALUES('Migrena', 'MG10', 'Migrena je neurološki poremećaj koji se manifestira kao intenzivan pulsirajući bol, obično na jednoj strani glave, često praćen mučninom, povraćanjem i osjetljivošću na svjetlost i zvuk.');

INSERT INTO public."Odeljenje"("Naziv", "Lokacija", "BolnicaId") VALUES ('Ortopedija', 'Sprat 3, 304', 6);
INSERT INTO public."Odeljenje"("Naziv", "Lokacija", "BolnicaId") VALUES ('Kardiologija', 'Sprat 2, 211', 3);
INSERT INTO public."Odeljenje"("Naziv", "Lokacija", "BolnicaId") VALUES ('Hirurgija', 'Sprat 1, 101', 2);
INSERT INTO public."Odeljenje"("Naziv", "Lokacija", "BolnicaId") VALUES ('Neurohirurgija', 'Sprat 3, 319', 5);
INSERT INTO public."Odeljenje"("Naziv", "Lokacija", "BolnicaId") VALUES ('Oftalmologija', 'Sprat 4, 404', 4);
INSERT INTO public."Odeljenje"("Naziv", "Lokacija", "BolnicaId") VALUES ('Gastroenterologija', 'Sprat 2, 206', 2);
INSERT INTO public."Odeljenje"("Naziv", "Lokacija", "BolnicaId") VALUES ('Pulmologija', 'Sprat 5, 512', 3);
INSERT INTO public."Odeljenje"("Naziv", "Lokacija", "BolnicaId") VALUES ('Pedijatrija', 'Sprat 1, 115', 6);
INSERT INTO public."Odeljenje"("Naziv", "Lokacija", "BolnicaId") VALUES ('Dermatologija', 'Sprat 3, 322', 5);
INSERT INTO public."Odeljenje"("Naziv", "Lokacija", "BolnicaId") VALUES ('Psihijatrija', 'Sprat 4, 401', 7);

INSERT INTO public."Pacijent"("Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "OdeljenjeId", "DijagnozaId") VALUES ('Jovana', 'Jeremic', true, to_date('14.01.2023.', 'dd.mm.yyyy.'), 5, 4);
INSERT INTO public."Pacijent"("Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "OdeljenjeId", "DijagnozaId") VALUES ('Milica', 'Petrovic', false, to_date('23.03.2023.', 'dd.mm.yyyy.'), 3, 2);
INSERT INTO public."Pacijent"("Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "OdeljenjeId", "DijagnozaId") VALUES ('Nikola', 'Stefanovic', true, to_date('17.02.2023.', 'dd.mm.yyyy.'), 3, 3);
INSERT INTO public."Pacijent"("Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "OdeljenjeId", "DijagnozaId") VALUES ('Sofija', 'Boganovska', true, to_date('29.03.2023.', 'dd.mm.yyyy.'), 5, 5);
INSERT INTO public."Pacijent"("Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "OdeljenjeId", "DijagnozaId") VALUES ('Stefan', 'Aleksic', true, to_date('14.01.2023.', 'dd.mm.yyyy.'), 2, 3);
INSERT INTO public."Pacijent"("Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "OdeljenjeId", "DijagnozaId") VALUES ('Milos', 'Trifunovic', true, to_date('14.01.2023.', 'dd.mm.yyyy.'), 4, 2);
INSERT INTO public."Pacijent"("Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "OdeljenjeId", "DijagnozaId") VALUES ('Jelena', 'Karleusa Star', true, to_date('14.01.2023.', 'dd.mm.yyyy.'), 4, 6);
INSERT INTO public."Pacijent"("Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "OdeljenjeId", "DijagnozaId") VALUES ('Milan', 'Petrovic', true, to_date('15.06.2023.', 'dd.mm.yyyy.'), 2, 4);
INSERT INTO public."Pacijent"("Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "OdeljenjeId", "DijagnozaId") VALUES ('Ivana', 'Jovanovic', false, to_date('07.03.2023.', 'dd.mm.yyyy.'), 7, 3);
INSERT INTO public."Pacijent"("Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "OdeljenjeId", "DijagnozaId") VALUES ('Marko', 'Nikolic', true, to_date('20.09.2023.', 'dd.mm.yyyy.'), 3, 9);
INSERT INTO public."Pacijent"("Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "OdeljenjeId", "DijagnozaId") VALUES ('Ana', 'Vasic', true, to_date('11.04.2023.', 'dd.mm.yyyy.'), 6, 5);
INSERT INTO public."Pacijent"("Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "OdeljenjeId", "DijagnozaId") VALUES ('Nikola', 'Kovacevic', false, to_date('30.11.2023.', 'dd.mm.yyyy.'), 4, 2);

