<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;
use yii\helpers\ArrayHelper;

/* @var $this yii\web\View */
/* @var $model app\models\UserText */
/* @var $form yii\widgets\ActiveForm */

$banks = ['' => 'Bitte wählen Sie']+ ['0' => 'All'] + ArrayHelper::map(app\models\Bank::find()->all(),'klasse', 'bezeichnung');
$groups = ['' => 'Bitte wählen Sie']+ ['0' => 'All'] + ArrayHelper::map(app\models\Group::find()->all(),'p_id', 'bezeichnung');
$languages = ['' => 'Bitte wählen Sie'] + ['0' => 'Default']+ ArrayHelper::map(app\models\Language::find()->all(),'l_id', 'name');
$texts = ['' => 'Bitte wählen Sie'] + ArrayHelper::map(app\models\Text::find()->all(),'t_id', 'name');

?>

<div class="user-text-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'p_id')->dropDownList($groups) ?>

    <?= $form->field($model, 'b_id')->dropDownList($banks) ?>

    <?= $form->field($model, 'l_id')->dropDownList($languages) ?>

    <?= $form->field($model, 't_id')->dropDownList($texts) ?>
	<div class="hidden">
		<?= $form->field($model, 'isStart')->textInput() ?>
		<?= $form->field($model, 'isEnd')->textInput() ?>
	</div>


    <div class="form-group">
        <?= Html::submitButton($model->isNewRecord ? 'Create' : 'Update', ['class' => $model->isNewRecord ? 'btn btn-success' : 'btn btn-primary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
