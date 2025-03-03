let categoriesArr = []
const OnLoad = async() => {
  await LoadCategories()
await GetProducts()
   
}
/*    const responsePost = await fetch(`api/Users/LogIn?userName=${postData.userName}&password=${postData.password}`, {
                method: 'POST',
                headers: {
                    'content-Type': 'application/json'
                },
                query: { userName: postData.userName, password: postData.password }*/
const GetProducts = async () => {
    const element = getElementFilter()
    let url = "api/Products"
    if (element.minPrice || element.maxPrice || element.namesearch || categoriesArr>0) {
        url += '?'
        if (element.minPrice)
            url += `&minPrice=${element.minPrice}`
        if (element.maxPrice)
            url += `&maxPrice=${element.maxPrice}`
        if (element.namesearch)
            url += `&desc=${element.namesearch}`
        for (let i = 0; i < categoriesArr.length; i++)
            url += `&categoryIds=${categoriesArr[i]}`
    }
  
    try {
        const productsGet = await fetch(url, {
            method: 'Get',
            headers: {
                'content-Type': 'application/json'
            },
            query: { categoryIds: categoriesArr, minPrice: element.minPrice, maxPrice: element.maxPrice, desc: element.namesearch }
        });
        products = await productsGet.json()
        console.log(products)
         LoadProducts(products);
    }
    catch (Error) {
        console.log(Error)
    }
const cart =  gatCart()
    document.getElementById("ItemsCountText").innerText = cart.length
}
const gatCart = () => {
    let cart = sessionStorage.getItem('cart')
    cart = cart ? JSON.parse(cart) : []
return cart}

const LoadProducts = async (products) => {
    
   
    let tmp = document.getElementById("temp-card");
    document.getElementById("PoductList").innerHTML = ""
    products.forEach(product => { 
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = "./Images/" + product.image
    cloneProduct.querySelector("h1").textContent = product.name
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.description
    cloneProduct.querySelector("button").addEventListener('click', () => { addToCart(product) })

    document.getElementById("PoductList").appendChild(cloneProduct)
    })
    document.getElementById("counter").innerHTML = products.length
}
const GetCategories = async () => {
    console.log("Categories")
    try {
        const categoryGet = await fetch('api/Categories', {
            method: 'Get',
            headers: {
                'content-Type': 'application/json'
            }
        });
        if (!categoryGet.ok) {
            throw new Error(`http error ${categoryGet.status}`)
        }
        Categories = await categoryGet.json()
        console.log(Categories)
        return Categories;
    }
    catch (Error) {
        console.log(Error)
    }
}
const LoadCategories = async () => {
    const categories = await GetCategories();
    let tmp = document.getElementById("temp-category");
    categories.forEach(category => {
        let cloneCategory = tmp.content.cloneNode(true)
        cloneCategory.querySelector(".OptionName").textContent = category.name
        cloneCategory.querySelector(".opt").addEventListener('change', () => { changeArrayCategory(category.id) } )
        //cloneCategory.querySelector("input").id = category.id
        document.getElementById("categoryList").appendChild(cloneCategory)
    })
}
const changeArrayCategory = (id) => {
   
    if (categoriesArr.find(c=>c==id)) {
      categoriesArr = categoriesArr.filter(c=>c!=id)
    }
    else {
        categoriesArr.push(id)
    }
    console.log(categoriesArr)
    filterProducts()
}
const getElementFilter = () => {
    const namesearch = document.querySelector("#nameSearch").value
    
    const maxPrice = document.querySelector("#maxPrice").value
 

    const minPrice = document.querySelector("#minPrice").value
    return { namesearch, maxPrice, minPrice }
}
const filterProducts = () => {
    GetProducts()

}
const addToCart = (product) => {
        let cart = gatCart()
        cart.push(product)
        sessionStorage.setItem('cart', JSON.stringify(cart))
        document.getElementById("ItemsCountText").innerText = cart.length
      //  alert("המוצר נוסף בהצלחה!") 
}
const TrackLinkID =()=> {
    //development
    //sessionStorage.setItem('currentUserId', 2)
    const user = sessionStorage.getItem('currentUserId')
    if (user == null) {
        const result = confirm("אינך מחובר! לחץ אישור להתחברות")
        if (result)
            window.location.href = "/login.html"
    }
    else {
        window.location.href ="/upDateUser.html"
    }
}

