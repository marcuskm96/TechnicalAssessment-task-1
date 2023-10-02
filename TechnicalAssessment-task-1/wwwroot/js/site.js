// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

const uri = '/api/Yahtzee'
let rollNumber = 0;

let dicehand = new Array;

function reset() {
    // Reset roll number and dicehand array
    rollNumber = 0;
    dicehand = [];

    // Clear all dice images and score element from the UI
    let firstRollDiv = document.getElementById("first-roll");
    firstRollDiv.innerHTML = '';
    let secondRollDiv = document.getElementById("second-roll");
    secondRollDiv.innerHTML = '';
    let thirdRollDiv = document.getElementById("third-roll");
    thirdRollDiv.innerHTML = '';
    let onHandDiv = document.getElementById("on-hand");
    onHandDiv.innerHTML = '';
    let scoreElement = document.getElementById("score");
    scoreElement.innerHTML = '';
}

function saveDice(el, i) {
    // Made sure that no more then maximum 5 dices gets saved
    if (dicehand.length < 5) {
        el.remove();
        let div = document.getElementById("on-hand");
        div.appendChild(getImg(i));
        dicehand.push(i);
    }
}

function ping() {
    fetch(uri)
        .then(response => response.text())
        .then(data => console.log(data));
}

function roll() {
    if (rollNumber < 3) {
        rollNumber++;
        fetch(uri + "/roll/" + (5 - dicehand.length))
            .then(response => response.json())
            .then(data => {
                // Clears the div elements for the previous roll phase
                if (rollNumber === 2) {
                    let clearDiv = document.getElementById("first-roll");
                    clearDiv.innerHTML = '';
                } else if (rollNumber === 3) {
                    let clearDiv = document.getElementById("second-roll");
                    clearDiv.innerHTML = '';
                }
                displayResults(data, rollNumber);
            });
    }
}

function getResult() {
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dicehand)
    })
        .then(response => response.json())
        .then(data => {
            displayScore(data)
        })
}

function displayResults(roll, i) {
    if (i === 1) {
        let div = document.getElementById("first-roll")
        roll.forEach((i => {
            div.appendChild(getImg(i));
        }));
    }
    else if (i === 2) {
        let div = document.getElementById("second-roll")
        roll.forEach((i => {
            div.appendChild(getImg(i));
        }));
    }
    else if (i === 3) {
        let div = document.getElementById("third-roll")
        roll.forEach((i => {
            div.appendChild(getImg(i));
        }));
    }
}

function displayScore(i) {
    // Changed this method to fix a bug such that the final score gets updated correctly
    let scoreElement = document.getElementById("score");
    scoreElement.innerHTML = '';

    let span = document.createElement("span");
    span.textContent = i;
    
    scoreElement.appendChild(span);
    console.log(document.getElementById("score").appendChild(span));
}

function getImg(i) {
    let img = document.createElement("img");
    img.setAttribute("roll-nr", i);
    img.className = "dice";
    img.height = 60;
    img.width = 60;
    switch (i) {
        case 1:
            img.src = "../imgs/1024px-Dice-1.svg.png";
            break;
        case 2:
            img.src = "../imgs/800px-Dice-2.svg.png";
            break;
        case 3:
            img.src = "../imgs/800px-Dice-3.svg.png";
            break;
        case 4:
            img.src = "../imgs/800px-Dice-4.svg.png";
            break;
        case 5:
            img.src = "../imgs/800px-Dice-5.svg.png";
            break;
        case 6:
            img.src = "../imgs/Dice-6a.svg.png";
            break;
    }
    img.setAttribute("onclick", "saveDice(this," + i + ")");

    // Comment out line 137 and remove comments right under + the comments around the removeDice() method if you want to try out the dice removal functionality
    /*
    img.onclick = function () {
        if (dicehand.includes(i)) {
            removeDice(i);
        } else {
            saveDice(this, i);
        }
    };
    */
    return img;
}

// This function makes the player able to delete saved dices and return them back to the current roll phase (does not work 100%)
/*
function removeDice(i) {
    let div = document.getElementById("on-hand");
    let img = div.querySelector(`img[roll-nr="${i}"]`);
    if (img) {
        div.removeChild(img);

        // Append the image back to the current roll div
        let rollDiv;
        switch (rollNumber) {
            case 1:
                rollDiv = document.getElementById("first-roll");
                break;
            case 2:
                rollDiv = document.getElementById("second-roll");
                break;
            case 3:
                rollDiv = document.getElementById("third-roll");
                break;
            default:
                return;
        }
        rollDiv.appendChild(getImg(i));
    }
}
*/
