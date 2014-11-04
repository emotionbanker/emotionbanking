<?php

use yii\helpers\Html;
use kartik\grid\GridView;
use yii\helpers\ArrayHelper;

/* @var $this yii\web\View */
/* @var $searchModel app\models\search\UserTextSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

if ($type == 'start') {
	$this->title = 'Individuelle Begrüßungstexte';
} else {
	$this->title = 'Individuelle Schlusstexte';
}
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="user-text-index">

    <p>
        <?= Html::a('Create User Text', ['user-text/create/' . $type], ['class' => 'btn btn-success']) ?>
    </p>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'ut_id',
			[
				'attribute' => 'p_id',
				'filterType'=>GridView::FILTER_SELECT2,
				'filter'=>ArrayHelper::map(app\models\Group::find()->all(),'p_id', 'bezeichnung'),
				'filterWidgetOptions'=>[
					'pluginOptions'=>['allowClear'=>true],
				],
				'value'=>function ($model, $key, $index, $widget) {
					if (! $model->p_id) return 'Alle';
					$group =  \app\models\Group::findOne($model->p_id);
					return $group ? $group->bezeichnung : $model->p_id;
				},
				'filterInputOptions'=>['placeholder'=>'Bitte wählen Sie'],
				'format'=>'raw'
			],
			[
				'attribute' => 'b_id',
				'filterType'=>GridView::FILTER_SELECT2,
				'filter'=>ArrayHelper::map(app\models\Bank::find()->all(),'b_id', 'bezeichnung'),
				'filterWidgetOptions'=>[
					'pluginOptions'=>['allowClear'=>true],
				],
				'value'=>function ($model, $key, $index, $widget) {
					if (! $model->b_id) return 'Alle';
					$group =  \app\models\Bank::findOne($model->b_id);
					return $group ? $group->bezeichnung : $model->b_id;
				},
				'filterInputOptions'=>['placeholder'=>'Bitte wählen Sie'],
				'format'=>'raw'
			],
			[
				'attribute' => 'l_id',
				'filterType'=>GridView::FILTER_SELECT2,
				'filter'=>ArrayHelper::map(app\models\Language::find()->all(),'l_id', 'name'),
				'filterWidgetOptions'=>[
					'pluginOptions'=>['allowClear'=>true],
				],
				'value'=>function ($model, $key, $index, $widget) {
					if (! $model->b_id) return 'Default';
					$group =  \app\models\Language::findOne($model->l_id);
					return $group ? $group->name : $model->l_id;
				},
				'filterInputOptions'=>['placeholder'=>'Bitte wählen Sie'],
				'format'=>'raw'
			],
			[
				'attribute' => 't_id',
				'value'=>function ($model, $key, $index, $widget) {
					$group =  \app\models\Text::findOne($model->t_id);
					return $group ? $group->name : $model->t_id;
				},
				'format'=>'raw'
			],
            [
				'class' => 'yii\grid\ActionColumn',
				'template' => '{update} {delete}'
			],
        ],
    ]); ?>

</div>
