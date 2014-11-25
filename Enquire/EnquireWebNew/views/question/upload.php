<?php

use yii\helpers\Html;
use kartik\grid\GridView;
use yii\widgets\ActiveForm;
use kartik\widgets\FileInput;

/* @var $this yii\web\View */
/* @var $searchModel app\models\search\QuestionSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Import Fragen';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="question-index">
	<div class="bs-callout bs-callout-warning">
		<h4>ACHTUNG: Quelldatei muss eine Textdatei im Format</h4>
		<p>Frage@Typ@Antwort1;Antwort2;AntwortN@Suchkürzel</p>
	</div>

	<?php if ($imported): ?>
		<h3 style="color: #008000"><?php echo $imported;?> Fragen in die Datenbank aufgenommen, <?php echo $dropped;?> fragen doppelt</h3>
	<?php endif;?>

	<div class="upload-field">
		<?php
			$form = ActiveForm::begin(['options' => ['enctype'=>'multipart/form-data']]); //important
			echo FileInput::widget([
				'name' => 'filename',
				'options'=>[
					'multiple' => false
				],
				'pluginOptions' => [
					'showPreview' => false,
					'showCaption' => true,
					'showRemove' => true,
					'showUpload' => true
				]

			]);
		?>
	</div>
	<?php ActiveForm::end(); ?>



</div>
