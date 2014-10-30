<?php

namespace app\controllers;

use Yii;
use yii\filters\AccessControl;
use yii\web\Controller;
use yii\filters\VerbFilter;
use app\models\LoginForm;
use app\models\ContactForm;

class SystemController extends Controller
{
	public $layout = 'admin';

    public function behaviors()
    {
        return [
        ];
    }

    public function actionStatistic()
    {
        return $this->render('index');
    }

}
