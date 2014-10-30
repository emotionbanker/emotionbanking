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
					echo "<h4>".$question[$pos]['text']."</h4>";
					$pos++;
					break;

				case 'pagebreak':
					echo "<div class='page-break'></div>";
					$pos++;
					break;

				case 'question':

					$multi = false;
					$m = array();

					while (
						(count($a = @explode(";", $question[$pos][2])) <= 6) &&
						(count($a = @explode(";", $question[$pos][2])) > 1) &&
						($all[$pos][2] == $question[$pos+1][2]) &&
						($all[$pos+1]['cmd'] == "question")
					) {
						$multi = true;

						$m[] = $all[$pos];

						$pos ++;
					}

					if ($multi) { $m[] = $question[$pos]; }

					if (!$multi) {
						print_r($question[$pos]);
						//echoQuestion($all[$pos],$pos,$qu[$pos + 1], true, true);
					} else {
						//echoMultiQuestion($m,$pos,$qu, true, true);
					}



					$pos++;

					break;
			}
		}

	?>
	<?php $form->end();?>
</div>
