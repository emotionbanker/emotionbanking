<?php

/**

  administration
  
**/


//defaults, directories
require_once("./settings.php");


//begin db

$db = initDB();

if(!connectDB($db))
{
  debug($db['msg']);
  die();
}

session_cache_expire(SESSION_EXPIRE);
session_save_path(SESSION_PATH);


session_start();

define (U09A, true);
//if ($u09a) define (U09A, true);
//else if ($_SESSION['u09a']) define (U09A, $_SESSION['u09a']);

//$_SESSION['u09a'] = U09A;

$r = $_REQUEST;
reset($r);
$key = key($r);
$v = $_REQUEST[$key];
reset($r);
$k = key($r);

if (!$_SESSION['isadmin'] && $k == "login")
{
  if ($r['user'] == USERNAME && $r['pass'] == PASSWORD)
  {
    $_SESSION['isadmin'] = true;
    $override = "loggedin";
  }
  else
    $override = "wrongpassword";
}
if ($k == "logout")
  $_SESSION['isadmin'] = false;

if ($k == "opensys")
  openSystem();

if ($k == "closesys")    
  closeSystem();

// begin html header
?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" >
  <head>
     <title><?php echo TITLE; ?> - administration</title>
     <meta http-equiv="Content-type" content="text/html; charset=iso-8859-1" />
     <link rel="stylesheet" type="text/css" href="./styles/admin/style.css" />
     <script language="javascript" type="text/javascript">
     function addText(text, caller) 
     {
	     document.editform.reihenfolge.value += text;
	     caller.className='used';
     }
</script>
  </head>

<?php

//begin page

echo "<body>";
echo "<table class='main' cellspacing='0' cellpadding='0'>";
echo "  <tr class='head'>";
//echo "    <td style='width:60px; overflow:hidden;'><img style='' src='./images/headImage.png' /></td>";
echo "    <td colspan=2>";
echo "   <span style='font-size: 32pt; color: #FFFFFF; padding: 50px;'>    Administration</span>";
echo "    </td>";
echo "  </tr>";
      
echo "  <tr class='head2'>";
echo "    <td class='quicklinks' style='text-align: left;'>";

if  ($_SESSION['isadmin'])
{
    echo "admin, " . DB_USER . "@" . DB_HOST;
    echo "<br/>";
    echo DB_ID;
}
else
  echo "&nbsp;";

 
echo "    </td>";
echo "    <td colspan='2' class='quicklinks'><a href='?' />startseite</a>";
if  ($_SESSION['isadmin'])
  echo " | <a href='?logout' />abmelden</a> | ";

if ($_SESSION['isadmin'])
{
  if (sysClosed())
    echo "system gesperrt";
  else
    echo "system freigegeben";
}
echo "    </td>";
echo "  </tr>";

echo "  <tr class='content'>";
echo "   <td class='nav'>";

if  (!$_SESSION['isadmin'])
  echo panelLogin();
else
{
  echo panelFragen();
  echo panelBanken();
  echo panelUserg();
  echo panelFragebogen();
  echo panelCodes();
  echo panelIndiv();
  echo panelLanguages();
  echo panelSystem();
}

echo "   </td>";
echo "   <td class='content'>";

if (!$_SESSION['isadmin'] && !isset($override))
  $override = "start";

if (isset($override))
  $k = $override;
  
