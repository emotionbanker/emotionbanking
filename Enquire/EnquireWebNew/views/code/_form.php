<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;
use \app\models\Bank;
use \app\models\Group;
use yii\helpers\ArrayHelper;

/* @var $this yii\web\View */
/* @var $model app\models\Code */
/* @var $form yii\widgets\ActiveForm */


$banks =  ['' => 'Bitte wählen'] + ArrayHelper::map(Bank::find()->all(), 'b_id', 'bezeichnung');
$groups = ['' => 'Bitte wählen'] + ArrayHelper::map(Group::find()->all(), 'p_id', 'bezeichnung');

?>

<div class="code-form">
	<h4>Für welche benutzer wollen sie codes erzeugen?</h4>
    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'z_b_id')->dropDownList($banks) ?>

    <?= $form->field($model, 'z_p_id')->dropDownList($groups) ?>
    <?= $form->field($model, 'count')->textInput() ?>

    <div class="form-group">
        <?= Html::submitButton($model->isNewRecord ? 'Create' : 'Update', ['class' => $model->isNewRecord ? 'btn btn-success' : 'btn btn-primary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
