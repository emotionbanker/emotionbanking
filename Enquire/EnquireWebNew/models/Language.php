<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "{{%languages}}".
 *
 * @property integer $l_id
 * @property string $short
 * @property string $name
 */
class Language extends \yii\db\ActiveRecord
{
    /**
     * @inheritdoc
     */
    public static function tableName()
    {
        return '{{%languages}}';
    }

    /**
     * @inheritdoc
     */
    public function rules()
    {
        return [
            [['short'], 'string', 'max' => 3],
            [['name'], 'string', 'max' => 60]
        ];
    }

    /**
     * @inheritdoc
     */
    public function attributeLabels()
    {
        return [
            'l_id' => 'L ID',
            'short' => 'Short',
            'name' => 'Name',
        ];
    }
}
