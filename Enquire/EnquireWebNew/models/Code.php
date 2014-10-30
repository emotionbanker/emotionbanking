<?php

namespace app\models;

use Yii;
use yii\helpers\ArrayHelper;

/**
 * This is the model class for table "{{%zugangsdaten}}".
 *
 * @property integer $z_id
 * @property string $code
 * @property string $z_b_id
 * @property integer $z_p_id
 * @property integer $used
 * @property integer $status
 */
class Code extends \yii\db\ActiveRecord
{

	public $count;
    /**
     * @inheritdoc
     */
	public static $_codes = null;

    public static function tableName()
    {
        return '{{%zugangsdaten}}';
    }

	public static function generateCode()
	{
		if (! self::$_codes) {
			self::$_codes = ArrayHelper::getColumn(self::find()->select('code')->all(), 'code');
		}

		$chars = array(1, 2, 3, 4, 5, 6, 7, 8, 9,
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' );

		$code ='';

		$generated = false;

		while (! $generated) {
			for ($j = 0; $j < 4; $j++) {
				$r = rand(0, count($chars)-1);
				$code .= $chars[$r];
			}

			if (!in_array($code, self::$_codes)) {
				$generated = true;
			} else {
				$code ='';
			}
		}


		return $code;

	}

    /**
     * @inheritdoc
     */
    public function rules()
    {
        return [
            [['z_p_id', 'used', 'status'], 'integer'],
            [['code'], 'string', 'max' => 4],
            [['z_b_id'], 'string', 'max' => 6],
            [['z_b_id', 'z_p_id'], 'required'],
            [['count'], 'required'],
        ];
    }

    /**
     * @inheritdoc
     */
    public function attributeLabels()
    {
        return [
            'z_id' => 'Z ID',
            'code' => 'Code',
            'z_b_id' => 'Bank',
            'z_p_id' => 'Benutzergruppe',
            'used' => 'Used',
            'status' => 'Status',
			'count' => 'Anzahl der codes'
        ];
    }
}
