$(window).load(function(){
    function fixDiv() {
        var $multiselect = $('ul.multiselect-container');
        var $filterInput = $('ul.multiselect-container .input-group');
        var $top = 0;
        $multiselect.scroll(function(){
            $top = $multiselect.scrollTop();
            if ($top > 1){
                $filterInput.css({'position': 'absolute', 'top': $top+'px'});
            }
            else{
                $filterInput.css({'position': 'relative', 'top': 'auto'});
            }
        });
    }
    fixDiv();
});