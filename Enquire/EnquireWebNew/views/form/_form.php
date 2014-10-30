<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;
use yii\helpers\ArrayHelper;
use kartik\grid\GridView;
use app\models\search\QuestionSearch;


$searchModel = new QuestionSearch();
$dataProvider = $searchModel->search(Yii::$app->request->queryParams);

/* @var $this yii\web\View */
/* @var $model app\models\Form */
/* @var $form yii\widgets\ActiveForm */
$banks = array_merge(
	['' => 'Bitte wählen Sie'],
	ArrayHelper::map(app\models\Bank::find()->all(),'klasse', 'bezeichnung')
);
$grous = array_merge(
	['' => 'Bitte wählen Sie'],
	ArrayHelper::map(app\models\Group::find()->all(),'p_id', 'bezeichnung')
);


?>

<div class="form-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'f_klasse')->dropDownList($banks) ?>

    <?= $form->field($model, 'f_p_id')->dropDownList($grous) ?>

    <?= $form->field($model, 'reihenfolge')->textarea(['rows' => 6]) ?>
	<?php echo Html::button('Fragenliste ein/ausblenden', ['id'=>'addQuestion', 'data'=>['toggle'=>"modal", 'target'=>'#myModal'], 'class'=>'btn btn-primary']) ?>
    <div class="form-group">
        <?= Html::submitButton($model->isNewRecord ? 'Create' : 'Update', ['class' => $model->isNewRecord ? 'btn btn-success' : 'btn btn-primary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

	<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
		<div class="modal-dialog" style="width:80%">
			<div class="modal-content">
				<div class="modal-header">
					<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
					<h4 class="modal-title" id="myModalLabel">Modal title</h4>
				</div>
				<div class="modal-body">
					<?php \yii\widgets\Pjax::begin(); ?>
					<?= GridView::widget([
						'dataProvider' => $dataProvider,
						'filterModel' => $searchModel,
						'columns' => [
							[
								'label' => 'ID',
								'attribute' => 'fr_id',
								'value'=>function ($model, $key, $index, $widget) {
									return Html::button('Add', ['data'=>['question'=>'fr_id'], 'class'=>'btn btn-warning']);
								},
								'format' => 'raw'
							],
							[
								'attribute' => 'frage',
								'value'=>function ($model, $key, $index, $widget) {
									return $model->frage . '<br/><em>' . $model->antworten .'</em>';
								},
								'format' => 'raw'
							],
							[
								'label' => 'Art',
								'attribute' => 'display',
								'filterType'=>GridView::FILTER_SELECT2,
								'filter'=>app\models\Question::$types,
								'filterWidgetOptions'=>[
									'pluginOptions'=>['allowClear'=>true],
								],
								'filterInputOptions'=>['placeholder'=>'Bitte wählen Sie'],
								'format'=>'raw'
							],
						],
					]); ?>
				<?php \yii\widgets\Pjax::end(); ?>
				</div>
				<div class="modal-footer">
					<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
					<button type="button" class="btn btn-primary">Save changes</button>
				</div>
			</div>
		</div>
	</div>

</div>
