<?php

$question = $questions[0];
$hide = $question['hidden'];
$aslist = isset($question['aslist']) ? $question['aslist'] : false;

//if ($translate) $q = translateQ($q);

//$q = applyAlias($q);

$answers = explode(";", $question['antworten']);
if (! is_array($answers)) {
	$answers = array($question['antworten']);
}

foreach($answers as $key => $value)
{
	$answers[$key] = trim($value);
}

$nr = $question['pos'];

if ($preview && $question['condition']) {
	$question['frage'] = $question['fr_id'] . ' - ' . "<span style='background-color: lightgreen;'> wenn " . $question['condition'] . "</span> " . $question['frage'];
} else if ($preview) {
	$question['frage'] = $question['fr_id'] . ' - ' . $question['frage'];
}

echo "<input type='hidden' name='q[".$nr."]' value=''/>";

switch($question['display']) {
	case "text":
		?>
		<div class="form-group">
			<label for=""><?php echo $question['frage']?></label>
			<input type='text' class="form-control" name='q[<?php echo $nr ?>]' value='<?php echo $qu ?>' size='90'>
		</div>
		<?
	break;

	case "multitext":
		?>
		<div class="form-group">
			<label for=""><?php echo $question['frage']?></label>
			<?php
			$in = 1;
			$i = 0;
			foreach ($answers as $answer)
			{
				echo $in . ". <input class='form-control' type='text' name='q[".$nr."][".$i++."]' value='".$qu."' size='90'>";
				$in++;
			}
			?>
		</div>
		<?php

	break;

	case "radio":

		if ($aslist) {
			?>
			<div class="form-group">
				<label for=""><?php echo $question['frage']?></label>
			<?php
				foreach ($answers as $answer)
				{
					?>
					<div class="radio">
						<label>
							<input type="radio" name="q[<?php echo $nr; ?>]" value="<?php echo $answer ?>" >
							<?php echo $answer ?>
						</label>
					</div>
					<?php
				}
			?>
			</div>
			<?php
		} else if (count($answers) > 50) {
			?>
			<div class="form-group" <?php if ($hide) echo " style='display: none;'"?>>
				<label for=""><?php echo $question['frage']?></label>
				<select class="form-control" name='q[<?php echo $nr; ?>]'>
					<?php
					echo "<option value='' selected>---</option>";
					foreach ($answers as $answer)
					{
						echo "<option value'".$answer."'>$answer</option>";
					}
					?>
				</select>
			</div>
			<?php
		} else if (count($answers) > 8) {

			?>
			<div class="form-group radio-group" <?php if ($hide) echo " style='display: none;'"?>>
				<label for=""><?php echo $question['frage']?></label>
				<?php
				foreach ($answers as $answer)
				{
					?>
					<div class="radio">
						<label>
							<input type="radio" name="q[<?php echo $nr; ?>]" value="<?php echo $answer ?>" >
							<?php echo $answer ?>
						</label>
					</div>
					<?php
				}
				?>
				<div class="clearfix"></div>
			</div>
			<?php
		} else {
			?>
 			<div class="form-group">
				<table class="table table-striped table-bordered">
					<tr>
						<th></th>
						<?php
						foreach ($answers as $answer)
						{
							echo "<th>" . $answer . "</th>";
						}
						?>
					</tr>
					<tr>
						<td><?php echo $question['frage']?></td>
						<?php
						foreach ($answers as $answer)
						{
							?>
							<td width="10%" class="radio-column">
								<input type="radio" name="q[<?php echo $nr; ?>]" value="<?php echo $answer ?>" >
							</td>
							<?php
						}
						?>
					</tr>
				</table>
 			</div>
		<?php
		}
	break;

	case "multi":
		?>
		<div class="form-group check-group" <?php if ($hide) echo " style='display: none;'"?>>
			<label for=""><?php echo $question['frage']?></label>
			<?php
			$i = 0;
			foreach ($answers as $answer)
			{
				?>
				<div class="checkbox">
					<label>
						<input type="checkbox" name="q[<?php echo $nr; ?>][<?php echo $i++ ?>]" value="<?php echo $answer ?>"
							<?php is_array($qu) && in_array($answer,$qu) ? 'checked' : '' ?>>
						<?php echo $answer ?>
					</label>
				</div>
			<?php
			}
			?>
			<div class="clearfix"></div>
		</div>
		<?php
	break;
}