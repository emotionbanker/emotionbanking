<?php

use app\assets\MultipleSelectAsset;
use yii\helpers\Html;
use yii\widgets\ActiveForm;
use yii\helpers\ArrayHelper;
use dosamigos\multiselect\MultiSelect;
MultipleSelectAsset::register($this);

/* @var $this yii\web\View */
/* @var $model app\models\UserText */
/* @var $form yii\widgets\ActiveForm */

$banks = ['0' => 'All'] + ArrayHelper::map(app\models\Bank::find()->all(),'klasse', 'bezeichnung');
$groups = ['0' => 'All'] + ArrayHelper::map(app\models\Group::find()->all(),'p_id', 'bezeichnung');
$languages = ['0' => 'Default']+ ArrayHelper::map(app\models\Language::find()->all(),'l_id', 'name');
$texts = ArrayHelper::map(app\models\Text::find()->all(),'t_id', 'name');

?>

<div class="user-text-form">

    <?php $form = ActiveForm::begin(); ?>

    <!--<?= $form->field($model, 'p_id')->dropDownList($groups) ?>-->

    <div class="form-group">
        <label for="">Benutzer</label>
        <?= MultiSelect::widget([
            'data' => $groups,
            'name' => 'UserText[p_id]',
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

    <!--<?= $form->field($model, 'b_id')->dropDownList($banks) ?>-->

    <div class="form-group">
        <label for="">Bank</label>
        <?= MultiSelect::widget([
            'data' => $banks,
            'name' => 'UserText[b_id]',
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

    <style>
        label {
            display: block;
        }
        .dropdown-menu > li > a {
            padding: 8px 30px;
        }
    </style>

</div>