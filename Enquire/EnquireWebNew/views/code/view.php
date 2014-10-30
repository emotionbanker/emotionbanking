<?php

use yii\helpers\Html;
use yii\widgets\DetailView;

/* @var $this yii\web\View */
/* @var $model app\models\Code */

$this->title = $model->z_id;
$this->params['breadcrumbs'][] = ['label' => 'Codes', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="code-view">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Update', ['update', 'id' => $model->z_id], ['class' => 'btn btn-primary']) ?>
        <?= Html::a('Delete', ['delete', 'id' => $model->z_id], [
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
            'z_id',
            'code',
            'z_b_id',
            'z_p_id',
            'used',
            'status',
        ],
    ]) ?>

</div>
