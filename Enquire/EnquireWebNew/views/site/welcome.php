<?php
use yii\widgets\ActiveForm;
use yii\helpers\ArrayHelper;

/* @var $this yii\web\View */
$this->title = 'Victor 2014';
?>

<div class="content">
	<?php echo \app\models\Text::findOne($text->t_id)->text; ?>
</div>
