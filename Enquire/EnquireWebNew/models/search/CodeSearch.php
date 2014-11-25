<?php

namespace app\models\search;

use app\models\Code;
use Yii;
use yii\base\Model;
use yii\data\ActiveDataProvider;

/**
 * QuestionSearch represents the model behind the search form about `app\models\Question`.
 */
class CodeSearch extends Code
{

	public function __construct($bankId) {
		$this->z_b_id = $bankId;
	}

	/**
	 * @inheritdoc
	 */
	public function rules()
	{
		return [
			[['z_p_id', 'used', 'status'], 'integer'],
			[['code'], 'string', 'max' => 4],
		];
	}

	/**
	 * @inheritdoc
	 */
	public function scenarios()
	{
		// bypass scenarios() implementation in the parent class
		return Model::scenarios();
	}

	/**
	 * Creates data provider instance with search query applied
	 *
	 * @param array $params
	 *
	 * @return ActiveDataProvider
	 */
	public function search($params)
	{
		$query = Code::find();

		$dataProvider = new ActiveDataProvider([
			'query' => $query,
		]);
		$query->andFilterWhere([
			'z_b_id' => $this->z_b_id,
		]);

		if (!($this->load($params) && $this->validate())) {
			return $dataProvider;
		}
		if (!$this->status) {
			$query->andFilterWhere([
				'status' => $this->status,
			]);
		} else {
			$query->andFilterWhere(['>', 'status', $this->status]);
		}


		$query->andFilterWhere(['like', 'code', $this->code]);


		return $dataProvider;
	}
}
