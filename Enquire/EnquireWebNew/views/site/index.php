<?php
/* @var $this yii\web\View */
$this->title = 'Victor 2014';
?>

<div class="form-div">
	<h4>Wenn Sie einen persönlichen Code für das Umfragesystem haben, geben Sie diesen bitte hier ein:</h4>
	<form action="?login" method="post" class="">
		<div class="form-group">
			<input type="text" class="form-control" placeholder="Code" name="code" maxlength="10" size="10">
		</div>
		<div class="form-group">
			<select name="lang" class="form-control">
				<option value="default">Deutsch</option>
				<option value="3"></option>
				<option value="4">italienisch Suedtirol</option><option value="14">Italienisch Suedtirol</option><option value="15">Italienisch Suedtirol Firmenkunde</option><option value="19">italienisch Suedtirol Führungskräfte Vertrieb</option><option value="17">Italienisch Suedtirol Vermögende Privatkunde</option><option value="18">italienisch Suedtirol Mitarbeiter Betrieb</option><option value="20">italienisch Suedtirol Führungskräfte Betrieb</option><option value="21">italienisch RK Bruneck vermögende Privatkunden</option><option value="22">italienisch RK Bruneck Privatkunden</option><option value="23">italienisch RK Bruneck Firmenkunden</option><option value="28">italienisch RK Wipptal Privatkunde </option><option value="29">Italiensich Raiffeisenkasse Wipptal Firmenkunde</option><option value="30">Testsprache</option><option value="31">Samet Test</option><option value="34">Test Koloman</option><option value="35">italienisch RK Eisacktal Firmenkunden </option><option value="36">italienisch RK Eisacktal Privatkunden</option><option value="37">italienisch RK Eisacktal vermögende Privatkunden</option>  </select>

		</div>
		<input type="submit"  class="btn btn-primary btn-block" value="Umfrage beginnen">
	</form>
</div>
