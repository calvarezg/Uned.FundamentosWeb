function findMostExpensiveItem() {
    
    $("div.item").removeClass("most-expensive");
    let maxPrice = 0;
    let elementWithMaxPrice = null;

    $("span.item-price").each(function (i, element) {
        let price = convertToNumber(element);
        if (price > maxPrice) {
            elementWithMaxPrice = element;
            maxPrice = price;
        }
    });

    $(elementWithMaxPrice).parent().addClass("most-expensive");
}

function convertToNumber(element) {
    let elementContent = element.innerText;
    let elementContentWithoutCurrencySymbol = elementContent.replace("$", "");
    return elementContentWithoutCurrencySymbol;
}
