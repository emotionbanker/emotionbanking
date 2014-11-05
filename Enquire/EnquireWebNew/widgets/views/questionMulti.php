<?php

	for ($i = 0; $i < count($questions); $i++) {
		if (Yii::$app->request->get('lang') || Yii::$app->session['anketData']['lang']) {
			$lang = Yii::$app->request->get('lang') ? Yii::$app->request->get('lang') : 0;
			$lang = $lang ? $lang : Yii::$app->session['anketData']['lang'];
			if ($lang != 'default') {
				\app\models\Question::translateQuestion($question, $lang);
			}
		}
	}

	$num += 1;
	$nr = $num - count($questions);

	$answers = explode(";", $questions[0]['antworten']);
	if (!is_array($answers))
		$answers = array($questions[0]['antworten']);

	foreach($answers as $key => $value)	{
		$answers[$key] = trim($value);
	}


	$style="light";

	?>
	<div class="form-group">
		<table class="table table-striped table-bordered">
			<tr>
				<th></th>
				<?php
				if ($questions[0]['display'] != "text") {
					foreach ($answers as $answer) {
						echo "<th>" . $answer . "</th>";
					}
				}
				?>
			</tr>

<?php

	foreach($questions as $q)
	{
		//$q = applyAlias($q);
		?>
			<tr>
		<?php
		$nr = $q['pos'];

		if ($preview && $q['condition']) {
			$q['frage'] = $q['fr_id'] . ' - ' . "<span style='background-color: lightgreen;'> wenn " . $q['condition'] . "</span> " . $q['frage'];
		} else if ($preview) {
			$q['frage'] = $q['fr_id'] . ' - ' . $q['frage'];
		}
		?>
		<td><?php echo $q['frage'] ;?><input type='hidden' name='q[<?php echo $nr?>]' value=''/></td>
		<?php

		switch($q['display'])
		{
			case "text":
				?>
				<td>
					<div class="form-group">
						<input type='text' class="form-control" name='q[<?php echo $nr ?>]' size='90'/>
					</div>
				</td>
				<?php
				break;

			case "radio":
				$ai = 1;
				foreach ($answers as $answer)
				{
					?>
						<td width="10%" class="radio-column"><input type="radio" name="q[<?php echo $nr; ?>]" value="<?php echo $answer ?>" ></td>
					<?php
				}
				break;

			case "multi":
				$i = 0;
				foreach ($answers as $answer)
				{
					?>
					<td class="radio-column" width="10%"><input type="checkbox" name="q[<?php echo $nr; ?>][<?php echo $i++ ?>]" value="<?php echo $answer ?>"
							<?php is_array($qu[$nr]) && in_array($answer,$qu[$nr]) ? 'checked' : '' ?>></td>
					<?php
				}
				break;

			case "multitext":
				$in = 1;
				foreach ($answers as $answer)
				{
					?>
						<td><?php echo $in ?><input class="form-control" type='text' name='q[<?php echo $nr ?>][<?php echo $i++ ?>]' value='<?php echo $qu ?>' size='90'></td>
					<?php
					$in++;
				}

				break;
		}
		?>
				</tr>
			<?php
	}
?>
			</table>
		</div>