switch($k)
{   
  case "del-alias":
    deleteAlias($r['aid']);
    setAliasForm($r['bank'], $r['do'], $r['original'], $r['alias'], $r['aid']);
    break;
    
  case "set-alias":
    setAliasForm($r['bank'], $r['do'], $r['original'], $r['alias'], $r['aid']);
    break;
    
  case "choose-alias":
    chooseBankAliasForm();
    break;
  
  case "meta-stats":
    showMetaStats($r['meta-stats']);
    break;
    
  case "drop-question-alias":
    dropQAlias($r['drop-question-alias'], $r['alias']);
    showQAlias($r['drop-question-alias']);
    break;
    
  case "set-question-alias":
    setQAlias($r['set-question-alias'], $r['aid'], $r['alias']);
    break;
    
  case "question-alias":
    showQAlias($r['question-alias']);
    break;
    
	case "preview-form":
		previewForm($r['form']);
	  break;
	  
	case "indiv-styles":
	  showAvailableStyles();
	  styleSettings($r['save'], $r['delU'], $r['delB'], $r['default-style'], $r['new-user'], $r['new-bank'], $r['new-style']);
	  break;
	  
	case "indiv-texts":
	  textSettings($r['save'], $r['delU'], $r['delB'], $r['delL'], $r['default-text'], $r['new-user'], $r['new-bank'], $r['new-text'], $r['new-lang']);
	  break;
	  
	case "indiv-etexts":
	  etextSettings($r['save'], $r['delU'], $r['delB'], $r['delL'], $r['default-text'], $r['new-user'], $r['new-bank'], $r['new-text'], $r['new-lang']);
	  break;
	  
  case "start":
    include(STATIC_DIR . "admin-start");
    break;
    
  case "wrongpassword":
    include(STATIC_DIR . "wrong-password");
    break;
  
  case "loggedin":
    include(STATIC_DIR . "admin-welcome");
    break;
    
  case "create-bank":
    if ($v)
    {
      if (!createBank($r['bezeichnung'], $r['id'], $r['klasse']))
        echo ('fehler beim erstellen der bank (bank unter umst�nden schon in der datenbank)');
      else
        echo "bank wurde erstellt";
      echoBankList(getBankList(),true);
    }
    else 
      createBankForm();
    break;
  
  case "new-lang":
    if ($v)
    {
    	if (!createLang($r['name'], $r['short']))
    	echo ('fehler beim erstellen der sprache (bank unter umst�nden schon in der datenbank)');
      else
        echo "sprache wurde erstellt";
      echoLangList(getLangList());
    }
    else
      createLangForm();
      
    break;
      
  case "list-lang":
    echoLangList(getLangList());
    break;
    
  case "edit-lang":
  	$lang = getLangInfoByID($r['edit-lang']);
  	createLangForm(true,$r['edit-lang'], $lang['name'], $lang['short']);
    break;
    
  case "update-lang":
  	if (!updateLang($r['name'], $r['update-lang'], $r['short']))
      echo ('fehler beim bearbeiten der sprache');
    else
      echo "�nderungen wurden gespeichert";
    echoLangList(getLangList());
    break;
    
  case "delete-lang":
  	if ($r['accept'] && $r['submit'] == "ja")
    {
      deleteLang($v);
      echo "sprache wurde gel�scht";
      echoLangList(getLangList());
    }
    else if ($v && $r['submit'] == "nein")
      echoLangList(getLangList());
    else
      areyousure("?delete-lang=" . $v . "&accept=true", "sprache l�schen", "achtung! diese sprache wird gel�scht!");
    break;
    
  case "translate":
  $sdata = array();
    $sdata['fortfahren'] = $r['fortfahren'];
    $sdata['wenn'] = $r['wenn'];
    translate($v, $r['q'], $r['action'], $r['text'], $r['answers'], $sdata);
    break;
  
  case "lock-bank":
    //lockUnlock($v);
    showLocks($v, $r['do'], $r['uid']);
    break;
    
  case "list-bank":
    echoBankList(getBankList(),true);
    break;
    
  case "edit-bank":
    $bank = getBankInfoByID($r['edit-bank']);
    createBankForm(true,$r['edit-bank'], $bank['bez'], $bank['class']);
    break;
    
  case "update-bank":
    if (!updateBank($r['bezeichnung'], $r['update-bank'], $r['klasse']))
      echo ('fehler beim bearbeiten der bank');
    else
      echo "�nderungen wurden gespeichert";
    echoBankList(getBankList(),true);
    break;
    
  case "delete-bank":
    if ($r['accept'] && $r['submit'] == "ja")
    {
      deleteBank($v);
      echo "bank wurde gel�scht";
      echoBankList(getBankList(),true);
    }
    else if ($v && $r['submit'] == "nein")
      echoBankList(getBankList(),true);
    else
      areyousure("?delete-bank=" . $v . "&accept=true", "bank l�schen", "achtung! diese bank wird gel�scht. existieren zugangscodes f�r diese bank kann dies zu systemfehlern f�hren!");
    break;
    
  case "create-userg":
    if ($v)
    {
      if (!createUserg($r['bezeichnung'], $r['id']))
        echo ('fehler beim erstellen der benutzergruppe: ' . mysql_error());
      else
        echo "benutzergruppe wurde erstellt";
      echoUsergList(getUsergList());
    }
    else
      createUsergForm();
    break;
    
   case "delete-userg":
    if ($r['accept'] && $r['submit'] == "ja")
    {
      deleteUserg($v);
      echo "benutzergruppe wurde gel�scht";
      echoUsergList(getUsergList());
    }
    else if ($v && $r['submit'] == "nein")
      echoUsergList(getUsergList());
    else
      areyousure("?delete-userg=" . $v . "&accept=true", "benutzergruppe l�schen", "achtung! diese benutzergruppe wird gel�scht. existieren zugangscodes oder frageb�gen f�r diese benutzergruppe kann dies zu systemfehlern f�hren!");
    break;
    break;

  case "edit-userg":
    $userg = getUsergByID($r['edit-userg']);
    createUsergForm(true,$r['edit-userg'],$userg);
    break;
      
  case "update-userg":
    if (!updateUserg($v, $r['bezeichnung']))
      echo ('fehler beim bearbeiten der benutzergruppe');
    else
      echo "�nderungen wurden gespeichert";
    echoUsergList(getUsergList());
    break;
    
  case "list-userg":
    echoUsergList(getUsergList());
    break;
    
  case "reset":
    if ($v && $r['submit'] == "ja")
    {
      createDB($db);
      echo "datenbank zur�ckgesetzt";
    }
    else if ($v)
      include(STATIC_DIR . "admin-welcome");
    else
      areyousure("?reset=true", "datenbank zur�cksetzen", "achtung! alle daten werden dabei gel�scht!");
    break;
    
  case "create-codes":
    if ($v)
    {
      echoCodesByBank(createCodes($r['bank'], $r['userg'], $r['anz']),$r['bank'],true);
    }
    else
      createCodesForm();
    break;
  
  case "codes-bank":
    echoCodesByBank(getCodesByBank($r['codes-bank']),$r['codes-bank']);
    break;
    
  case "del-code":
  	echo "Benutzer " . $r['del-code'] . " inkl. Antworten wirklich l�schen?<br>";
  	echo "<a href='?do-del-code=" . $r['del-code'] . "'>l�schen</a>";
    break;
    
  case "do-del-code":
  	query("delete from " . ZUG . " where z_id='".$r['do-del-code']."'");
  	query("delete from " . RES . " where e_z_id='".$r['do-del-code']."'");
    break;
  
  case "create-question":
    if ($v)
    {
      createQuestion($r['text'], $r['display'], $r['answers'], $r['search']);
      echo "frage wurde gespeichert";
      echoQuestionList(getQuestionList());      
    }
    else
      createQuestionForm();
    break;
    
  case "list-question":
    if ($v == "search")
    {
      echoQuestionList(getQuestionListBySearch($r['search']));
    }
    else
      echoQuestionList(getQuestionList());
    break;
    
  case "edit-question":
    $q = getQuestionByID($r['edit-question']);
    createQuestionForm(true,$r['edit-question'],$q['question'], $q['display'], $q['answers'], $q['search']);
    break;
      
  case "update-question":
    if (!updateQuestion($v, $r['text'],$r['display'], $r['answers'], $r['search']))
      echo ('fehler beim bearbeiten der frage');
    else
      echo "�nderungen wurden gespeichert";
    echoQuestionList(getQuestionList());
    break;
    
  case "delete-question":
    if ($r['accept'] && $r['submit'] == "ja")
    {
      deleteQuestion($v);
      echo "frage wurde gel�scht";
      echoQuestionList(getQuestionList());
    }
    else if ($v && $r['submit'] == "nein")
      echoQuestionList(getQuestionList());
    else
      areyousure("?delete-question=" . $v . "&accept=true", "frage l�schen", "achtung! diese frage wird gel�scht. ist diese frage teil eines fragebogens kann dies zu systemfehlern f�hren!");
    break;
    break;
    
  case "choose-form":
    chooseFormForm();
    break;
    
  case "form-edit":
    formEdit($r['class'], $r['userg'], $r['q'], $r['reihenfolge'],$r['search']);
    break;
  
  case "opensys":
    echo "system freigegeben";
    break;
    
  case "closesys":
    echo "system gesperrt";
    break;
  
  case "stats":
    echoSystemStats();
    break;
    
  case "upload-translation":
    if ($v)
    {
    	uploadTranslation($r['data'],$r['lang']);
    }
    else
    {
    	echoUploadTranslationForm();
    }
    break;
    
  case "upload-question":
    if ($v)
    {
      uploadQuestion($r['data']);
    }
    else
    {
      echoUploadQuestionForm();
    }
    break;
    
  case "stat-bank";
    echoBankStats();
    break;
    
  case "backup";
    backup();
    break;
    
  case "restore":
    if ($v)
    {
      restore($r['data']);
    }
    else
    {
      restoreForm();
    }
    break;
    
  case "drop-results";
    if ($v && $r['submit'] == "ja")
    {
      query("delete from ".ZUG);
      query("delete from ".RES);
      echo "ergebnisse gel�scht";
    }
    else if ($v)
      include(STATIC_DIR . "admin-welcome");
    else
      areyousure("?drop-results=true", "ergebnisse l�schen", "achtung! alle ergebnisdaten werden dabei gel�scht! NUR NACH ENDE DER TESTPHASE AKTIVIEREN, IN KEINEM FALL W�HREN DEM BETRIEB!");
    break;
    
  default:
    include(STATIC_DIR . "admin-welcome");
    break;
}


echo "   </td>";
echo " </tr>";

echo " <tr class='foot'>";
echo "   <td colspan='2'>" . TITLE . "</td>";
echo " </tr>";
            
echo "</table>";
echo "</body>";



closeDB($db);

//end page
?>

</html>