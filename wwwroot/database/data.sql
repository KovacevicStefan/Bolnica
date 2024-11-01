INSERT INTO public."Bolnica" ("Id", "Naziv", "Adresa", "Slika", "BrojTelefona", "Budzet") VALUES
(1, 'Ortopedska bolnica Banjica', 'Mihaila Avramovica 28, Beograd', 'https://bizlife.rs/upload/2012/jun/13/mara/banjica-inst.jpg', '021/2711-689', 3000000000.00),
(2, 'Institut za zastitu majke i deteta', 'Radoja Dakica 6-8, Beograd', 'https://www.gradnja.rs/wp-content/uploads/2022/01/Institut-za-majku-i-dete-3.jpg', '011/4351-256', 10000000000.00),
(3, 'Klinicki centar Vojvodine', 'Hajduk Veljkova 1-9, Novi Sad', 'https://www.kcv.rs/wp-content/uploads/2023/07/4-scaled.jpg', '021/5612-479', 9000000000.00),
(4, 'KBC Bezanijska kosa', 'Dr Zorza Matea bb, Beograd', 'https://xdn.tf.rs/2020/11/05/kbc-bezanijska-kosa-foto-marko-jovnaovic-127-1200x630.jpg', '011/6234-198', 6000000000.00),
(5, 'KBC Zemun', 'Vukova 9, Zemun', 'https://zemun.rs/wp-content/uploads/2021/02/kbc-zemun-I.jpg', '011/2345-678', 5000000000.00),
(6, 'Klinički centar Niš', 'Zorana Đinđića 48, Niš', 'https://ocdn.eu/images/pulscms/OTM7MDA_/66845ad16ff2a397298493ff2c8a663b.jpeg', '018/7889-123', 8000000000.00),
(7, 'Opšta bolnica Subotica', 'Izvorska bb, Subotica', 'https://bolnicasubotica.com/portal/foto/1546736859bolnica-subotica.jpg', '024/4567-890', 2500000000.00),
(8, 'Specijalna bolnica "Sveti Sava"', 'Cara Dušana 3, Sremska Kamenica', 'https://n1info.rs/wp-content/uploads/2022/10/24/1666622080-shutterstock_1947244624-1200x800.jpg', '021/8745-321', 3500000000.00),
(9, 'Opšta bolnica Valjevo', 'Vojvode Mišića 59, Valjevo', 'https://www.valjevo.rs/valjevo_wp/wp-content/uploads/2015/09/srbZdravstveni-centar-Valje.jpg', '014/1234-567', 2000000000.00),
(10, 'Institut za ortopedske bolesti', 'Svetog Save 13, Novi Sad', 'https://lh4.googleusercontent.com/proxy/CYwmuvBR_4qzRO-WTFefOjvztJD9oK8yf06mOtbM83mE62qtwQpVa_2wnNLEv3n0HO4jEoWVI98-31kOymLC4-b-NqhVT_zlZh-vHqG4nY1f5_9FN438IkE2YGgL3wMUPls02XH7iGI', '021/1122-334', 4000000000.00);

INSERT INTO public."Dijagnoza" ("Id", "Naziv", "Opis", "Slika", "Oznaka") VALUES
(1, 'Migrena', 'Migrena je neurološki poremećaj koji se manifestira kao intenzivan pulsirajući bol, obično na jednoj strani glave, često praćen mučninom, povraćanjem i osjetljivošću na svjetlost i zvuk.', 'https://ordinacijaalona.com/wp-content/uploads/2018/02/migrena-glavobolja-1.jpg', 'MG10'),
(2, 'Dijabetes', 'Dijabetes je kronična bolest koja se javlja kada tijelo ne proizvodi dovoljno inzulina ili ne koristi inzulin adekvatno, što rezultira povišenim nivoom šećera u krvi.', 'https://zavodgaj.rs/wp-content/uploads/2020/08/secerna-bolest-dijabetes.jpg', 'DB09'),
(3, 'Perikarditis', 'Perikarditis je zapaljenski proces koji podrazumeva otok i iritaciju srcane maramice sa vecim ili manjim izlivom tecnosti unutar srcane kese.', 'https://epoteka.rs/wp-content/uploads/2022/08/INFARTO-MIOCARDIO-1-1024x652.jpg', 'PK03'),
(4, 'Miokarditis', 'Miokarditis je zapaljenje miokarda - srednjeg sloja zida srca.', 'https://asabolnica.ba/sites/default/files/inline-images/Kako%20se%20lije%C4%8Di%20%20miokarditis.jpg', 'MK04'),
(5, 'Upala srednjeg uha', 'Infekcija srednjeg uha je najcesci uzrok bola u predelu uha.', 'https://www.plivazdravlje.hr/?plivahealth[section]=IMAGEmanager&plivahealth[action]=getIMAGE&plivahealth[id]=19332&plivahealth[size]=304&', 'USH05'),
(6, 'Pneumonija', 'Pneumonija je infekcija pluća koja može biti uzrokovana raznim bakterijama, virusima ili gljivicama.', 'https://euromedic.rs/pregledi/wp-content/uploads/2020/05/Upala-pluca.jpg', 'PN06'),
(7, 'Gastritis', 'Gastritis je upala sluznice želuca, obično uzrokovana infekcijom bakterijom Helicobacter pylori ili dugotrajnom upotrebom nesteroidnih antiinflamatornih lijekova.', 'https://krugzdravlja.rs/wp-content/uploads/2021/04/gastritis-01.jpg', 'GT07'),
(8, 'Hipertenzija', 'Hipertenzija, poznata i kao visoki krvni tlak, predstavlja stanje u kojem je krvni tlak u arterijama povišen.', 'https://www.labomedica.net/wp-content/uploads/2020/05/visok-krvni-pritisak.jpg', 'HT08'),
(9, 'Aritmija', 'Aritmija je naziv za nepravilan srcani ritam i predstavlja iregularnost frekvencije i redosled otkucaja srca.', 'https://www.ordinacijanesovic.rs/wp-content/uploads/2023/03/aritmija-apsoluta.jpg', 'AT01'),
(10, 'Encefalitis', 'Encefalitisi su upalna stanja koja zahvataju mozak i koja su uzrokovana uglavnom virusima.', 'https://upload.wikimedia.org/wikipedia/commons/d/d5/Hsv_encephalitis.jpg', 'EF02');

