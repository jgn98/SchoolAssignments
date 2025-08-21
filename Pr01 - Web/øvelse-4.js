console.log("Hello World!");


function Alert(){
    let name = document.getElementById("name").value;
    let age = document.getElementById("age").value;

    console.log(`${name} er ${age} år gammel`);

    if (age >= 70)
    alert(`Dav ${name}, du er gammel!`);
    else if(age <= 60)
    alert(`Dav ${name}, du er ung`)
    else
    alert(`Dav`)
}