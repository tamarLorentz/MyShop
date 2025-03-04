
let resPas;
const CloseSignIn = () => {
    console.log("aaa");
    
    const signInDiv = document.querySelector('.signIn_div');
    if (signInDiv) {
        signInDiv.style.display = 'none';
    }
}

const GetDataFromSignIn = () => {
    CheckPassword()
    const userName = document.getElementById("userName").value
    const password = document.getElementById("password").value
    const firstName = document.getElementById("firstName").value
    const lastName = document.getElementById("lastName").value
    if (userName.indexOf('@') == -1 || userName.indexOf('@') == userName.length-1)
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
                method: 'GET',
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
    document.getElementById('login_div').style.display = 'none'
        document.querySelector('.signIn_div').style.display = 'block';
    // const signIn1 = document.querySelector(".signIn_div")
    // signIn1.classList.remove("signIn_div")
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
            const userPost = await responsePost.json()
            console.log(userPost)
            alert("signIn successfully")
            document.querySelector('.signIn_div').style.display = 'none';
            document.getElementById('login_div').style.display = 'block';
        }
    }
    catch (Error) {
        console.log(Error)

    }
}

const UpDate = async () => {
    try {
       
        const id = sessionStorage.getItem("currentUserId")
        const user = GetDataFromSignIn()
        if (user) {
            const responsePut = await fetch(`api/Users/${id}`, {
                method: 'PUT',
                headers: {
                    'content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });


            alert("upDate successfully")
            window.location.href = "home.html"
        }
    }
    catch (Error) {
        console.log('error:', Error)

    }
}
const Details = async () => {
    const id = sessionStorage.getItem("currentUserId")
    if (id) {
        const currentUser =await  GetUserById(id);
        console.log(currentUser)
        document.getElementById("userName").value = currentUser.userName
       // document.getElementById("password").value = ""
        document.getElementById("firstName").value = currentUser.firstName
        document.getElementById("lastName").value = currentUser.lastName
    }
    else {
    alert("אינך משתמש רשום")
    window.location.href = "/home.html"
}
}
const GetUserById = async (id) => {
   
        try {
            const UserById = await fetch(`api/Users/${id}`, {
                method: 'Get',
                headers: {
                    'content-Type': 'application/json'
                }
            });

            if (!UserById.ok) {
                throw new Error(`http error ${UserById.status}`)
            }
            currentUser = await UserById.json()
           
            return currentUser;
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
                window.location.href="home.html"
            }

        }
    catch (Error) {
            console.log(Error)


        }
    }
}
/* JavaScript להחלפת תצוגה */

    // const  OpenSignIn =()=> {
    //     document.getElementById('login_div').style.display = 'none'
    //     document.getElementById('signIn_div').style.display = 'block';
    // }

    // function CloseSignIn() {
    //     alert('Registration successful! Redirecting to login.');
    //     document.getElementById('signIn_div').style.display = 'none';
    //     document.getElementById('login_div').style.display = 'block';
    // }




