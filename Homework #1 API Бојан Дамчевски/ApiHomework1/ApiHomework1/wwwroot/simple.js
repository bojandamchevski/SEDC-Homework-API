let getAllBtn = document.getElementById("btn1");
let getByIdBtn = document.getElementById("btn2");
let addNoteBtn = document.getElementById("btn3");
let deleteBtn = document.getElementById("deleteBtn");
let getByIdInput = document.getElementById("input2");
let addNoteInput = document.getElementById("input3");
let deleteInput = document.getElementById("delete");

let port = "53562";
let getAllNotes = async () => {
    let url = "http://localhost:" + port + "/api/users";

    let response = await fetch(url);
    console.log(response);
    let data = await response.json();
    console.log(data);
};

let getNoteById = async () => {
    let url = "http://localhost:" + port + "/api/users/" + getByIdInput.value;

    let response = await fetch(url);
    let data = await response.text();
    console.log(data);
};

let addNote = async () => {
    let url = "http://localhost:" + port + "/api/users";
    var response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'text/plain'
        },
        body: addNoteInput.value
    });
    var data = await response.text();
    console.log(data);
}

let deleteNote = async () => {
    let url = "http://localhost:" + port + "/api/users";
    var response = await fetch(url, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'text/plain'
        },
        body: deleteInput.value
    });
    var data = await response.text();
    console.log(data);
    console.log(response);
}

getAllBtn.addEventListener("click", getAllNotes);
getByIdBtn.addEventListener("click", getNoteById);
addNoteBtn.addEventListener("click", addNote);
deleteBtn.addEventListener("click", deleteNote);