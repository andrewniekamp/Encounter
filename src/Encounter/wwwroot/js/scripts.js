//Count down on event start
function countDown(count) {
    var intervalId = setInterval(function () {
        $("#count-down").text(count);
        if (count == 0) {
            clearInterval(intervalId);
            $('#start-banner').hide();
            $('#start-btn').fadeIn();
            console.log("START");
        };
        count -= 1;
    }, 1000);
}

//Pause game
function pressPause(gameActive, paused) {
    if (gameActive && paused == false) {
        $("#paused").fadeIn();
        console.log("Paused");
        return true;
    }
    else {
        $("#paused").fadeOut();
        console.log("Unpaused");
        return false;
    }
}

//Randomization check for foe action
function chooseAction(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}

//Sets animations and adjusts health based on Act Ajax
function setEffects(isPlayer, result) {
    //Player action
    if (isPlayer) {
        if (result.charHeal > 0) {
            $('#char-sprite-effect-box').html('<img class="effect" src="' + result.imageUrl + '" />')
            $('#char-sprite-effect-box').show();
            window.setTimeout(function () {
                $('#char-sprite-effect-box').fadeOut();
            }, 200);
        }
        if (result.charHarm > 0) {
            $('#char-sprite-effect-box').html('<img class="effect" src="' + result.imageUrl + '" />')
            $('#char-sprite-effect-box').show();
            window.setTimeout(function () {
                $('#char-sprite-effect-box').fadeOut();
            }, 200);
        }
        if (result.foeHeal > 0) {
            $('#foe-sprite-effect-box').html('<img class="effect" src="' + result.imageUrl + '" />')
            $('#foe-sprite-effect-box').show();
            window.setTimeout(function () {
                $('#foe-sprite-effect-box').fadeOut();
            }, 200);
        }
        if (result.foeHarm > 0) {
            $('#foe-sprite-effect-box').html('<img class="effect" src="' + result.imageUrl + '" />')
            $('#foe-sprite-effect-box').show();
            window.setTimeout(function () {
                $('#foe-sprite-effect-box').fadeOut();
            }, 200);
        }
    } else {
        //Foe action
        if (result.charHeal > 0) {
            $('#foe-sprite-effect-box').html('<img class="effect" src="' + result.imageUrl + '" />')
            $('#foe-sprite-effect-box').show();
            window.setTimeout(function () {
                $('#foe-sprite-effect-box').fadeOut();
            }, 200);
        }
        if (result.charHarm > 0) {
            $('#foe-sprite-effect-box').html('<img class="effect" src="' + result.imageUrl + '" />')
            $('#foe-sprite-effect-box').show();
            window.setTimeout(function () {
                $('#foe-sprite-effect-box').fadeOut();
            }, 200);
        }
        if (result.foeHeal > 0) {
            $('#char-sprite-effect-box').html('<img class="effect" src="' + result.imageUrl + '" />')
            $('#char-sprite-effect-box').show();
            window.setTimeout(function () {
                $('#char-sprite-effect-box').fadeOut();
            }, 200);
        }
        if (result.foeHarm > 0) {
            $('#char-sprite-effect-box').html('<img class="effect" src="' + result.imageUrl + '" />')
            $('#char-sprite-effect-box').show();
            window.setTimeout(function () {
                $('#char-sprite-effect-box').fadeOut();
            }, 200);
        }
    }
}

function move(actor) {
    if (actor == "char") {
        var char = $(".game-char-img");
        char.animate({ marginTop: "-=10%" }, { duration: 100, queue: false });
        char.animate({ marginLeft: "+=10%" }, 200);
        char.animate({ marginTop: "+=10%" }, 100);
        char.animate({ marginLeft: "-=10%" }, 200);
    } else if (actor == "foe") {
        var foe = $(".game-foe-img");
        foe.animate({ marginTop: "-=10%" }, { duration: 100, queue: false });
        foe.animate({ marginRight: "+=10%" }, 200);
        foe.animate({ marginTop: "+=10%" }, 100);
        foe.animate({ marginRight: "-=10%" }, 200);
    }

}