<?php

/**

victor umfragesystem
lukas maczejka, 2005

**/

//defaults, directories
require_once("./settings.php");


//begin

$db = initDB();

if(!connectDB($db))
{
  debug($db['msg']);
  die();
}


session_cache_expire(SESSION_EXPIRE);
session_save_path(SESSION_PATH);

session_start();



$r = $_REQUEST;
reset($r);
$key = key($r);
$v = $_REQUEST[$key];
reset($r);
$k = key($r);

//if(!$_SESSION['user'])
//  $k = "login";

if ($_SESSION['display'] != "flat")
  $_SESSION['display'] = $_REQUEST['display'];
  
if ($_SESSION['allow-reset'] != "true")
  $_SESSION['allow-reset'] = $_REQUEST['allow-reset'];
  
if ($_SESSION['numbers'] != 1)
  $_SESSION['numbers'] = $_REQUEST['numbers'];

if ($_SESSION['dodebug'] != 1)  
	$_SESSION['dodebug'] = $_REQUEST['dodebug'];


if ($k == 'login')
{
	$loginerr=false;

	if (!$r['nocode'] && $r['code']) //regular code
  {  	
    if (!(($code = explodeCode($r['code'])) && loginCode($code)))
      $loginerr=true;
  }
  else //quicklink
  {
  	//link
  	// ?login&nocode=true&bank=XXX&userg=Y
  	
  	//alt link:
  	// ?login=XXXY
  	
  	if ($r['login']) //new style code
  	{
  		$nsbank = substr($r['login'], 0, 3);
  		$nscode = substr($r['login'], 3);
  		
  		if (!loginCode($nsbank,$nscode))
      	$loginerr=true;
  	}
  	else //old style code
  	{
  		if (!loginCode($r['bank'],$r['userg']))
      	$loginerr=true;
    }
  }
}

//if(!$_SESSION['user'])
//  $k = "login";

// begin html header

//debug($_SESSION['user']);
?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" >
  <head>
     <title><?php echo TITLE; ?></title>
     <meta http-equiv="Content-type" content="text/html; charset=iso-8859-1" />
     <?php
       echo "<link rel='stylesheet' type='text/css' href='./styles/".getStyle($_SESSION['user']['code']['p_id'], $_SESSION['user']['code']['b_id'])."/style.css' />";
     ?>
     
     <script language='javascript'>
     	function getElementByIdCompatible (the_id) {
if (typeof the_id != 'string') {
return the_id;
}

if (typeof document.getElementById != 'undefined') {
return document.getElementById(the_id);
} else if (typeof document.all != 'undefined') {
return document.all[the_id];
} else if (typeof document.layers != 'undefined') {
return document.layers[the_id];
} else {
return null;
}
}

function toggleDsa()
{
	getElementByIdCompatible("dsa").style.display="block";
	getElementByIdCompatible("dsabutton").style.display="none";
}
     	</script>
  </head>

<?php

//begin page

