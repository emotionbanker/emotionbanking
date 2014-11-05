<?php

namespace app\controllers;

use app\models\AnketForm;
use app\models\Code;
use app\models\Form;
use app\models\UserText;
use Yii;
use yii\filters\AccessControl;
use yii\web\Controller;
use yii\filters\VerbFilter;
use app\models\LoginForm;
use app\models\ContactForm;

class SiteController extends Controller
{
    public function behaviors()
    {
        return [
            'access' => [
                'class' => AccessControl::className(),
                'only' => ['logout'],
                'rules' => [
                    [
                        'actions' => ['logout'],
                        'allow' => true,
                        'roles' => ['@'],
                    ],
                ],
            ],
            'verbs' => [
                'class' => VerbFilter::className(),
                'actions' => [
                ],
            ],
        ];
    }

    public function actions()
    {
        return [
            'error' => [
                'class' => 'yii\web\ErrorAction',
            ]
        ];
    }

    public function actionIndex()
    {
        $error = '';
        $model = new AnketForm();

        if ($model->load(Yii::$app->request->post())) {
            if ($code = $model->validateCode()) {
                if ($model->processCode($code)) {
                    $this->redirect('/site/welcome');
                } else {
                    $this->redirect('/site/index');
                }
            } else {
                $error = 'Bank gesperrt, Code ung?ltig oder bereits verwendetet. Anmeldung fehlgeschlagen.';
            }
        }

        return $this->render('index',[
            'model' => $model,
            'error' => $error
        ]);
    }

    public function actionWelcome()
    {
        if (! isset(Yii::$app->session['anketData'])) {
            $this->redirect('/site/index');
        }

        $data = Yii::$app->session['anketData'];

        return $this->render('welcome',[
            'text' => UserText::getText($data['group']['p_id'], $data['bank']['b_id'], $data['lang'], true)
        ]);
    }

    public function actionForm()
    {

        if (! isset(Yii::$app->session['anketData'])) {
            $this->redirect('/site/index');
        }

        $data = Yii::$app->session['anketData'];

        $form = Form::findOne($data['form']);

        $questions = $form->getQuestions();

        $status = Code::findOne($data['code']['z_id'])->status;

        if (Yii::$app->request->post('q')) {

            $userAnswers = Yii::$app->request->post('q');

            $status = $form->saveAnswers($data['code'], $userAnswers);

            $data['status'] = $status;
            $data['code']['status'] = $status;
        }

        Yii::$app->session['anketData'] = $data;

        if (! ($status < $form->getQuestionsCount($questions) )) {
            $code = Code::findOne($data['code']['z_id']);
            $code->used = 1;
            $code->save();
            $this->redirect('/site/end');
        }

        return $this->render('form',[
            'status' => $status,
            'percent' => round(($status / $form->getQuestionsCount($questions)) * 100),
            'questions' => $questions,
            'anket' => $form,
            'bank' => $data['bank']['b_id']
        ]);
    }

    public function actionEnd()
    {
        if (! isset(Yii::$app->session['anketData'])) {
            $this->redirect('/site/index');
        }

        $data = Yii::$app->session['anketData'];

        Yii::$app->session->remove('anketData');

        return $this->render('end',[
            'text' => UserText::getText($data['group']['p_id'], $data['bank']['b_id'], $data['lang'], false)
        ]);
    }

    public function actionLogin()
    {
        if (!\Yii::$app->user->isGuest) {
            return $this->redirect('/admin');
        }

        $model = new LoginForm();
        if ($model->load(Yii::$app->request->post()) && $model->login()) {
            return $this->redirect('/admin');
        } else {
            return $this->render('login', [
                'model' => $model,
            ]);
        }
    }

    public function actionLogout()
    {
        Yii::$app->user->logout();

        return $this->goHome();
    }
}
