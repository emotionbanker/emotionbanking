$(window).load(function(){
    var questions = [], existingQuestions = [];
    var $questionary = $('#form-reihenfolge').val();
    var $modal = $('#myModal');

    function applyQuestionsAdding(){
        existingQuestions = getExisting($questionary).concat(questions);
        $('.question-add.btn-warning').each(function(){
            var $questionId = $(this).data('question');
            if(existingQuestions.indexOf($questionId)!==-1){
                $(this).removeClass('btn-warning');
            }
        });
        $('.question-add.btn-warning').on('click', function(){
            var $text = $(this).text();
            //$(this).text($text == "Add" ? "Del" : "Add");
            $(this).removeClass('btn-warning').off('click');
            var $questionId = $(this).data('question');
            questions.push($questionId);
        });
    }

    function getExisting(questionary){
        var existing = [];
        if(questionary != ''){
            existing = questionary.split(';');
            for(var i=0; i < existing.length; i++){
                if(isNaN(existing[i] = parseInt(existing[i]))){
                    existing.splice(i,1);
                    i--;
                }
            }
        }
        return existing;
    }


    $(document).on('ready pjax:success', function() {
        applyQuestionsAdding();
    });

    $modal.on('hide.bs.modal', function (e) {
        questions = [];
    });

    $('#reinfolge-save').bind('click', function(){
        if(questions.length != 0){
            $questionary = $questionary + questions.join(';') + ';';
            $('#form-reihenfolge').val($questionary);
        }
    });

    applyQuestionsAdding();
});