echo "<body>";
echo "<table class='main' cellspacing='0' cellpadding='0'>";
echo "  <tr class='head'>";
echo "    <td colspan='2'></td>";//<img style='display: inline;' src='./images/headImage.gif' /></td>";
//echo "    <td>";
//echo "   <span style='font-size: 18pt; color: #d0d0d0; padding: 50px;'>    v i c t o r <sup>&copy;</sup> 2 0 0 5</span>";
//echo "   <span style='font-size: 18pt; color: #d0d0d0; padding: 50px;'>    bank des jahres</span>";
//echo "    </td>";
echo "  </tr>";
/*      
echo "  <tr class='head2'>";
echo "     <td colspan='2' class='sponsors'><a href='?home'><img style='border: none;' src='./images/logo.gif' /></a>";
echo "    </td>";
echo "  </tr>";
*/
echo "  <tr class='content'>";
echo "   <td class='content' colspan='2'>";


          
if (!sysClosed())
{
  switch($k)
  { 
    case "home":

    case "logout":	
      $_SESSION['user'] = 0;
      include(STATIC_DIR . "code-start");
      break;
      
    case "login":
    	if (!$loginerr)
    	{
    		 //set lang
          if (isset($r['lang']))
          	$_SESSION['user']['lang'] = $r['lang'];
          else
           $_SESSION['user']['lang'] = "default";
           
          //$lang = getLangInfoByID($r['lang']);
           
          if($_SESSION['user']['userg'] == "Führungskraft mit FK")
            $out = "Führungskraft";
          else if($_SESSION['user']['userg'] == "Firmenkundenbetreuer")
            $out = "Mitarbeiter";
          else
            $out = $_SESSION['user']['userg'];
          
          //debug($_SESSION['user']);
            
          include(TEXT_PATH . getText07($_SESSION['user']['code']['p_id'], $_SESSION['user']['code']['b_id'], $r['lang']));
          
          /*
            
          if (file_exists(STATIC_DIR . "public-welcome-".$out."-".$lang['short']))
            include (STATIC_DIR . "public-welcome-".$out."-".$lang['short']);
          else if (file_exists(STATIC_DIR . "public-welcome-".$out))
            include(STATIC_DIR . "public-welcome-".$out);
          else if (file_exists(STATIC_DIR . "public-welcome-".$lang['short']))
            include (STATIC_DIR . "public-welcome-".$lang['short']);
          else
            include(STATIC_DIR . "public-welcome");
          
          */
    	}
    	else
    	{
    		 echo "Bank gesperrt, Code ungültig oder bereits verwendetet. Anmeldung fehlgeschlagen.<br/><br/>";
         include(STATIC_DIR . "code-start");
    	}
      /*
      if (!$r['nocode'])
      {
        if (($code = explodeCode($r['code'])) && loginCode($code))
        {
        	 //set lang
          if (isset($r['lang']))
          	$_SESSION['user']['lang'] = $r['lang'];
          else
           $_SESSION['user']['lang'] = "default";
           
          $lang = getLangInfoByID($r['lang']);
           
          if($_SESSION['user']['userg'] == "Führungskraft mit FK")
            $out = "Führungskraft";
          else if($_SESSION['user']['userg'] == "Firmenkundenbetreuer")
            $out = "Mitarbeiter";
          else
            $out = $_SESSION['user']['userg'];
            
          if (file_exists(STATIC_DIR . "public-welcome-".$out."-".$lang['short']))
            include (STATIC_DIR . "public-welcome-".$out."-".$lang['short']);
          else if (file_exists(STATIC_DIR . "public-welcome-".$out))
            include(STATIC_DIR . "public-welcome-".$out);
          else if (file_exists(STATIC_DIR . "public-welcome-".$lang['short']))
            include (STATIC_DIR . "public-welcome-".$lang['short']);
          else
            include(STATIC_DIR . "public-welcome");
            
         
        }
        else
        {
          echo "bank gesperrt, code ungültiger oder bereits verwendetet. anmeldeung fehlgeschlagen.<br/><br/>";
          include(STATIC_DIR . "code-start");
        }
      }
      else
      {       
        //debug($out);
        if (loginCode($r['bank'],$r['userg']))
        {
        	//set lang
          if (isset($r['lang']))
          	$_SESSION['user']['lang'] = $r['lang'];
          else
           $_SESSION['user']['lang'] = "default";
           
           $lang = getLangInfoByID($r['lang']);
           
          if($_SESSION['user']['userg'] == "Führungskraft mit FK")
            $out = "Führungskraft";
          else if($_SESSION['user']['userg'] == "Firmenkundenbetreuer")
            $out = "Mitarbeiter";
          else
            $out = $_SESSION['user']['userg'];
            
         
          if (($r['userg'] ==3 || $r['userg'] == 4) &&file_exists(STATIC_DIR . "public-welcome-".$out."-".$lang['short']))
            include (STATIC_DIR . "public-welcome-".$out."-".$lang['short']);
          else if (($r['userg'] ==3 || $r['userg'] == 4) && file_exists(STATIC_DIR . "public-welcome-".$out))
            include(STATIC_DIR . "public-welcome-".$out);
          else if (file_exists(STATIC_DIR . "public-welcome-".$lang['short']))
            include (STATIC_DIR . "public-welcome-".$lang['short']);
          else
            include(STATIC_DIR . "public-welcome");
            
          /*
          if ( ($r['userg'] ==3 || $r['userg'] == 4)  && file_exists(STATIC_DIR . "public-welcome-".$out))
            include(STATIC_DIR . "public-welcome-".$out);
          else
            include(STATIC_DIR . "public-welcome");
            *//*
        }
        else
        {
          echo "bank gesperrt oder ungültige anmeldung (bitte überprüfen sie den anmeldelink)";
        }
      }
      */
      break;
      
    case "form":
      //debug($_SESSION);
      if (doForm($r['form'],$r['q'],3) == "end")
      {
      	 $lang = getLangInfoByID($_SESSION['user']['lang']);
      	 
      	 
      	 //yay, end -> set end meta
      	 query("update ".META." set time_end='".time()."' where m_z_id='".$_SESSION['user']['uid']."'");
      	 
      	 
      	include(TEXT_PATH . getText07($_SESSION['user']['code']['p_id'], $_SESSION['user']['code']['b_id'], $r['lang'], "etexts"));
         
         /*
      	if (file_exists(STATIC_DIR . "public-end" . "-" . $lang['short']))
      	  include (STATIC_DIR . "public-end" . "-" . $lang['short']);
      	else
          include (STATIC_DIR . "public-end");
          */
        $_SESSION['user'] = 0;
      }
      break;
    
    case "fragebogen":
      if (file_exists(STATIC_DIR . $r['fragebogen']))
        include(STATIC_DIR . $r['fragebogen']);
      include(STATIC_DIR . "public-welcome");
      loginCode($r['fragebogen'],$r['uid']);
      break;
            
    default:
      include(STATIC_DIR . "code-start");
      break;
  }
}
else
  include(STATIC_DIR . "sys-closed");
