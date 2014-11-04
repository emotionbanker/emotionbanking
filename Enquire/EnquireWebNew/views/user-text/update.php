<?php

use yii\helpers\Html;

/* @var $this yii\web\View */
/* @var $model app\models\UserText */

$this->title = 'Update User Text';
$this->params['breadcrumbs'][] = ['label' => 'User Texts', 'url' => ['/user-text/index/'. ($model->isStart ? 'start' : 'end')]];
$this->params['breadcrumbs'][] = 'Update';
?>
<div class="user-text-update">

    <?= $this->render('_form', [
        'model' => $model,
    ]) ?>

</div>
