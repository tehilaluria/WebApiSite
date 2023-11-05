
login = async () =>
{
    //JavaScript function names and variables names should start with camel case
    //userName,password
    try {
        const UserName = document.getElementById("username").value
        const Password = document.getElementById("password").value
        const res = await fetch(`api/User?UserName=${UserName}&Password=${Password}`,
            {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            })

        if (!res.ok)//if res.status==400 for BadRequest() or 401 for unauthorized()! 
            window.alert("NotFound")
        else {
            const user = await res.json()
            sessionStorage.setItem("user", JSON.stringify(user))
            window.location.href = "update.html"
             }
        }

     catch (e) {
        console.log(e);
    }
}

register = async () =>
{
    
    const user = {
       UserName: document.getElementById("userNameRegister").value,
        Password: document.getElementById("passwordRegister").value,
       // FirstName, LastName
       firstName: document.getElementById("FirstName").value, 
       lastName: document.getElementById("LastName").value
    }
    try {
        const res = await fetch('api/User',
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(user)

            })
        if (!res.ok)
            alert("Sorry, we couldn't add you to our site, Try again")
        else {
            const data = await res.json()
            //successfully (spelling)
            alert(`user ${data.userName} registered succfully`)
        }
    }

    catch (err) {
        //Alerting errors to the user is not recommended, only log them to the console.
        alert("something not good... :(")
        console.log(err)
    }
}

//const instead of let! (if you don't change the variable)
checkPassword = async () => {
    var res;
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var password = document.getElementById('passwordRegister').value;
    var meter = document.getElementById('meter');
    var text = document.getElementById('textMeter');
    await fetch('api/User/check',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)

        })
        .then(r => r.json())
        .then(data => res = data)
        meter.value = res;
    if (password !== "") {
        text.innerHTML = "Strength: "+strength[res];
    }
    else {
        text.innerHTML = "No Password";

    }
}

//Check the password's strength in the register function ! (not only when the button clicked)

