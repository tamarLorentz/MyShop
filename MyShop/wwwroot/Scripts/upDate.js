let resPas;
const GetDataFromUpDate = () => {
    const userName = document.getElementById("userName").value
    const password = document.getElementById("password").value
    const firstName = document.getElementById("firstName").value
    const lastName = document.getElementById("lastName").value

    if (!lastName || !firstName || !password || !userName)
        alert("all fields are requierd")
    else if (resPas < 3)
        alert("yout password is not enough strong")
    else
        return ({ lastName, firstName, password, userName })
}

const UpDate = async () => {
    try {
        const id = sessionStorage.getItem("currentUserId")
        const user = GetDataFromUpDate()
        if (user) {
            const responsePut = await fetch(`api/Users/${id}`, {
                method: 'PUT',
                headers: {
                    'content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            });
           
          
            alert("upDate successfully")
        }
    }
    catch (Error) {
        console.log('error:',Error)

    }
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


   
