<?php

use yii\helpers\Html;
use kartik\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel app\models\search\QuestionSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Fragen';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="question-index">

    <p>
        <?= Html::a('Neue frage', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
           	[
				'label' => 'ID',
				'attribute' => 'fr_id',
				'value'=>function ($model, $key, $index, $widget) {
					$count = $model->getAliasesCount();
					$additional = '';
					if ($count) {
						$additional = '<small>(+' . $count . ')</small>';
					}
					return $model->fr_id . ' ' . $additional;
				},
				'format' => 'raw'
			],
            'frage:ntext',
            [
				'label' => 'Art',
				'attribute' => 'display',
				'filterType'=>GridView::FILTER_SELECT2,
				'filter'=>app\models\Question::$types,
				'filterWidgetOptions'=>[
					'pluginOptions'=>['allowClear'=>true],
				],
				'filterInputOptions'=>['placeholder'=>''],
				'format'=>'raw'
			],
            'suche:ntext',
            [
				'class' => 'yii\grid\ActionColumn',
				'template' => '{alias} {update} {delete}',
				'buttons' => [
					'alias' => function($url, $model, $key) {
						return Html::a('<i class="fa fa-files-o"></i>', '/question/' . $model->fr_id . '/aliases', [
							'title' => Yii::t('yii', 'Alternativen'),
						]);
					}
				]
			],
        ],
    ]); ?>

</div>
