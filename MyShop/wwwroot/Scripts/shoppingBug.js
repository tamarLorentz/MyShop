
const getCart=() => {
    let cart = sessionStorage.getItem('cart')
    cart = cart ? JSON.parse(cart) : []
    return cart
}
const OnLoad = () => {
    loadCart()
}
loadCart = () => {
    document.querySelector("tbody").innerHTML = ""
   const cart = getCart()
    let tmp = document.querySelector("#temp-row");
    cart.forEach(ProductCart => {
        let cloneProductCart = tmp.content.cloneNode(true)
        cloneProductCart.querySelector('.image').style.backgroundImage = `url(/Images/${ProductCart.image})`  
        cloneProductCart.querySelector(".itemName").innerText = ProductCart.name
        cloneProductCart.querySelector(".price").innerText = ProductCart.price
        cloneProductCart.querySelector(".showText").addEventListener('click', () => { removeProduct(ProductCart) })

        document.querySelector("tbody").appendChild(cloneProductCart)
      
    })
    totalAmount()
    document.querySelector("#itemCount").innerText = cart.length
}
const totalAmount = () => {
    const cart = getCart()
    const initialValue = 0;
    const sum = cart.reduce(
        (accumulator, currentValue) => accumulator + currentValue.price,initialValue,);
 
    const totalAmount = document.querySelector("#totalAmount")
    console.log(sum +" "+ totalAmount)
    totalAmount.textContent =sum
}
const removeProduct = (ProductCart) => {
   
    let cart = getCart()
    let flag = false
    cart = cart.filter(p => {
        if (p.id == ProductCart.id && !flag) {
            flag = true
            return false;
        }
        else return true
    })
    sessionStorage.setItem('cart', JSON.stringify(cart))

        loadCart()
    
}


const placeOrder = async () => {
    //development
    //sessionStorage.setItem('currentUserId', 2)
    const user = sessionStorage.getItem('currentUserId')
    if (user == null) {
        const result = confirm("אינך מחובר! לחץ אישור להתחברות")
        if (result)
            window.location.href = "/login.html"
    }
    else {
        try {
            const order = GetData()
            if (order) {
                const responsePost = await fetch('api/Orders', {
                    method: 'POST',
                    headers: {
                        'content-Type': 'application/json'
                    },
                    body: JSON.stringify(order)
                });
                const orderPost = await responsePost.json()
                console.log(orderPost)
                alert(`order ${orderPost.id} created successfully`)
                document.location.href = "/home.html";
            }
        }
        catch (Error) {
            console.log(Error)

        }
        sessionStorage.removeItem('cart')
        loadCart()
    }
}
    const GetData = () => {
        const OrderItems = []
        const cart = getCart()
        let Sum=0;
        for (let i = 0; i < cart.length; i++) {
            Sum+=cart[i].price
            const orderItem = OrderItems.find(oi => oi.ProuductId == cart[i].id)
            if (orderItem)
                orderItem.Quantity++;
            else
                OrderItems.push({ ProuductId: cart[i].id, Quantity: 1 })
        }
        const UserId = sessionStorage.getItem('currentUserId')
        console.log("sum:"+Sum)
        return { UserId, OrderItems ,Sum}
    }

