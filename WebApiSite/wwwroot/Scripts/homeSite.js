﻿
const login = async () =>
{
    try
    {
        const user =
        {
            userName: document.getElementById("userName").value,
            password: document.getElementById("password").value
        }
        const res = await fetch(`api/User/login`, {
            method: "POST",
            headers: {
            "Content-Type": "application/json"
        }, body: JSON.stringify(user)
        })

        if (!res.ok )
            window.alert("Error ")
        else
        {
            const user = await res.json()
            sessionStorage.setItem("user", JSON.stringify(user))
            window.location.href = "BookStore.html"

         }
     }

     catch (e) {
        console.log(e);
    }
}

const register = async () =>
{
    
    const user = {
       UserName: document.getElementById("userNameRegister").value,
       Password: document.getElementById("passwordRegister").value,
       FirstName: document.getElementById("firstName").value, 
       LastName: document.getElementById("lastName").value
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
        else
        {
            const data = await res.json()
            alert(`user ${data.userId} registered successfully`)
        }
    }

    catch (err) {
        alert("Error")
        console.log(err)
    }
}

const checkPassword = async () =>
{
    var res;
    var strength =
    {
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
    if (password !== "")
    {
        text.innerHTML = "Strength: "+strength[res];
    }
    else
    {
        text.innerHTML = "No Password";
    }
}

const update = () =>
{

    window.location.href = "update.html"
}