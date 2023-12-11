

const goToCart = () => {
    let sum = 0;
    let newArrayCart = JSON.parse(localStorage.getItem("ArrayCard"));
    document.getElementById("itemss").replaceChildren([]);
    for (let i = 0; i < (newArrayCart).length; i++) {
             drawCart(newArrayCart[i]);
        sum += newArrayCart[i].price;
      
    }

    document.getElementById("totalAmount").innerText = sum  ;
    document.getElementById("itemCount").innerText = newArrayCart.length;
}

const drawCart = (book) =>
{
    var tmpBook = document.getElementById("temp-row");
    var cln = tmpBook.content.cloneNode(true);
    cln.querySelector(".image").src = "images/" + book.image;;
    cln.querySelector(".descriptionColumn").innerText = book.bookName;
    cln.querySelector(".price").innerText = book.price+"¤";
    cln.querySelector("button").addEventListener("click", () => { deleteProduct(book) })
    document.getElementById("itemss").appendChild(cln);
    
}

const deleteProduct = (book1) =>
{
    let newArrayCartt = JSON.parse(localStorage.getItem("ArrayCard"));
    let index = newArrayCartt.findIndex(x => ( x.bookName == book1.bookName) )
    newArrayCartt.splice(index, 1);
    localStorage.setItem("ArrayCard", JSON.stringify(newArrayCartt))

    goToCart()

}

const placeOrder = () =>
{
    let orderCart = JSON.parse(localStorage.getItem("ArrayCard"));
    if (!orderCart)
        return
     if (!sessionStorage.getItem("user"))
         window.location.href = "HomeSite.html";

    let orderItemsArr = [];

    for (let i = 0; i < orderCart.length; i++) {
        if (orderItemsArr.find(p => p.BookId == orderCart[i].bookId)) {
            const o = orderItemsArr.find(p => p.BookId == orderCart[i].bookId);
            o.Quantity += 1;
        }
        else {
            let orderItem = {
                BookId: orderCart[i].bookId,
                Quantity: 1
            }
            orderItemsArr.push(orderItem);
        }
    }
    const user = sessionStorage.getItem("user");
    const userJson = JSON.parse(user);

    const order = {
        OrderDate: new Date(),
        UserId: userJson.userId,
        OrderSum: parseInt(document.getElementById("totalAmount").innerText),
        OrderBooks: orderItemsArr
    }

    addOrderToDB(order);

}   

const addOrderToDB = async (order) =>
{

   try
   {
    const res = await fetch('api/Order',
      {
       method: 'POST',
       headers: { 'Content-Type': 'application/json' },
       body: JSON.stringify(order)

      })
     if (!res.ok || res.status==204)
         alert("Sorry, your order isn't created, Try again")
     else {
            const data = await res.json()
           alert(`${data.orderId} added succfully`)
          }
    }
   catch (err)
   {
            console.log(err);
   }
 }