echo "   </td>";
echo " </tr>";

echo " <tr class='foot'>";
echo "   <td colspan='2'>" . TITLE . "</td>";
echo " </tr>";

echo "<tr style='height: 1px;'>";
echo "<td style='height: 1px; font-size: 2px;'>&nbsp;</td>";
echo "</tr>";

echo " <tr class='content'>";
echo "   <td colspan='2'>";

//echo "<a id='dsabutton' href='#' onclick='javascript:toggleDsa();'>toggle dsa</a>";
echo "<div id='dsa' style='display: none;'>";
?>



<h1>Datenschutzerklärung - victor Umfragen</h1>

<p>Wir achten und respektieren Ihre Privatsphäre.<br/>
Diese Befragung wurde unter Einhaltung sämtlicher Standards für wissenschaftliche Marktforschung erstellt und dient nicht der Geschäftsanbahnung. Die Einhaltung des Datenschutzgesetzes ist für unser Unternehmen und alle an der Umfrageerstellung beteiligten Parteien selbstverständlich und maßgeblich. Die Teilnahme an unserer Umfrage erfolgt freiwillig und anonym. Die Daten, die an uns übermittelt werden, können nicht mit Ihrer Person in Verbindung gebracht werden. Der Fragebogen enthält weder Ihren Namen noch Ihre Adresse, sofern Sie diese nicht freiwillig angeben. In keinem Fall werden erhobene Privatdaten an Drittunternehmen verkauft. 
</p>

<p>Die nachfolgende Erklärung gibt Ihnen einen Überblick darüber, wie wir diesen Schutz gewährleisten und welche Art von Daten zu welchem Zweck erhoben werden.
</p>

