<?php

use yii\helpers\Html;
use kartik\grid\GridView;
use yii\helpers\ArrayHelper;

/* @var $this yii\web\View */
/* @var $model app\models\Bank */

$this->title = 'Zugangscodes für Bank:' . $model->b_id;
$this->params['bankName'] = $model->b_id;
$this->params['userGroups'] = ArrayHelper::map(\app\models\Group::find()->all(),'p_id','bezeichnung');
$this->params['breadcrumbs'][] = ['label' => 'Banken', 'url' => ['index']];
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="bank-view">
	<?= GridView::widget([
	'dataProvider' => $dataProvider,
	'columns' => [
		[
			'label' => 'Code',
			'attribute' => 'code',
			'value'=>function ($model, $key, $index, $widget) {
				return $this->params['bankName'] . str_pad($model->z_p_id, 3, '0', STR_PAD_LEFT) . $model->code;
			},
			'format' => 'raw'
		],
		[
			'label' => 'Benutzergruppe',
			'attribute' => 'z_p_id',
			'value'=>function ($model, $key, $index, $widget) {
				return $this->params['userGroups'][$model->z_p_id];
			},
			'format' => 'raw'
		],
		[
			'label' => 'Status',
			'attribute' => 'status',
			'value'=>function ($model, $key, $index, $widget) {
				return ($model->status)  ? 'füllt gerade aus/noch nicht komplett ausgefüll' : 'noch nicht verwendet';
			},
			'format' => 'raw'
		],
		[
			'class' => 'yii\grid\ActionColumn',
			'template' => '{delete}',
			'buttons' => [
				'delete' => function($url, $model, $key) {
					return Html::a('<span class="glyphicon glyphicon-trash"></span>', '/bank/' . $model->z_b_id . '/delete-code/' . $model->z_id, [
						'title' => Yii::t('yii', 'Delete'),
						'data-confirm' => Yii::t('yii', 'Are you sure you want to delete this item?'),
						'data-method' => 'post',
						'data-pjax' => '0',
					]);
				}
			]
		],
	],
]);
?>
</div>
