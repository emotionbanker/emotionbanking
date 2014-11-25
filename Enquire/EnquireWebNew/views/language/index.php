<?php

use yii\helpers\Html;
use yii\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel app\models\search\LanguageSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Sprachen';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="language-index">


    <p>
        <?= Html::a('Neue Sprache', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            'l_id',
            'short',
            'name',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>

</div>
