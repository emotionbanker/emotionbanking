<?php

namespace app\models;

use Yii;
use yii\base\Model;

/**
 * This is the model class for table "{{%meta}}".
 *
 */
class AnketForm extends Model
{

    public $code;
    public $language;
    /**
     * @inheritdoc
     */
    public function rules()
    {
        return [
            [['code', 'language'], 'required'],
        ];
    }

    /**
     * @inheritdoc
     */
    public function attributeLabels()
    {
        return [
        ];
    }

    public function validateCode()
    {
        $code = substr($this->code, -4, 4);
        $bank = substr($this->code, 0, strlen($this->code)-7);

        $code = Code::findOne(['z_b_id' => $bank, 'code' => $code]);
        if (! $code) {
            return false;
        } else {
            return $code;
        }

    }

    public function isCodeLocked($bank, $group)
    {
        $staticDir = Yii::$app->params['staticDir'];

        if (!file_exists($staticDir . "banklocks")) return false;

        $data = file($staticDir . "banklocks");

        foreach ($data as $list) {
            if (
                (trim(strtolower($bank)) == trim(strtolower($list)))
                ||
                (trim(strtolower($bank. ':' . $group)) == trim(strtolower($list)))
            ) {
                return true;
            }
        }

        return false;
    }

    public function isCodeActive($code)
    {
        if ($code->used) {
            return false;
        }

        if ($this->isCodeLocked($code->z_b_id, $code->z_p_id)) {
            return false;
        }

        return true;
    }

    public function processCode($code)
    {

        if ($this->isCodeActive($code)) {
            $group = Group::findOne($code->z_p_id)->toArray();
            $bank  = Bank::findOne($code->z_b_id)->toArray();
            $form = Form::findOne(['f_klasse' => $bank['klasse'], 'f_p_id' => $group['p_id']]);

            Yii::$app->session['anketData'] = [
                'code' => $code->toArray(),
                'group' => $group,
                'bank' => $bank,
                'form' => $form->f_id,
                'status' => 0,
                'lang' => $this->language
            ];

            $meta = Meta::findOne(['m_z_id' => $code->z_id]);
            if (! $meta) {
                $meta = new Meta();
                $meta->m_z_id = $code->z_id;
                $meta->ip = $_SERVER['REMOTE_ADDR'];
                $meta->time_start = time();
            } else {
                $meta->ip = $_SERVER['REMOTE_ADDR'];
            }

            $meta->save();
            return true;
        }
        return false;
    }

}
