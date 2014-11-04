<?php

use yii\helpers\Html;
use yii\widgets\DetailView;

/* @var $this yii\web\View */
/* @var $model app\models\UserText */

$this->title = $model->ut_id;
$this->params['breadcrumbs'][] = ['label' => 'User Texts', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="user-text-view">

    <p>
        <?= Html::a('Update', ['update', 'id' => $model->ut_id], ['class' => 'btn btn-primary']) ?>
        <?= Html::a('Delete', ['delete', 'id' => $model->ut_id], [
            'class' => 'btn btn-danger',
            'data' => [
                'confirm' => 'Are you sure you want to delete this item?',
                'method' => 'post',
            ],
        ]) ?>
    </p>

    <?= DetailView::widget([
        'model' => $model,
        'attributes' => [
            'ut_id',
            'p_id',
            'b_id',
            'l_id',
            't_id',
            'isStart',
            'isEnd',
        ],
    ]) ?>

</div>
