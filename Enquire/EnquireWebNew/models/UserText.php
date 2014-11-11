<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "{{%usertext}}".
 *
 * @property integer $ut_id
 * @property integer $p_id
 * @property string $b_id
 * @property integer $l_id
 * @property integer $t_id
 * @property integer $isStart
 * @property integer $isEnd
 */
class UserText extends \yii\db\ActiveRecord
{
    /**
     * @inheritdoc
     */
    public static function tableName()
    {
        return '{{%usertext}}';
    }

    /**
     * @inheritdoc
     */
    public function rules()
    {
        return [
			[['b_id'], 'string'],
            [['p_id', 'l_id', 't_id', 'isStart', 'isEnd'], 'integer'],
            [['p_id', 'b_id', 'l_id', 't_id'], 'required'],
        ];
    }

    /**
     * @inheritdoc
     */
    public function attributeLabels()
    {
        return [
            'ut_id' => 'Ut ID',
            'p_id' => 'Benutzer',
            'b_id' => 'Bank',
            'l_id' => 'Sprache',
            't_id' => 'Begrüssungstext',
            'isStart' => 'Is Start',
            'isEnd' => 'Is End',
        ];
    }

    public static function getText($user = null, $bank = null, $language = null, $isStart = true) {

        $query = UserText::find()
            ->andWhere(['OR', 'p_id=0', 'p_id='.$user])
            ->andWhere(['OR', 'b_id=0', 'b_id="'.$bank.'"'])
            ->andWhere(['OR', 'l_id=0', 'l_id='.($language == 'default' ? '0' : $language)]);
            if(!$isStart) {
                $query->andWhere(['isEnd' => 1]);
            } else {
                $query->andWhere(['isStart' => 1]);
            }
        $query->orderBy(['p_id' => SORT_DESC, 'b_id' => SORT_DESC, 'l_id' =>SORT_DESC  ]);

        $text = $query->one();

        return $text;
    }
}
