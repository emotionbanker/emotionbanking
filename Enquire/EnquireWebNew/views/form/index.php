<?php

use yii\helpers\Html;
use yii\helpers\ArrayHelper;
use app\models\search\QuestionSearch;
use kartik\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel app\models\FormSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Fragebögen';
$this->params['breadcrumbs'][] = $this->title;


?>
<div class="form-index">

    <p>
        <?= Html::a('Neue fragebögen', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            'f_id',
			[
				'attribute' => 'f_klasse',
				'filterType'=>GridView::FILTER_SELECT2,
				'filter'=>ArrayHelper::map(app\models\Bank::find()->all(),'klasse', 'bezeichnung'),
				'filterWidgetOptions'=>[
					'pluginOptions'=>['allowClear'=>true],
				],
				'value'=>function ($model, $key, $index, $widget) {
					 $bank = app\models\Bank::findOne(['klasse' => $model->f_klasse]);
					return $bank ? $bank->bezeichnung : '';
				},
				'filterInputOptions'=>['placeholder'=>'Bitte wählen Sie'],
				'format'=>'raw'
			],
			[
				'attribute' => 'f_p_id',
				'filterType'=>GridView::FILTER_SELECT2,
				'filter'=>ArrayHelper::map(app\models\Group::find()->all(),'p_id', 'bezeichnung'),
				'filterWidgetOptions'=>[
					'pluginOptions'=>['allowClear'=>true],
				],
				'value'=>function ($model, $key, $index, $widget) {
					$group =  \app\models\Group::findOne($model->f_p_id);
					return $group ? $group->bezeichnung : $model->f_p_id;
				},
				'filterInputOptions'=>['placeholder'=>'Bitte wählen Sie'],
				'format'=>'raw'
			],
			[
				'attribute' => 'reihenfolge',
				'value'=>function ($model, $key, $index, $widget) {
					return mb_substr($model->reihenfolge, 0, 100) . '...';
				},
			],

            [
				'class' => 'yii\grid\ActionColumn',
				'buttons' => [
					'view' => function ($url, $model) {
						return Html::a('<span class="glyphicon glyphicon-eye-open"></span>', $url, [
							'title' => Yii::t('yii', 'View'),
							'data-pjax' => '0',
							'target' => '_blank'
						]);
					}
				]
			],
        ],
    ]); ?>

</div>
