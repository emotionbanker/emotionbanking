<?php

use yii\helpers\Html;
use kartik\grid\GridView;
use dosamigos\multiselect\MultiSelect;
use yii\helpers\ArrayHelper;

/* @var $this yii\web\View */
/* @var $model app\models\Bank */

$this->title = 'Platzhalter';
$this->params['breadcrumbs'][] = ['label' => 'Banken', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
$data = [0=>'Please select'] + ArrayHelper::map(\app\models\Bank::findAll(['>', 'b_id', 0]), 'b_id', 'bezeichnung');
?>
<div class="bank-view">
    <?php if (isset($error)): ?>
        <div class="alert alert-danger alert-dismissible" role="alert">
            <?php echo $error; ?>
        </div>
    <?php endif;?>
	<form action="/bank/placeholders/set-alias">
		<div class="form-group">
			<label for="">Platzhalter setzen für</label>
			<?= MultiSelect::widget([
				'data' => $data,
				'name' => 'bank',
				'clientOptions' => [
					'maxHeight' => 300,
					'enableCaseInsensitiveFiltering' => true,
					'buttonWidth' => '400px'
				],
				'options' => [
					'multiple' => true
				]
			]) ?>
		</div>
		<button class="btn btn-success">Platzhalter für diese Bank bearbeiten</button>
	</form>
	<style>
		label {
			display: block;
		}
		.dropdown-menu > li > a {
			padding: 8px 30px;
		}
	</style>
</div>
