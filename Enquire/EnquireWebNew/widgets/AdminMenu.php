<?php

namespace app\widgets;

use Yii;
use yii\helpers\ArrayHelper;
use yii\helpers\Html;

class AdminMenu extends \yii\base\Widget {

	public function run()
	{

		$items = [
			[
				'title' => 'Fragen',
				'icon' => 'question-circle',
				'url' => 'question/index',
				'items' => [
					[
						'title' => 'Neue frage',
						'url' => 'question/create',
					],
					[
						'title' => 'Aus datei einspielen',
						'url' => 'question/import',
					],
					[
						'title' => 'Liste',
						'url' => 'question/index',
					],
				]
			],
			[
				'title' => 'Banken',
				'icon' => 'money',
				'url' => 'bank/index',
				'items' => [
					[
						'title' => 'Neue bank',
						'url' => 'bank/create',
					],
					[
						'title' => 'Liste',
						'url' => 'bank/index',
					],
					[
						'title' => 'Bankenstatistik',
						'url' => 'bank/statistic-list',
					],
					[
						'title' => 'Platzhalter',
						'url' => 'bank/placeholders',
					],
				]
			],
			[
				'title' => 'Benutzergruppen',
				'icon' => 'users',
				'url' => 'group/index',
				'items' => [
					[
						'title' => 'Neue gruppe',
						'url' => 'group/create',
					],
					[
						'title' => 'Liste',
						'url' => 'group/index',
					],
				]
			],

			[
				'title' => 'Fragebögen',
				'icon' => 'terminal',
				'url' => 'form/index',
				'items' => [
					[
						'title' => 'Neue fragebögen',
						'url' => 'form/create',
					],
					[
						'title' => 'Liste',
						'url' => 'form/index',
					],
				]
			],
			[
				'title' => 'Zugangscodes',
				'icon' => 'barcode',
				'url' => 'codes/create',
				'items' => [
					[
						'title' => 'Neue codes erzeugen',
						'url' => 'code/create',
					],
				]
			],
			[
				'title' => 'Individualisierung',
				'icon' => 'paint-brush',
				'url' => 'user-text/index',
				'items' => [
					[
						'title' => 'Texts',
						'url' => 'texts/index'
					],
/*					[
						'title' => 'styles',
						'url' => 'group/create',
					],*/
					[
						'title' => 'begrüßungstexte',
						'url' => 'user-text/index/start',
					],
					[
						'title' => 'schlusstexte',
						'url' => 'user-text/index/end',
					],
				]
			],


			[
				'title' => 'Sprachen',
				'icon' => 'language',
				'url' => 'language/index',
				'items' => [
					[
						'title' => 'Neue sprache',
						'url' => 'language/create',
					],
					[
						'title' => 'Liste',
						'url' => 'language/index',
					],
					[
						'title' => 'Aus datei einspielen',
						'url' => 'language/import',
					],
				]
			],
			[
				'title' => 'System',
				'icon' => 'cogs',
				'url' => 'system/index',
				'items' => [
					[
						'title' => 'Statistik',
						'url' => 'system/statistic',
					],
					[
						'title' => 'Backup',
						'url' => 'system/index',
					],
					[
						'title' => 'Backup einspielen',
						'url' => 'system/index',
					],
					[
						'title' => 'Sperren',
						'url' => 'system/index',
					],
					[
						'title' => 'Reset',
						'url' => 'system/index',
					],
					[
						'title' => 'Ergebnisse löschen',
						'url' => 'system/index',
					],
				]
			],

		];

		echo $this->render('adminmenu', ['items' => $items]);
	}

}