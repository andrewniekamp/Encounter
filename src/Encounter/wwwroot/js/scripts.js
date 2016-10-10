﻿//Randomization check for foe action
function chooseAction(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}

//Checks for a winner
function winCheck(foeHealth, playerHealth) {
    if (foeHealth <= 0) {
        setTimeout(function () {
            $('#next-event').fadeIn();
        }, 500);
        console.log("Foe has died!");
        return false;
    }
    if (playerHealth <= 0) {
        setTimeout(function () {
            $('#you-lose').fadeIn();
        }, 500);
        console.log("You have died!");
        return false;
    }
    return true;
}

//Sets animations and adjusts health based on Act Ajax
function setEffects(isPlayer, result) {
    //Player action
    if (isPlayer) {
        if (result.charHeal > 0) {
            console.log(result.imageUrl);
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