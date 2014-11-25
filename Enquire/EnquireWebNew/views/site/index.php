<?php
use yii\widgets\ActiveForm;
use yii\helpers\ArrayHelper;

/* @var $this yii\web\View */
$this->title = 'Victor 2014';
$languages = ['default' => 'Default']+ ArrayHelper::map(app\models\Language::find()->all(),'l_id', 'name');
?>

<div class="form-div">

	<?php if ($error): ?>
		<div class="alert alert-danger" role="alert">
			<?php echo $error; ?>
		</div>
	<?php endif;?>

	<h4>Wenn Sie einen persönlichen Code für das Umfragesystem haben, geben Sie diesen bitte hier ein:</h4>
	<?php $form = ActiveForm::begin();?>
		<?php echo $form->field($model, 'code')->textInput();?>
		<?php echo $form->field($model, 'language')->dropDownList($languages);?>
		<input type="submit" class="btn btn-primary btn-block" value="Umfrage beginnen">
	<?php ActiveForm::end();?>
</div>
