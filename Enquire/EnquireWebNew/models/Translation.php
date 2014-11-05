<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "{{%translations}}".
 *
 * @property integer $t_l_id
 * @property integer $t_fr_id
 * @property string $frage
 * @property string $antworten
 */
class Translation extends \yii\db\ActiveRecord
{
    /**
     * @inheritdoc
     */
    public static function tableName()
    {
        return '{{%translations}}';
    }

    /**
     * @inheritdoc
     */
    public function rules()
    {
        return [
            [['t_l_id', 't_fr_id'], 'required'],
            [['t_l_id', 't_fr_id'], 'integer'],
            [['frage', 'antworten'], 'string']
        ];
    }

    /**
     * @inheritdoc
     */
    public function attributeLabels()
    {
        return [
            't_l_id' => 'T L ID',
            't_fr_id' => 'T Fr ID',
            'frage' => 'Frage',
            'antworten' => 'Antworten',
        ];
    }
}