INSERT INTO public."Odeljenje" ("Id", "Naziv", "Lokacija", "Slika", "BolnicaId") VALUES
(1, 'Ortopedija', 'Sprat 3, 304', 'https://poliklinika-lokrum.hr/wp-content/uploads/2019/08/ortopedija-01-mala.jpg', 6),
(2, 'Psihijatrija', 'Sprat 4, 401', 'https://zdravlje.eu/wp-content/uploads/2009/02/Psihijatrija.jpg', 7),
(3, 'Dermatologija', 'Sprat 3, 322', 'https://www.westmedic.rs/wp-content/uploads/2021/10/dermatologija-01-1.jpg', 5),
(4, 'Pedijatrija', 'Sprat 1, 115', 'https://www.cardiosnovisad.rs/wp-content/uploads/pedijatrija-cardios-novi-sad.jpg', 6),
(5, 'Pulmologija', 'Sprat 5, 512', 'https://ordinacija-dijanakovacevic.rs/wp-content/uploads/2022/02/plucne-bolesti.jpg', 3),
(6, 'Gastroenterologija', 'Sprat 2, 206', 'https://www.poliklinikanaissa.com/wp-content/uploads/2017/06/gastroskopija-endoskopija-01-1.jpg', 2),
(7, 'Oftalmologija', 'Sprat 4, 404', 'https://novamed.hr/wp-content/uploads/2023/01/oftalmologija.jpg', 4),
(8, 'Neurohirurgija', 'Sprat 3, 319', 'https://upload.wikimedia.org/wikipedia/commons/e/e0/Sanjay_Gupta_%26_medical_team_prepare_for_brain_surgery_on_USS_Carl_Vinson_%28CVN-70%29_2010-01-18.jpg', 5),
(9, 'Hirurgija', 'Sprat 1, 101', 'https://www.sbparks.rs/wp-content/uploads/2024/07/Parks-dr-Takashi-Toyonaga-500-x-300-px.png', 2),
(10, 'Kardiologija', 'Sprat 2, 211', 'https://poliklinikanovakov.com/wp-content/uploads/2022/10/kardiologija.jpg', 3);

INSERT INTO public."Pacijent" ("Id", "Ime", "Prezime", "Zdr_osiguranje", "DatumRodjenja", "Slika", "OdeljenjeId", "DijagnozaId") VALUES
(1, 'Jovana', 'Jeremic', TRUE, '2023-01-13 01:00:00+01', 'https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png', 5, 4),
(2, 'Milan', 'Petrovic', TRUE, '2023-06-14 02:00:00+02', 'https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png', 2, 4),
(3, 'Sofija', 'Boganovska', TRUE, '2023-03-28 02:00:00+02', 'https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png', 5, 5),
(4, 'Ana', 'Vasic', TRUE, '2023-04-10 02:00:00+02', 'https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png', 6, 5),
(5, 'Jelena', 'Karleusa Star', TRUE, '2023-01-13 01:00:00+01', 'https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png', 4, 6),
(6, 'Marko', 'Nikolic', TRUE, '2023-09-19 02:00:00+02', 'https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png', 3, 9),
(7, 'Milica', 'Petrovic', FALSE, '2023-03-22 01:00:00+01', 'https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png', 3, 2),
(8, 'Milos', 'Trifunovic', TRUE, '2023-01-13 01:00:00+01', 'https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png', 4, 2),
(9, 'Nikola', 'Kovacevic', FALSE, '2023-11-29 01:00:00+01', 'https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png', 4, 2),
(10, 'Nikola', 'Stefanovic', TRUE, '2023-02-16 01:00:00+01', 'https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png', 3, 3),
(11, 'Ivana', 'Jovanovic', FALSE, '2023-03-06 01:00:00+01', 'https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png', 7, 3),
(12, 'Stefan', 'Aleksic', TRUE, '2023-01-13 01:00:00+01', 'https://storage.needpix.com/rsynced_images/blank-profile-picture-973460_1280.png', 2, 3);
