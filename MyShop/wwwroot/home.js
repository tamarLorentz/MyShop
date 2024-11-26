
let resPas;
const GetDataFromSignIn = () => {
    const userName = document.getElementById("userName").value
    const password = document.getElementById("password").value
    const firstName = document.getElementById("firstName").value
    const lastName = document.getElementById("lastName").value
     if (userName.indexOf('@') == -1)
         alert("email is wrong")
     else if (resPas < 3)
         alert("yout password is not enough strong")
     else if (firstName.length < 2 || firstName.length > 20 || lastName.length < 2 || lastName.length > 20)
        alert("firstName,lastName need between 2 to 20")

    else if (!lastName || !firstName || !password || !userName)
        alert("all fields are requierd")
     
else
    return ({ lastName, firstName, password, userName })
}
const CheckPassword = async () => {
    const password = document.getElementById("password").value
    if (password) {
        try {
            let responsePost = await fetch(`api/Users/check?password=${password}`, {
                method: 'POST',
                headers: {
                    'content-Type': 'application/json'
                },
                query: { password }
            });

            if (!responsePost.ok)
                throw new Error(`http error ${responsePost.status}`)
            else {
               resPas = await responsePost.json()
                console.log(resPas) 
                const progress = document.querySelector("progress")
                progress.value = resPas;
                
                
            }



        }
        catch (Error) {
            console.log(Error)
        }
    }
}
const OpenSignIn = () => {
    const signIn1 = document.querySelector(".signIn_div")
    signIn1.classList.remove("signIn_div")
}
const SignIn = async () => {
    try {
        const user = GetDataFromSignIn()
        if (user) {
            const responsePost = await fetch('api/Users', {
                method: 'POST',
                headers: {
                    'content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });
            //if status==400
            //weak password
            //if !ok
            //error
            const userPost = await responsePost.json()
            console.log(userPost)
            alert("signIn successfully")
        }
    }
    catch (Error) {
        console.log(Error)

    }
}
const GetDataFromLogIn=() => {
    const userName = document.getElementById("userNameLogIn").value
    const password = document.getElementById("passwordLogIn").value
    if (!userName || !password)
        alert("all fields are required")
    return ({ userName, password })
}
const LogIn = async () => {

    const postData = GetDataFromLogIn()
    
    if (postData) {
        try {
            const responsePost = await fetch(`api/Users/LogIn?userName=${postData.userName}&password=${postData.password}`, {
                method: 'POST',
                headers: {
                    'content-Type': 'application/json'
                },
                query: { userName: postData.userName, password: postData.password }
            });
            if (!responsePost.ok)
                throw new Error(`http error ${responsePost.status}`)
            if (responsePost.status == 204)
                alert("user not found")
            else {
                const userPost = await responsePost.json()
                console.log(userPost)
                alert("logIn successfully")
                sessionStorage.setItem("currentUserId", userPost.id)
                window.location.href="upDateUser.html"
            }

        }
    catch (Error) {
            console.log(Error)


        }
    }
}




