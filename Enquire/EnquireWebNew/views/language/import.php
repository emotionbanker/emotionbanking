<?php

use yii\helpers\Html;
use kartik\grid\GridView;
use yii\widgets\ActiveForm;
use kartik\widgets\FileInput;

/* @var $this yii\web\View */
/* @var $searchModel app\models\search\QuestionSearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Aus datei einspielen';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="question-index">
    <div class="bs-callout bs-callout-warning">
        <h4>ACHTUNG: Quelldatei muss eine Textdatei im Format</h4>
        <p>Fragennummer@Übersetzter Fragentext@Übersetzte Antwort 1;Übersetzte Antwort 1;Übersetzte Antwort N</p>
        <p>sein. Beispiel: (Frage 445: Die Zusammenarbeit mit meinem direkten Vorgesetzen hat sich in den letzten 12 Monaten...</p>
        <p>445@Cooperation with my direct superior has, in the last 12 months@greatly improved;improved;neither;declined;greatly declined</p>
    </div>

    <?php if ($imported): ?>
        <h3 style="color: #008000"><?php echo $imported;?> bersetzungen in die Datenbank aufgenommen bzw. upgedated</h3>
    <?php endif;?>

    <div class="upload-field">
        <?php
        $form = ActiveForm::begin(['options' => ['enctype'=>'multipart/form-data']]); //important
        ?>
        <div class="form-group">
            <label for="">Für Sprache</label>
            <?php echo Html::dropDownList('lang',null, \app\helpers\InputHelper::getDropdownOptions('app\models\Language', 'l_id', 'name', true), ['class'=>'form-control']);?>
        </div>
        <?php

        echo FileInput::widget([
            'name' => 'filename',
            'options'=>[
                'multiple' => false
            ],
            'pluginOptions' => [
                'showPreview' => false,
                'showCaption' => true,
                'showRemove' => true,
                'showUpload' => false
            ]

        ]);
        ?>
        <br/>
        <input type="submit" class="btn btn-primary" value="Upload"/>
    </div>
    <?php ActiveForm::end(); ?>



</div>