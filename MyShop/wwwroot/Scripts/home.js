const GetProducts = async () => {
    try {
        const productsGet = await fetch('api/Products', {
            method: 'Get',
            headers: {
                'content-Type': 'application/json'
            }
        });
        products = await productsGet.json()
        console.log(products)
        return products;
    }
    catch (Error) {
        console.log(Error)
    }
   
}

const LoadProducts = () => {
    const products = GetProducts()

}

