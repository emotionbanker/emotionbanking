<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\Form */

$this->title = 'Update Form: ';
$this->params['breadcrumbs'][] = ['label' => 'Forms', 'url' => ['index']];
$this->params['breadcrumbs'][] = ['label' => $model->f_id, 'url' => ['view', 'id' => $model->f_id]];
$this->params['breadcrumbs'][] = 'Update';
?>
<div class="form-update">

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
