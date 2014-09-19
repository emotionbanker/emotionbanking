using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Web
{
	public class Static
	{
		public string Name;
		public string Text;

		public Static()
		{
			Name = Text = string.Empty;
		}

		public override string ToString()
		{
			return Name;
		}
	}


	[Serializable]
	public class WebSurvey
	{
		private FTPFactory ftp;
		public string Servername;
		public string FTPusername;
		public string FTPpassword;
		
		public string SystemDirectory;

		//settings
		public string SESSION_PATH;
		public string SESSION_EXPIRE;
		public string SYSTEM_DIR;
		public string BACKUP_DIR;
		public string STATIC_DIR;
		public string LOCK_DIR;

		public string DB_HOST;
		public string DB_USER;
		public string DB_PASS;
		public string DB_BASE;
		public string DB_SCRIPT;

		public string DB_ID;

		public string TITLE;

		private string USERNAME;
		private string PASSWORD;

		private ArrayList INCLUDES;

		public ArrayList Statics;

		//stylesheet
		//private StyleSheet CSS;
		private string style;

		public WebSurvey()
		{
			Initialize(string.Empty, string.Empty, string.Empty, string.Empty);
		}

		public WebSurvey(string server, string dir, string user, string password)
		{
			Initialize(server, dir, user, password);
		}

		private void Initialize(string server, string dir, string user, string password)
		{
			Statics = new ArrayList();
			this.Servername = server;
			this.SystemDirectory = dir;
			this.FTPusername = user;
			this.FTPpassword = password;

//			CSS = new StyleSheet();
			DefaultSettings();

			ftp = new FTPFactory();
		}

		public void SaveImage(string file)
		{
			//Connect();

			try{ftp.chdir("/" + SystemDirectory);}
			catch{}
			ftp.chdir("images");

			File.Copy(file, Path.GetTempPath() + "headImage.png");

			ftp.upload(Path.GetTempPath() + "headImage.png");

			//Close();
		}

		public Bitmap GetImage()
		{
			try{ftp.chdir("/" + SystemDirectory);}
			catch{}
			ftp.chdir("images");

			string file = Path.GetTempFileName();

			ftp.download("headImage.png", file);

			Bitmap bmp = new Bitmap(file);
			return bmp;
		}

		
		public string[] getStaticNames()
		{
			string[] list;
			//Connect();

			try
			{
				ftp.chdir("/" + SystemDirectory);
			}
			catch{}
			try
			{
				ftp.chdir("static");
			}
			catch{}

			list = ftp.getFileList("");

			Console.WriteLine("l=" + list.Length);

			for (int i = 0; i < list.Length; i++)
			{
				list[i] = list[i].Trim();
				Console.WriteLine(list[i]);
			}

			//Close();

			return list;
		}
		

		public void LoadStatics()
		{
			
			Statics.Clear();
			foreach (string st in getStaticNames())
			{
				try
				{
					Console.WriteLine(st);
				
					try {ftp.chdir("/" + SystemDirectory);}
					catch{}
					try{ftp.chdir("static");}
					catch{}
					ftp.setBinaryMode(false);


					File.Delete(Path.GetTempPath() + "ftptemp" + st);
					ftp.download(st, Path.GetTempPath() + "ftptemp" + st);

					Static s = new Static();

					s.Name = st;
					StreamReader sr = new StreamReader(Path.GetTempPath() + "ftptemp" + st);
					s.Text = sr.ReadToEnd();
					sr.Close();

					Statics.Add(s);

					//Console.WriteLine("loaded!");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
		/*
		public string getStaticAsString(string remote)
		{
			string s = string.Empty;
			try
			{
				//Connect();

				try {ftp.chdir("/" + SystemDirectory);}
				catch{}
				try{ftp.chdir("static");}
				catch{}
				ftp.setBinaryMode(false);
				File.Delete(Path.GetTempPath() + "ftptemp");
				ftp.download(remote, Path.GetTempPath() + "ftptemp");

				StreamReader sr = new StreamReader(Path.GetTempPath() + "ftptemp");
				s = sr.ReadToEnd();
				sr.Close();

				//Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
			}
			return s;
		}

		*/

		/*
		public void saveStatic(string file, string text)
		{
			try
			{

				FileStream fs = new FileStream(Path.GetTempPath() + file, FileMode.Create);
				StreamWriter sr = new StreamWriter(fs);
				sr.Write(text);
				sr.Close();
				fs.Close();

				//Connect();

				try{ftp.chdir("/" + SystemDirectory);}
				catch{}
				try{ftp.chdir("static");}
				catch{}

				ftp.upload(Path.GetTempPath() + file);

				//Close();
			}
			catch {}

		}
		*/

		public void saveStatics()
		{
			foreach (Static s in Statics)
			{
				try
				{
					FileStream fs = new FileStream(Path.GetTempPath() + s.Name, FileMode.Create);
					StreamWriter sr = new StreamWriter(fs);
					sr.Write(s.Text);
					sr.Close();
					fs.Close();

					//Connect();

					try{ftp.chdir("/" + SystemDirectory);}
					catch{}
					try{ftp.chdir("static");}
					catch{}

					ftp.upload(Path.GetTempPath() + s.Name);

					//Close();
				}
				catch {}
			}
		}

		public void Create()
		{
			string ddir = SystemTools.GetAppPath() + "websurvey/";
			string idir = ddir + "images/";
			string sdir = ddir + "static/";
			string ydir = ddir + "system/";
			//Connect();
			
			try {ftp.mkdir("/" + SystemDirectory);}
			catch{}

			ftp.chdir("/" + SystemDirectory);

			//start copying
			try {ftp.mkdir("sessions");}
			catch{}
			try {ftp.mkdir("images");}
			catch{}
			try {ftp.mkdir("locks");}
			catch{}
			try {ftp.mkdir("static");}
			catch{}
			try {ftp.mkdir("system");}
			catch{}
			try {ftp.mkdir("backup");}
			catch{}

			ftp.chmod("sessions", "777");
			ftp.chmod("locks", "777");
			ftp.chmod("backup", "777");
			ftp.chmod("static", "777");

			ftp.upload(ddir + "admin.php");
			ftp.upload(ddir + "index.php");
			ftp.upload(ddir + "settings");
			ftp.upload(ddir + "style.css");

			ftp.chdir("images");

			ftp.upload(idir + "admin.png");
			ftp.upload(idir + "bar.png");
			ftp.upload(idir + "headImage.png");
			ftp.upload(idir + "pcnt0.png");
			ftp.upload(idir + "pcnt10.png");
			ftp.upload(idir + "pcnt20.png");
			ftp.upload(idir + "pcnt30.png");
			ftp.upload(idir + "pcnt40.png");
			ftp.upload(idir + "pcnt50.png");
			ftp.upload(idir + "pcnt60.png");
			ftp.upload(idir + "pcnt70.png");
			ftp.upload(idir + "pcnt80.png");
			ftp.upload(idir + "pcnt90.png");
			ftp.upload(idir + "pcnt100.png");
			ftp.upload(idir + "sample-select.png");

			ftp.chdir("../static");

			ftp.upload(sdir + "public-welcome");
			ftp.upload(sdir + "public-end");
			ftp.upload(sdir + "admin-start");
			ftp.upload(sdir + "code-start");
			ftp.upload(sdir + "sys-closed");
			ftp.upload(sdir + "wrong-password");
			ftp.upload(sdir + "admin-welcome");

			ftp.chdir("../system");

			ftp.upload(ydir + "bank");
			ftp.upload(ydir + "codes");
			ftp.upload(ydir + "database.sql");
			ftp.upload(ydir + "db");
			ftp.upload(ydir + "debug");
			ftp.upload(ydir + "forms");
			ftp.upload(ydir + "panels");
			ftp.upload(ydir + "public");
			ftp.upload(ydir + "questions");
			ftp.upload(ydir + "system");
			ftp.upload(ydir + "userg");
			ftp.upload(ydir + "vis");

			//Close();
		}

		public void Connect()
		{

			ftp.setRemoteHost(Servername);
			ftp.setRemotePass(FTPpassword);
			ftp.setRemoteUser(FTPusername);
			//ftp.setDebug(true);

			try{ftp.login();}
			catch
			{
				MessageBox.Show("Die FTP-Verbindung konnte nicht hergestellt werden. Bitte versuchen Sie es erneut.", "Verbindungsfehler");
			}

			ftp.setBinaryMode(true);
		}

		public void Close()
		{
			ftp.close();
		}

		private void DefaultSettings()
		{
			SESSION_PATH	= "./sessions/";
			SESSION_EXPIRE	= "100";
			SYSTEM_DIR		= "./system/";
			BACKUP_DIR      = "./backup/";
			STATIC_DIR		= "./static/";
			LOCK_DIR		= "./locks/";


			USERNAME		= "administrator";
			PASSWORD		= "start";

			INCLUDES = new ArrayList();
			INCLUDES.Add("db");
			INCLUDES.Add("vis");
			INCLUDES.Add("debug");
			INCLUDES.Add("bank");
			INCLUDES.Add("userg");
			INCLUDES.Add("codes");
			INCLUDES.Add("questions");
			INCLUDES.Add("forms");
			INCLUDES.Add("panels");
			INCLUDES.Add("system");
			INCLUDES.Add("public");
		}

		public string getCSS()
		{
			return style.Replace("\n", "\r\n");
		}

		public void setCSS(string css)
		{
			style = css.Replace("\r\n", "\n");
		}

		public string getSQLScript()
		{
			string s = string.Empty;

			s += @" DROP TABLE IF EXISTS " + DB_ID + @"zugangsdaten;
					DROP TABLE IF EXISTS " + DB_ID + @"bank;
					DROP TABLE IF EXISTS " + DB_ID + @"fragebogen;
					DROP TABLE IF EXISTS " + DB_ID + @"personen;
					DROP TABLE IF EXISTS " + DB_ID + @"frage;
					DROP TABLE IF EXISTS " + DB_ID + @"ergebnisse;
					DROP TABLE IF EXISTS " + DB_ID + @"f_f;
					DROP TABLE IF EXISTS " + DB_ID + @"translations;
					DROP TABLE IF EXISTS " + DB_ID + @"languages;

					CREATE TABLE languages (l_id	INT NOT NULL AUTO_INCREMENT,
												short VARCHAR(3) NOT NULL default '',
												name VARCHAR(60) NOT NULL default '',
												PRIMARY KEY(l_id)
											 );

					CREATE TABLE translations (t_l_id INT NOT NULL,
													 t_fr_id INT NOT NULL,
													 frage TEXT,
													 antworten TEXT
													);

					CREATE TABLE " + DB_ID + @"zugangsdaten (z_id   INT NOT NULL AUTO_INCREMENT,
											code   VARCHAR(4) NOT NULL default '',
											z_b_id VARCHAR(3) NOT NULL default '',
											z_p_id INT NOT NULL default '',
											used   INT DEFAULT '0',
											status INT DEFAULT '0',
											PRIMARY KEY(z_id)
											);
					                         
					CREATE TABLE " + DB_ID + @"bank (b_id VARCHAR(3) NOT NULL,
									bezeichnung VARCHAR(60),
									klasse VARCHAR(60),
									PRIMARY KEY(b_id)
									);
					                  
					CREATE TABLE " + DB_ID + @"personen (p_id INT NOT NULL AUTO_INCREMENT,
										bezeichnung VARCHAR(60),
										PRIMARY KEY(p_id)
										);
					                  
					CREATE TABLE " + DB_ID + @"fragebogen (f_id   INT NOT NULL AUTO_INCREMENT,
											f_klasse VARCHAR(60) NOT NULL,
											f_p_id INT NOT NULL,
											reihenfolge TEXT,
											PRIMARY KEY(f_id)
											);
					                   
					CREATE TABLE " + DB_ID + @"frage (fr_id     INT NOT NULL AUTO_INCREMENT,
										frage     TEXT,
										display   VARCHAR(10),
										antworten TEXT,
										suche     TEXT,
										PRIMARY KEY(fr_id)
									);
					                   
					CREATE TABLE " + DB_ID + @"ergebnisse (e_id INT NOT NULL AUTO_INCREMENT,
											e_z_id  INT NOT NULL,
											e_fr_id INT NOT NULL,
											antwort TEXT,
											PRIMARY KEY(e_id)
											);

					CREATE TABLE " + DB_ID + @"f_f (ff_fr_id INT NOT NULL,
									ff_f_id INT NOT NULL
									);

					ALTER TABLE " + DB_ID + @"ergebnisse ADD INDEX z_id_fr_id (e_z_id, e_fr_id);

					";
					

			return s;
		}

		public string getSettings()
		{
			string s = string.Empty;

			s += "<?php\n";
			s += "	define ('SESSION_PATH', \"" + SESSION_PATH + "\");\n";
			s += "	define ('SESSION_EXPIRE', \"" + SESSION_EXPIRE + "\");\n";
			s += "	define ('SYSTEM_DIR', \"" + SYSTEM_DIR + "\");\n";
			s += "  define ('BACKUP_DIR', \"" + BACKUP_DIR + "\");\n";
			s += "	define ('STATIC_DIR', \"" + STATIC_DIR + "\");\n";
			s += "	define ('LOCK_DIR', \"" + LOCK_DIR + "\");\n";
			s += "	define ('DB_HOST', \"" + DB_HOST + "\");\n";
			s += "	define ('DB_USER', \"" + DB_USER + "\");\n";
			s += "	define ('DB_PASS', \"" + DB_PASS + "\");\n";
			s += "	define ('DB_BASE', \"" + DB_BASE + "\");\n";
			s += "	define ('DB_SCRIPT', SYSTEM_DIR . \"" + DB_SCRIPT + "\");\n";
			s += "	define('USERNAME', \"" + USERNAME + "\");\n";
			s += "	define('PASSWORD', \"" + PASSWORD + "\");\n";
			s += "  define ('TITLE', \"" + TITLE + "\");\n";
			s += "  define ('DB_ID', \"" + DB_ID + "\");\n";

			s += "  define ('BANK',     DB_ID . \"bank\");\n";
			s += "  define ('ZUG',      DB_ID . \"zugangsdaten\");\n";
			s += "  define ('PERSONEN', DB_ID . \"personen\");\n";
			s += "  define ('FF',       DB_ID . \"f_f\");\n";
			s += "  define ('BOGEN',    DB_ID . \"fragebogen\");\n";
			s += "  define ('RES',      DB_ID . \"ergebnisse\");\n";
			s += "  define ('FRAGE',    DB_ID . \"frage\");\n";


			foreach (string inc in INCLUDES)
			   s += " require_once(SYSTEM_DIR . \"" + inc + "\");";

			s += "  ?>";

			return s;
		}

		private void setValue(string var, string val)
		{
			switch (var)
			{
				case "SESSION_PATH": SESSION_PATH = val; break;
				case "SESSION_EXPIRE": SESSION_EXPIRE = val; break;
				case "SYSTEM_DIR":   SYSTEM_DIR = val; break;
				case "BACKUP_DIR":   BACKUP_DIR = val; break;
				case "STATIC_DIR":   STATIC_DIR = val; break;
				case "LOCK_DIR":     LOCK_DIR = val; break;

				case "DB_HOST":   DB_HOST = val; break;
				case "DB_USER":   DB_USER = val; break;
				case "DB_PASS":   DB_PASS = val; break;
				case "DB_BASE":   DB_BASE = val; break;
				case "DB_SCRIPT": DB_SCRIPT = val; break;

				case "TITLE": TITLE = val; break;
				case "DB_ID": DB_ID = val; break;
			}
		}
		private void ReadSettingsFromFile(string file)
		{
			FileStream fs = new FileStream(file, FileMode.Open);
			StreamReader sr = new StreamReader(fs);

			string settings = sr.ReadToEnd();

			sr.Close();
			fs.Close();

			string defPattern = "define \\('(.*)',(.*)\"(.*)\"(.*)\\);";

			Regex r = new Regex(defPattern);

			Match m = r.Match(settings);

			while(m.Success)
			{
				Group var = m.Groups[1];
				Group val = m.Groups[3];

				Console.WriteLine(var.Value + " = " + val.Value);
				setValue(var.Value, val.Value);

				m = m.NextMatch();
			}
		}

		private void SaveSettingsToFile(string file)
		{
			FileStream fs = new FileStream(file, FileMode.Create);
			StreamWriter sr = new StreamWriter(fs);

			sr.Write(getSettings());

			sr.Close();
			fs.Close();
		}

		private void ReadStylesFromFile(string file)
		{
			FileStream fs = new FileStream(file, FileMode.Open);
			StreamReader sr = new StreamReader(fs);

			style = sr.ReadToEnd();

			sr.Close();
			fs.Close();

			//style = style.Replace("\n", "\r\n");
		}

		private void SaveSQLScriptToFile(string file)
		{
			FileStream fs = new FileStream(file, FileMode.Create);
			StreamWriter sr = new StreamWriter(fs);

			sr.Write(this.getSQLScript());

			sr.Close();
			fs.Close();
		}

		private void SaveStylesToFile(string file)
		{
			FileStream fs = new FileStream(file, FileMode.Create);
			StreamWriter sr = new StreamWriter(fs);

			sr.Write(style);

			sr.Close();
			fs.Close();
		}

		public void ReadData()
		{
			string temp1 = Path.GetTempPath() + "settings";
			string temp2 = Path.GetTempPath() + "style.css";
			try
			{
				//Connect();

				ftp.chdir("/" + SystemDirectory);

				ftp.download("settings", temp1);
				ftp.download("style.css", temp2);

				//Close();

				ReadSettingsFromFile(temp1);
				ReadStylesFromFile(temp2);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		public void SaveData()
		{
			string temp1 = Path.GetTempPath() + "settings";
			SaveSettingsToFile(temp1);
			string temp2 = Path.GetTempPath() + "style.css";
			SaveStylesToFile(temp2);
			string temp3 = Path.GetTempPath() + "database.sql";
			SaveSQLScriptToFile(temp3);

			try
			{
				//Connect();

				try{ftp.chdir("/" + SystemDirectory);}
				catch{}

				ftp.upload(temp1);
				ftp.upload(temp2);

				try{ftp.chdir("system");}
				catch{}

				ftp.upload(temp3);

				//Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

	}
}