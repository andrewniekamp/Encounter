//Randomization check for foe action
function chooseAction(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}

//Checks for a winner
function winCheck() {
    if (foeHealth <= 0) {
        gameActive = false;
        setTimeout(function () {
            $('#next-event').fadeIn();
        }, 500);
        console.log("Foe has died!");
    }
    if (playerHealth <= 0) {
        gameActive = false;
        setTimeout(function () {
            $('#next-event').fadeIn();
        }, 500);
        console.log("You have died!");
    }
}

//Sets animations and adjusts health based on Act Ajax
function setEffects(isPlayer, result) {
    //Player action
    if (isPlayer) {
        if (result.charHeal > 0) {
            $('#char-sprite-effect-box').html('<img src="/img/heal-jade-3.png" />')
            $('#char-sprite-effect-box').fadeIn();
            window.setTimeout(function () {
                $('#char-sprite-effect-box').fadeOut();
            }, 100);
        }
        if (result.charHarm > 0) {
            $('#char-sprite-effect-box').html('<img src="/img/enchant-red-3.png" />')
            $('#char-sprite-effect-box').fadeIn();
            window.setTimeout(function () {
                $('#char-sprite-effect-box').fadeOut();
            }, 100);
        }
        if (result.foeHeal > 0) {
            $('#foe-sprite-effect-box').html('<img src="/img/heal-jade-3.png" />')
            $('#foe-sprite-effect-box').fadeIn();
            window.setTimeout(function () {
                $('#foe-sprite-effect-box').fadeOut();
            }, 100);
        }
        if (result.foeHarm > 0) {
            $('#foe-sprite-effect-box').html('<img src="/img/enchant-red-3.png" />')
            $('#foe-sprite-effect-box').fadeIn();
            window.setTimeout(function () {
                $('#foe-sprite-effect-box').fadeOut();
            }, 100);
        }
    } else {
        //Foe action
        if (result.charHeal > 0) {
            $('#foe-sprite-effect-box').html('<img src="/img/heal-jade-3.png" />')
            $('#foe-sprite-effect-box').fadeIn();
            window.setTimeout(function () {
                $('#foe-sprite-effect-box').fadeOut();
            }, 100);
        }
        if (result.charHarm > 0) {
            $('#foe-sprite-effect-box').html('<img src="/img/enchant-red-3.png" />')
            $('#foe-sprite-effect-box').fadeIn();
            window.setTimeout(function () {
                $('#foe-sprite-effect-box').fadeOut();
            }, 100);
        }
        if (result.foeHeal > 0) {
            $('#char-sprite-effect-box').html('<img src="/img/heal-jade-3.png" />')
            $('#char-sprite-effect-box').fadeIn();
            window.setTimeout(function () {
                $('#char-sprite-effect-box').fadeOut();
            }, 100);
        }
        if (result.foeHarm > 0) {
            $('#char-sprite-effect-box').html('<img src="/img/enchant-red-3.png" />')
            $('#char-sprite-effect-box').fadeIn();
            window.setTimeout(function () {
                $('#char-sprite-effect-box').fadeOut();
            }, 100);
        }
        
    }
}