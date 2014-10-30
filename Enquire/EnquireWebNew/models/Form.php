<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "{{%fragebogen}}".
 *
 * @property integer $f_id
 * @property string $f_klasse
 * @property integer $f_p_id
 * @property string $reihenfolge
 * @property string $history
 */
class Form extends \yii\db\ActiveRecord
{
    /**
     * @inheritdoc
     */
    public static function tableName()
    {
        return '{{%fragebogen}}';
    }

    /**
     * @inheritdoc
     */
    public function rules()
    {
        return [
            [['f_klasse', 'f_p_id'], 'required'],
            [['f_p_id'], 'integer'],
            [['reihenfolge', 'history'], 'string'],
            [['f_klasse'], 'string', 'max' => 60]
        ];
    }

    /**
     * @inheritdoc
     */
    public function attributeLabels()
    {
        return [
            'f_id' => 'F ID',
            'f_klasse' => 'Bank',
            'f_p_id' => 'Benutzergruppen',
            'reihenfolge' => 'Reihenfolge',
            'history' => 'History',
        ];
    }

	public function getQuestions()
	{
		$count = 1;
		return $this->parseQuestions($this->reihenfolge, ";", '', $count);
	}

	private function parseQuestions($text, $separator, $condition="", &$qcount)
	{
		$data = explode($separator, trim($text));
		$tmp = array();

		foreach ($data as $val)
		{
			$entry = array();
			$cmd = trim($val);
			$hidden = false;
			$aslist = false;

			if ($cmd != "")
			{
				switch($cmd[0])
				{
					case "#":
						$entry['cmd'] = "header";
						$entry['text'] = substr($cmd, 1);
						$entry['condition'] = $condition;
						$tmp[] = $entry;
						break;

					case "@":
						$entry['cmd'] = "pagebreak";
						$entry['condition'] = $condition;
						$tmp[] = $entry;
						break;

					case "w":
						$cond = array();
						$stat = "";
						for ($i = 4; $i < strlen($cmd); $i++)
						{
							if ($cmd[$i] == "(")
							{
								if ($stat == "condition") $stat = "commands";
								else $stat = "condition";
							}

							if ($cmd[$i] != "(" && $cmd[$i] != ")")
							{
								if (!isset($cond[$stat])) {
									$cond[$stat] = '';
								}
								$cond[$stat] .= $cmd[$i];
							}

						}

						$sub = $this->parseQuestions($cond['commands'], ",", $cond['condition'], $qcount);


						foreach ($sub as $entry)
						{
							$tmp[] = $entry;
						}
						break;

					case "H":
					case "L":
						$prefix = $cmd[0];
						$cmd = substr($cmd,1);
						if ($prefix == "H") $hidden = true;
						if ($prefix == "L") $aslist = true;
					default:
/*						$result = query("select frage, display, antworten, fr_id, suche from ".FRAGE." where fr_id = '".$cmd."'");

						if (!$entry = mysql_fetch_row($result))
							return 0;*/

						$entry = (array) Question::findOne($cmd);
						if (! $entry) {
							return 0;
						}

						$entry['cmd'] = "question";
						$entry['condition'] = $condition;
						$entry['pos'] = $qcount;
						if ($hidden)
						{
							$entry['hidden'] = true;
						}
						if ($aslist)
						{
							$entry['aslist'] = true;
						}
						$qcount++;

						if (strpos($cmd, "!")) //default
						{
							$oal = explode("!", $cmd);
/*							$result2 = query("select frage, display, antworten, fr_id, suche from ".FRAGE." where fr_id = '".$oal[0]."'");

							$entry2 = mysql_fetch_row($result2);*/
							$entry2 = (array) Question::findOne($oal[0]);
							if (isset($entry2[0])) {
								$entry[0] = $entry2[0];
								$entry['dset'] = $oal[1];
							}

						}

						if (strpos($cmd, "/")) //alias!
						{
							$al = explode("/", $cmd);
							$al = (array) QuestionAlias::findOne(['a_fr_id' => $al[0], 'al_id' => $al[1]]);
							if ($al) $entry[0] = $al;
						}
						$tmp[] = $entry;
						break;
				}
			}
		}

		$data = $tmp;



		return $data;
	}
}
