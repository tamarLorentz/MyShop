const GetDataFromUpDate = () => {
    const userName = document.getElementById("userName").value
    const password = document.getElementById("password").value
    const firstName = document.getElementById("firstName").value
    const lastName = document.getElementById("lastName").value

    if (!lastName || !firstName || !password || !userName)
        alert("all fields are requierd")
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




   
