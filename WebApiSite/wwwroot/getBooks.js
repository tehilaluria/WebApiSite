
const getBooks = async (desc, minPrice, maxPrice, categoryIds) =>
{

    try {
        let url = `api/Book`;
        if (desc || minPrice || maxPrice || categoryIds)
            url += `?`
        if (desc) url += `&desc=${desc}`;
        if (minPrice) url += `&minPrice=${minPrice}`;
        if (maxPrice) url += `&maxPrice=${maxPrice}`;
        if (categoryIds) {
            for (let i = 0; i < categoryIds.length; i++) {
                url += `&categoryIds=${categoryIds[i]}`
            }
        }
        const res = await fetch(url)

        if (!res.ok)
            window.alert("NotFound")
        else {

            let booksArray = await res.json()

            document.getElementById("counter").innerText = booksArray.length;
            for (let i = 0; i < booksArray.length; i++) {
                drawCard(booksArray[i])

            }

        }

    }

    catch (e)
    {
        console.log(e);
    }
    if (localStorage.length > 1) {
        document.getElementById("ItemsCountText").innerText = (JSON.parse(localStorage.getItem("ArrayCard"))).length;
    }
}

const drawCard = (book) => {
    var tmpBook = document.getElementById("temp-card");
    var cln = tmpBook.content.cloneNode(true);
    cln.querySelector("img").src = "images/" + book.image;
    cln.querySelector("h1").innerText = book.bookName;
    cln.querySelector("p.price").innerText = book.price + '$';
    cln.querySelector("p.auther").innerText = book.auther;
    cln.querySelector("button").addEventListener('click', () => { insertToCart(book) })
    document.getElementById("BookList").appendChild(cln);
}

const getAllCartegories = async () => {
    try {
        const res = await fetch("api/Category")
        const Categories = await res.json();
        return Categories;
    }
    catch (ex) {
        console.log(ex);
    }
}

const showCategories = async () => {
    const Categories = await getAllCartegories();
    for (let i = 0; i < Categories.length; i++) {
        var tmpCatg = document.getElementById("temp-category");
        var cln = tmpCatg.content.cloneNode(true);
        cln.querySelector("label").for = Categories[i].categoryName;
        cln.querySelector("input").value = Categories[i].categoryName;
        cln.querySelector("input").id = Categories[i].categoryId;
        cln.querySelector("span.OptionName").innerText = Categories[i].categoryName;
        document.getElementById("categoryList").appendChild(cln);
    }
}

const showFilter = async () => {
    let checkedCategories = [];
    const allCategoriesOptions = document.querySelectorAll(".opt");
    for (let i = 0; i < allCategoriesOptions.length; i++) {
        if (allCategoriesOptions[i].checked) checkedCategories.push(allCategoriesOptions[i].id)
    }
    let minPrice = document.getElementById("minPrice").value;
    let maxPrice = document.getElementById("maxPrice").value;
    let desc = document.getElementById("nameSearch").value;
    document.getElementById("BookList").replaceChildren([]);
    getBooks(desc, minPrice, maxPrice, checkedCategories);

}

const insertToCart = (book) => {
    document.getElementById("ItemsCountText").innerText++;
    if (localStorage.length == 1) localStorage.setItem("ArrayCard", "[]");
    let card = JSON.parse(localStorage.getItem("ArrayCard"));
    arrayCard = [...card, book];
    let ArrayCard = JSON.stringify(arrayCard);
    localStorage.ArrayCard = ArrayCard;
    window.alert("���" + book.bookName.trim() + "  ���� ������!")
}
