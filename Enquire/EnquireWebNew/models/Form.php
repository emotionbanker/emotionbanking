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

						$entry = Question::find()->where(['fr_id' => $cmd])->asArray()->one();
						if (! $entry) {
							return 0;
						}

						$entry['cmd'] = "question";
						$entry['condition'] = $condition;
						$entry['pos'] = $qcount;

						if ($hidden) {
							$entry['hidden'] = true;
						} else {
							$entry['hidden'] = false;
						}

						if ($aslist) {
							$entry['aslist'] = true;
						} else {
							$entry['aslist'] = false;
						}

						$qcount++;

						if (strpos($cmd, "!")) //default
						{
							$oal = explode("!", $cmd);
							$entry2 = Question::find()->where(['fr_id' => $oal[0]])->asArray()->one();
							if (isset($entry2['frage'])) {
								$entry['frage'] = $entry2['frage'];
								$entry['dset'] = $oal[1];
							}

						}

						if (strpos($cmd, "/")) //alias!
						{
							$al = explode("/", $cmd);
							$al = QuestionAlias::find()->where(['a_fr_id' => $al[0], 'al_id' => $al[1]])->asArray()->one();
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

	private function getQuestionByPosition($questions, $position)
	{
		foreach ($questions as $q) {
			if (isset($q['pos']) && $q['pos'] == $position) {
				return $q;
			}
		}
	}

	private function answerToDefault($qid, $answer)
	{

		if (is_array($answer)) {
			$res = array();
			foreach ($answer as $a) {
				$res[] = $this->answerToDefault($qid,$a);
			}
			return $res;
		} else {

			if (trim($answer) == "") {
				return "";
			}

			//$qt = getTranslation($_SESSION['user']['lang'],$qid);
			$qt = Question::findOne($qid)->toArray();
			$tas = explode(";", $qt['antworten']);

			$oas = explode(";", $qt['antworten']);

			for ($i = 0; $i < count($tas); $i++) {
				if ($tas[$i] == $answer) {
					return $oas[$i];
				}
			}
			return $answer;
		}
	}

	private function getAnswerId($q, $a)
	{
		$c = 0;
		foreach (explode(";", $q['antworten']) as $i)
		{
			if ($i == $a) return $c;
			$c++;
		}
		return "err";
	}


	public function getPos($list, $qp)
	{
		if ($qp == 0) return 0;
		$c = 0;
		foreach ($list as $q) {
			if (isset($q['pos']) && $q['pos'] != $qp) {
				$c++;
			} else if(isset($q['pos']) && $q['pos'] == $qp){
				break;
			} else {
				$c++;
			}
		}

		while ($c > 0 && $list[$c]['cmd'] != 'pagebreak') {
			$c--;
		}

		if ($list[$c]['cmd'] == 'pagebreak') {
			$c++;
		}

		while ($c < count($list) && $list[$c]['cmd'] != 'pagebreak'){
			$c++;
		}

		if ($list[$c]['cmd'] == 'pagebreak') {
			$c++;
		}

		return $c;
	}

	private function checkSubCondition($condition)
	{
		$q['condition'] = $condition;

		if ($q['condition'] == "") return true;

		$negate = false;
		if ($condition[0] == "!")
		{
			$q['condition'] = substr($q['condition'],1);
			$negate = true;
		}

		$dat = explode(".", $q['condition']);

		$result = Result::findOne(['e_fr_id' => $dat[0], 'e_z_id' => Yii::$app->session['anketData']['code']['z_id']]);

		//$quer = "select a_id, antwort from ".RES." where e_fr_id='".$dat[0]."' and e_z_id='".$user['uid']."'";

		$question = Question::findOne($dat[0])->toArray();

		$aid = $result->a_id;
		$answers = $result->antwort;
		$alist = array();

		if (trim($answers) == "") {
			$alist[] = $aid;
		} else {
			$questionAnswers = explode(";", $question['antworten']);
			$userAnswers = explode(";", $answers);

			for ($i = 0; $i < count($questionAnswers); $i++) {
				foreach ($userAnswers as $userAnswer) {
					if ($userAnswer == $questionAnswers[$i]) {
						$alist[] = $i;
					}
				}
			}
		}

		$ok = false;
		foreach ($alist as $a) {
			if ( ($a == ($dat[1]-1)) ) {
				if (isset($a)) {
					$ok = true;
				}
			}
		}

		if ($negate) return ! $ok;
		else return $ok;
	}


	public function checkCondition($condition)
	{
		$okConj = true;

		$conjs = explode("&", $condition);

		foreach ($conjs as $conj) {
			$diss = explode("|", $conj);

			$okDisj = false;
			foreach($diss as $dis) {
				if ($this->checkSubCondition($dis)) {
					$okDisj = true;
				}
			}

			if (!$okDisj) {
				$okConj = false;
			}
		}

		return $okConj;
	}

	public function getQuestionsCount($list)
	{
		$c = 0;
		foreach ($list as $q) {
			if ($q['cmd'] == "question") $c++;
		}
		return $c;
	}


	public function saveAnswers($code, $answers)
	{
		$questions = $this->getQuestions();

		foreach ($answers as $key => $answer) {
			$aq = $this->getQuestionByPosition($questions,$key);

			$fr_id = $aq['fr_id'];

			$answer = $this->answerToDefault($fr_id, $answer);

			if (is_array($answer)) {
				$answer = implode(";", $answer);
			}

			$count = Result::find()->andWhere(['e_z_id' => $code['z_id'], 'e_fr_id' => $fr_id])->count();

			if (! $count) {

				if (!trim($answer)) {
					if (isset($aq['dset'])) {
						$aid = $aq['dset'];
					} else {
						$aid = "err";
						$answer="";
					}
				} else {
					$aid = $this->getAnswerId($aq, $answer);
				}

				if ($aq['display'] == "radio" && $aid !== "err") {
					$result = new Result();
					$result->e_z_id = $code['z_id'];
					$result->e_fr_id = $fr_id;
					$result->a_id = $aid;
					$result->save();
				} else {
					$result = new Result();
					$result->e_z_id = $code['z_id'];
					$result->e_fr_id = $fr_id;
					$result->antwort = $answer;
					$result->save();
				}
			}
			$status = $key;
		}

		$codeObj = Code::findOne($code['z_id']);
		$codeObj->status = $status;
		$codeObj->save();

		return $status;
	}
}
