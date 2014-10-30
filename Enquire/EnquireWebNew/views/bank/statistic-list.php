<?php

use yii\helpers\Html;
use kartik\grid\GridView;

/* @var $this yii\web\View */
/* @var $model app\models\Bank */

$this->title = 'Statistik';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="bank-view">

	<?php foreach ($list as $bank): ?>
		<?php echo Html::a($bank->bezeichnung, '#' . $bank->b_id) ?><br/>
	<?php endforeach;?>

	<?php foreach ($list as $bank): ?>
		<h3 id="<?php echo  $bank->b_id?>"><?php echo $bank->bezeichnung?></h3>
		<?php

		$searchModel = new \app\models\search\Statistic($bank->b_id);
		$dataProvider = $searchModel->search();
		?>
		<?= GridView::widget([
			'dataProvider' => $dataProvider,
			'columns' => [
				[
					'label' => 'Personengruppe',
					'attribute' => 'bezeichnung',
					'width' => '20%'
				],
				[
					'label' => 'Anz. Codes',
					'attribute' => 'tic_count',
					'pageSummary' => true,
					'width' => '20%'
				],
				[
					'label' => 'Komplett',
					'attribute' => 'bused',
					'pageSummary' => true,
					'width' => '20%'
				],
				[
					'label' => 'nur 50 oder mehr',
					'attribute' => 'bused50',
					'pageSummary' => true,
					'width' => '20%'
				],
				[
					'label' => 'Gesamt in Auswertung',
					'attribute' => 'busedtot',
					'pageSummary' => true,
					'width' => '20%'
				],
			],
			'showPageSummary' => true
		]);
		?>
	<?php endforeach;?>
</div>
