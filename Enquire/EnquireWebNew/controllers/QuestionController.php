<?php

namespace app\controllers;

use app\models\QuestionAlias;
use app\models\search\QuestionAliasSearch;
use Yii;
use app\models\Question;
use app\models\search\QuestionSearch;
use yii\helpers\ArrayHelper;
use yii\web\Controller;
use yii\web\NotFoundHttpException;
use yii\filters\VerbFilter;
use yii\web\UploadedFile;
use yii\filters\AccessControl;

/**
 * QuestionController implements the CRUD actions for Question model.
 */
class QuestionController extends Controller
{
	public $layout = 'admin';

    public function behaviors()
    {
        return [
            'access' => [
                'class' => AccessControl::className(),
                'rules' => [
                    [
                        'allow' => true,
                        'roles' => ['@'],
                    ],
                ],
            ],
            'verbs' => [
                'class' => VerbFilter::className(),
                'actions' => [
                    'delete' => ['post'],
                ],
            ],
        ];
    }

    /**
     * Lists all Question models.
     * @return mixed
     */
    public function actionIndex()
    {
        $searchModel = new QuestionSearch();
        $dataProvider = $searchModel->search(Yii::$app->request->queryParams);

        return $this->render('index', [
            'searchModel' => $searchModel,
            'dataProvider' => $dataProvider,
        ]);
    }

    /**
     * Displays a single Question model.
     * @param integer $id
     * @return mixed
     */
    public function actionView($id)
    {
        return $this->render('view', [
            'model' => $this->findModel($id),
        ]);
    }


	/**
	 * Displays a list of question Aliases.
	 * @param integer $id
	 * @return mixed
	 */
	public function actionAliases($id)
	{
		if (Yii::$app->request->post('QuestionAlias')){

			$model = new QuestionAlias();
			$model->load(Yii::$app->request->post());
			$model->save();
		}


		$searchModel = new QuestionAliasSearch($id);
		$dataProvider = $searchModel->search(
				Yii::$app->request->queryParams
		);
		return $this->render('aliases', [
			'question' => $this->findModel($id),
			'searchModel' => $searchModel,
			'dataProvider' => $dataProvider,
		]);
	}

	public function actionDeleteAlias($id, $alid)
	{
		QuestionAlias::deleteAll(['a_fr_id'=>$id, 'al_id'=>$alid]);

		return $this->redirect(['question/' . $id . '/aliases']);
	}

    /**
     * Creates a new Question model.
     * If creation is successful, the browser will be redirected to the 'view' page.
     * @return mixed
     */
    public function actionCreate()
    {
        $model = new Question();

        if ($model->load(Yii::$app->request->post()) && $model->save()) {
            return $this->redirect(['view', 'id' => $model->fr_id]);
        } else {
            return $this->render('create', [
                'model' => $model,
            ]);
        }
    }

    /**
     * Updates an existing Question model.
     * If update is successful, the browser will be redirected to the 'view' page.
     * @param integer $id
     * @return mixed
     */
    public function actionUpdate($id)
    {
        $model = $this->findModel($id);

        if ($model->load(Yii::$app->request->post()) && $model->save()) {
            return $this->redirect(['view', 'id' => $model->fr_id]);
        } else {
            return $this->render('update', [
                'model' => $model,
            ]);
        }
    }

    /**
     * Deletes an existing Question model.
     * If deletion is successful, the browser will be redirected to the 'index' page.
     * @param integer $id
     * @return mixed
     */
    public function actionDelete($id)
    {
        $this->findModel($id)->delete();

        return $this->redirect(['index']);
    }



	public function actionImport()
	{
		//print_r($_FILES);
		//exit;
		$imported = 0;
		$dropped = 0;
		$file = UploadedFile::getInstanceByName('filename');
		if ($file) {
			$content = file($file->tempName);
			foreach ($content  as $line) {
				$question = explode('@', $line);
				if (in_array($question[1], array_keys(Question::$types))) {

					$oQuestion = new Question();
					$oQuestion->frage = $question[0];
					$oQuestion->display = $question[1];
					$oQuestion->antworten = $question[2];
					$oQuestion->suche = $question[3];
					$oQuestion->save();
					$imported++;
				} else {
					$dropped++;
				}
			}
		}

		return $this->render('upload', [
			'imported' => $imported,
			'dropped' => $dropped,
		]);
	}

    /**
     * Finds the Question model based on its primary key value.
     * If the model is not found, a 404 HTTP exception will be thrown.
     * @param integer $id
     * @return Question the loaded model
     * @throws NotFoundHttpException if the model cannot be found
     */
    protected function findModel($id)
    {
        if (($model = Question::findOne($id)) !== null) {
            return $model;
        } else {
            throw new NotFoundHttpException('The requested page does not exist.');
        }
    }
}
