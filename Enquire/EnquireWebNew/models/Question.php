<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "{{%frage}}".
 *
 * @property integer $fr_id
 * @property string $frage
 * @property string $display
 * @property string $antworten
 * @property string $suche
 */
class Question extends \yii\db\ActiveRecord
{

	public static $types = [
		'text' => 'freie antwort (textfeld)',
		'radio' => 'auswahl (radio buttons)',
  		'multi' => 'mehrfachauswahl (tickboxes)',
		'multitext' => 'mehrere freie antworten (textfelder)'
	];

    /**
     * @inheritdoc
     */
    public static function tableName()
    {
        return '{{%frage}}';
    }

    /**
     * @inheritdoc
     */
    public function rules()
    {
        return [
            [['frage', 'antworten', 'suche'], 'string'],
            [['display'], 'string', 'max' => 10],
			[['frage'], 'required'],
        ];
    }

    /**
     * @inheritdoc
     */
    public function attributeLabels()
    {
        return [
            'fr_id' => 'ID',
            'frage' => 'Frage/Text',
            'display' => 'Art',
            'antworten' => 'Antworten',
            'suche' => 'Suchkürzel',
        ];
    }

	public function getAliasesCount()
	{
		return QuestionAlias::find()->where(['a_fr_id'=>$this->fr_id])->count();
	}
}
