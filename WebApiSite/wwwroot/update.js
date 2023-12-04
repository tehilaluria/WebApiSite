const update = async () =>
{
   const userJson = sessionStorage.getItem("user")
   if (!userJson)
        return
    const UserId = JSON.parse(userJson).userId
    
    const user =
    {
        UserName: document.getElementById("userNameUpdate").value,
        Password: document.getElementById("passwordUpdate").value,
        firstName: document.getElementById("FirstNameUpdate").value,
        lastName: document.getElementById("LastNameUpdate").value,
        userId: UserId
    }

    try
    {
       
        const res = await fetch(`api/User/${UserId}`,
            {
                method: 'PUT',
                headers: { 'Content-Type': `application/json` },
                body: JSON.stringify(user)
            })
        if (!res.ok)
            alert("error updated to the server,please try again!")
        else
        {

            alert(`user ${UserId} updated succfully`)
        }

    }
    catch (e) {
        alert(e)
    }
}

const hello = () =>
{
    const userToHello = sessionStorage.getItem("user");
    const userToHelloJSON = JSON.parse(userToHello)
    const hello = document.getElementById("hello")
    hello.innerHTML = `Hello ${userToHelloJSON.firstName}! Welcome to our site!`
}

