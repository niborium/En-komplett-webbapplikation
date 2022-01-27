'use strict';

const nasaapiKey = 'zCdlM3l2m8Cz5thU3mpML6gO5uHgV5aEcDshdqvy'

const app =
{
    main: document.getElementById('main'),
    startpageButton: document.getElementById('startpageButton'),
    roverButton1: document.getElementById('roverButton1'),
    roverButton2: document.getElementById('roverButton2'),
    roverButton3: document.getElementById('roverButton3'),
    roverButtons: [roverButton1, roverButton2, roverButton3]
}

getRovers();

app.startpageButton.addEventListener('click', function () {
    app.main.innerHTML = `<h2>Välkommen!</h2>
            <p>
                Vi är en naturhistorisk förening med fokus på rymden, som skulle vilja göra allt fantastiskt som hänt på Mars de senaste åren mer tillgängligt för unga människor i Sverige.<br />
                NASA har ett antal rymddrönare på planeten som tagit, och som fortfarande tar foton på planetens yta!<br /> <br />
                Du kan trycka på knapparna ovan i menyn för att få mer information och även se foton, du kan även trycka på "Bli medlem" för att ansöka om medlemskap hos oss.
            </p>`;
})

function getRovers() {
    fetch('api/rovers')
        .then(resp => resp.json())
        .then(data => printRovers(data))
        .catch(error => console.error('Problem med api/rovers/', error));
}

function printRovers(data) {
    for (var i = 0; i < data.length; i++) {
        let rover = data[i];
        let id = rover.id;
        let name = rover.name;
        let roverButton = app.roverButtons[i];
        roverButton.innerHTML = name;
        roverButton.id = id;
        roverButton.addEventListener('click', function () {
            getRoverById(id);
        })
    }
}

function getRoverById(id) {
    fetch('api/rovers/' + id)
        .then(resp => resp.json())
        .then(data => printInfo(data))
        .catch(error => console.error('Problem med api/rovers/', error));
}

function main_divtextEraser() {
    app.main.innerHTML = '';
}

function printInfo(data) {
    main_divtextEraser();
    app.main.innerHTML = `
        <div id="pictureDiv">
        <img src="img/` + data.name + `.jpg"/></div>
        <div id="descriptionDiv"><p><b>Beskrivning:</b><br> ` + data.description + `</p></div>
        <div id="historyDiv"><p> <b>Historia:</b><br>` + data.history + `</p></div>
        <div id="weightDiv"><p> <b>Vikt:<br></b> ` + data.weight + ` kg</p></div>
        <div id="numberofwheelsDiv"><p> <b>Antal hjul:</b><br>` + data.numberOfWheels + `</p></div>
        <button id="pictureBtn" class="btn btn-primary">Visa senaste foton</button><br><br>
        <a href="https://mars.nasa.gov/mer/" class="btn btn-primary" role="button">Mer information (NASA: MARS Exploration Rovers)</a><br><br>
        <a href="https://en.wikipedia.org/wiki/Mars_rover" class="btn btn-primary role="button">Mer information (WIKIPEDIA: Mars rover) --English--</a>
        `;
    pictureBtn.addEventListener('click', function () {
        getlatestPictures(data.nasaURL);
    })
}


function getlatestPictures(nasaURL) {
    fetch('' + nasaURL + 'latest_photos?api_key=' + nasaapiKey + '')
        .then(resp => resp.json())
        .then(data => printlatestPictures(data))
        .catch(error => console.error('Problem med NASA:s Mars Rover Photos API eller API nyckeln.', error));
}

function printlatestPictures(data) {
    main_divtextEraser();
    for (var i = 0; i < data.latest_photos.length; i++) {
        let roverPhoto = data.latest_photos[i].img_src;
        let insertImage = document.createElement('img');
        insertImage.src = roverPhoto;
        app.main.insertAdjacentElement('afterbegin', insertImage)
    }
}
