<?php

use yii\helpers\Html;
use yii\widgets\DetailView;
use kartik\widgets\ActiveForm;

/* @var $this yii\web\View */
/* @var $model app\models\Form */

$this->title = 'Preview';
?>
<div class="form-view">

	<b>Sprachauswahl:</b>

	<?php $form = ActiveForm::begin();?>
	<?php
		$i = 0;
		$pos = 0;
		$question = $model->getQuestions();
		while ($pos < count($question)) {

			switch ($question[$pos]['cmd'])
			{
				case 'header':
					echo "<h3>".$question[$pos]['text']."</h3>";
					$pos++;
					break;

				case 'pagebreak':
					echo "<div class='page-break'></div>";
					$pos++;
					break;

				case 'question':

					$multi = false;
					$m = array();

					//print_r($question);


					while (
						(count($a = @explode(";", $question[$pos]['antworten'])) <= 6) &&
						(count($a = @explode(";", $question[$pos]['antworten'])) > 1) &&
						(isset($question[$pos]['antworten']) && isset($question[$pos+1]['antworten'])) &&
						($question[$pos]['antworten'] == $question[$pos+1]['antworten']) &&
						($question[$pos+1]['cmd'] == "question")
					) {
						$multi = true;

						$m[] = $question[$pos];

						$pos ++;
					}

					if ($multi) { $m[] = $question[$pos]; }

					if (!$multi) {
						//print_r($question[$pos]);
						echo \app\widgets\Question::widget([
							'questions' => [
								$question[$pos]
							],
							'num' => $pos,
							'showConditions' => true,
							'translate' => false
						]);
						//echoQuestion($all[$pos],$pos,$qu[$pos + 1], true, true);
					} else {
						echo \app\widgets\Question::widget([
							'questions' => $m,
							'num' => $pos,
							'showConditions' => true,
							'translate' => false,
							'multi' => true
						]);
						//echoMultiQuestion($m,$pos,$qu, true, true);
					}



					$pos++;

					break;
			}
		}

	?>
	<?php $form->end();?>
</div>
