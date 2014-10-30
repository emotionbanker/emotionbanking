<?php

use yii\helpers\Html;
use yii\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel app\models\BankSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Banken';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="bank-index">

    <p>
        <?= Html::a('Neue Banken', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'b_id',
            'bezeichnung',
            'klasse',

            [
				'class' => 'yii\grid\ActionColumn',
				'template' => '{codes} {update} {delete} {lock} {statistic}',
				'buttons' => [
					'codes' => function($url, $model, $key) {
						return Html::a('<i class="fa fa-barcode"></i>', '/bank/' . $model->b_id . '/codes', [
							'title' => Yii::t('yii', 'Zugangscodes'),
						]);
					},
					'lock' => function($url, $model, $key) {
						if (! $model->isLocked()) {
							$icon = 'fa-lock';
							$text = 'sperren';
							$color = 'red';
						} else {
							$icon = 'fa-unlock';
							$text = 'sperren';
							$color = 'green';
						}
						return Html::a('<i style="color:'.$color.'" class="fa ' . $icon . '"></i>', '/bank/' . $model->b_id . '/lock', [
							'title' => Yii::t('yii', $text),
						]);
					},
					'statistic' => function($url, $model, $key) {
						return Html::a('<i class="fa fa-area-chart"></i>', '/bank/' . $model->b_id . '/statistic', [
							'title' => Yii::t('yii', 'Statistik'),
						]);
					}
				]
			],
        ],
    ]); ?>

</div>
