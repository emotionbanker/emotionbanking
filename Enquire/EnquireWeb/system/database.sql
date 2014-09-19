DROP TABLE IF EXISTS victor2010zugangsdaten;
DROP TABLE IF EXISTS victor2010bank;
DROP TABLE IF EXISTS victor2010fragebogen;
DROP TABLE IF EXISTS victor2010personen;
DROP TABLE IF EXISTS victor2010frage;
DROP TABLE IF EXISTS victor2010ergebnisse;
DROP TABLE IF EXISTS victor2010f_f;
DROP TABLE IF EXISTS victor2010translations;
DROP TABLE IF EXISTS victor2010languages;
DROP TABLE IF EXISTS victor2010qalias;
DROP TABLE IF EXISTS victor2010meta;
DROP TABLE IF EXISTS victor2010replace;

CREATE TABLE victor2010meta (m_z_id INT NOT NULL,
                     ip TEXT,
                     time_start INT,
                     time_end INT,
                     PRIMARY KEY (m_z_id)
                    );

CREATE TABLE victor2010qalias (a_fr_id INT NOT NULL,
                        al_id INT NOT NULL,
                        alias TEXT
                       );

CREATE TABLE victor2010languages (l_id	INT NOT NULL AUTO_INCREMENT,
							short VARCHAR(3) NOT NULL default '',
							name VARCHAR(60) NOT NULL default '',
							PRIMARY KEY(l_id)
						 );

CREATE TABLE victor2010translations (t_l_id INT NOT NULL,
								 t_fr_id INT NOT NULL,
								 frage TEXT,
								 antworten TEXT
								);

CREATE TABLE victor2010zugangsdaten (z_id   INT NOT NULL AUTO_INCREMENT,
						code   VARCHAR(4) NOT NULL default '',
						z_b_id VARCHAR(3) NOT NULL default '',
						z_p_id INT NOT NULL default 0,
						used   INT DEFAULT '0',
						status INT DEFAULT '0',
						PRIMARY KEY(z_id)
						);
                         
CREATE TABLE victor2010bank (b_id VARCHAR(3) NOT NULL,
				bezeichnung VARCHAR(60),
				klasse VARCHAR(60),
				PRIMARY KEY(b_id)
				);
                  
CREATE TABLE victor2010personen (p_id INT NOT NULL AUTO_INCREMENT,
					bezeichnung VARCHAR(60),
					PRIMARY KEY(p_id)
					);
                  
CREATE TABLE victor2010fragebogen (f_id   INT NOT NULL AUTO_INCREMENT,
						f_klasse VARCHAR(60) NOT NULL,
						f_p_id INT NOT NULL,
						reihenfolge TEXT,
						PRIMARY KEY(f_id)
						);

CREATE TABLE victor2010alias (a_id   INT NOT NULL AUTO_INCREMENT,
            b_id VARCHAR(3),
						original TEXT,
						alias TEXT,
						PRIMARY KEY(a_id)
						);
          
                   
CREATE TABLE victor2010frage (fr_id     INT NOT NULL AUTO_INCREMENT,
					frage     TEXT,
					display   VARCHAR(10),
					antworten TEXT,
					suche     TEXT,
					PRIMARY KEY(fr_id)
				);
                   
CREATE TABLE victor2010ergebnisse (e_id INT NOT NULL AUTO_INCREMENT,
						e_z_id  INT NOT NULL,
						e_fr_id INT NOT NULL,
						antwort TEXT,
						a_id INT,
						PRIMARY KEY(e_id)
						);

CREATE TABLE victor2010f_f (ff_fr_id INT NOT NULL,
				ff_f_id INT NOT NULL
				);

ALTER TABLE victor2010ergebnisse ADD INDEX z_id_fr_id (e_z_id, e_fr_id);

					