<p><b>Datenverarbeitung für die Auswertung der Befragungsergebnisse</b><br/>
Die Auswertung der Befragungsergebnisse erfolgt unter rein statistischen Gesichtspunkten. Informationen zu Ihrer Person wie z.B. Alter oder Geschlecht dienen lediglich dazu, gruppenspezifische Trends zu erfassen. Die Ergebnisse werden in anonymisierter Form (z.B. als Tabellen, Grafiken) an unsere Auftraggeber weitergeleitet. Für den Fall, dass ein Dankeschön für die Teilnahme an der Befragung vorgesehen ist und die Auskunftspersonen freiwillig persönliche Kontaktdaten angeben, wird für die zweckgebundene ausschließliche Verwendung der Daten garantiert.
</p>

<p><b>Datenverarbeitung auf dieser Internetseite</b><br/>
Der Provider von emotion banking garantiert die Einhaltung des Datenschutzgesetzes und des Telekommunikationsgesetzes. Demnach werden – so wie rechtlich vorgesehen – Informationen, die Ihr Browser automatisch in Server Log Files speichert, an den Provider übermittelt. 
Diese Daten sind für emotion banking in keinster Weise bestimmten Personen zuordenbar. Eine Zusammenführung dieser Daten mit anderen Datenquellen wird nicht vorgenommen. Die Daten werden zudem nach einer rein statistischen Auswertung durch den Provider wieder gelöscht.
</p>


<p><b>Cookies</b><br/>
Die Internetseiten verwenden an mehreren Stellen so genannte Cookies. Sie dienen dazu, unser Angebot nutzerfreundlicher, effektiver und sicherer zu machen. Cookies sind kleine Textdateien, die auf Ihrem Rechner abgelegt werden und die Ihr Browser speichert. Die meisten der von uns verwendeten Cookies sind so genannte „Session-Cookies“. Sie werden nach Ende Ihres Besuchs automatisch gelöscht. Cookies richten auf Ihrem Rechner keinen Schaden an und enthalten keine Viren.
</p>

<p><b>Auskunftsrecht</b><br/>
Sie haben jederzeit das Recht auf Auskunft über die bezüglich Ihrer Person gespeicherten Daten, deren Herkunft und Empfänger sowie den Zweck der Speicherung. Auskunft über die gespeicherten Daten geben wir Ihnen gerne unter den unten angeführten Kontaktdaten.
</p>

<p><b>Weitere Informationen</b><br/>
Ihr Vertrauen ist uns wichtig. Daher möchten wir Ihnen jederzeit für Fragen bezüglich der Verarbeitung Ihrer personenbezogenen Daten zu Verfügung stehen. Wenn Sie Fragen haben, die Ihnen diese Datenschutzerklärung nicht beantworten konnte oder wenn Sie zu einem Punkt vertiefte Informationen wünschen, wenden Sie sich bitte jederzeit an uns:
</p>

<p><b>Wir danken Ihnen für Ihr Mitwirken und für Ihr Vertrauen in unsere Arbeit.</b>
</p>
<?php
echo "</div>";

echo "   </td>";
echo " </tr>";

echo "<tr style='height: 1px;'>";
echo "<td style='height: 1px; font-size: 2px;'>&nbsp;</td>";
echo "</tr>";

echo " <tr class='foot'>";
echo "   <td colspan='2' style='color: lightgray; font-size: 8pt;'>";
?>
© emotion banking®<br/>
Theaterplatz 5<br/>
2500 Baden bei Wien<br/>
Telefon: +43/2252/254845<br/>
E-Mail: <a style='color: white;' href='mailto:victor@bankdesjahres.at'>victor@bankdesjahres.at</a>
<?php
echo "   </td>";
echo " </tr>";
            
echo "</table>";
echo "</body>";

closeDB($db);

//end page
?>

</html>
