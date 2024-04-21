document.addEventListener("DOMContentLoaded", function () {
    const CalculateRentalPriceButton = document.getElementById("CalculateRentalPriceButton");
    CalculateRentalPriceButton.addEventListener("click", function (event) {
        event.preventDefault();
        CalculateRentalPrice();
    });
});

async function CalculateRentalPrice() {
    try {
        let Response = await fetch('https://localhost:7072/Rental/GetRentalPrice');
        let Data = await Response.json()
        const RentalPrice = document.getElementById("RentalPrice");
        RentalPrice.value = Data.RentalPrice;
        console.log(Data);
    }
    catch (error) {
        console.log("Error" + error);
    }
}

document.addEventListener("DOMContentLoaded", function () {
    var VehicleWashButton = document.getElementById("VehicleWashButton");
    VehicleWashButton.addEventListener('change', function () {
        const VehicleWashPrice = document.getElementById("VehicleWashPrice");
        
        if (this.checked) {
            VehicleWashPrice.value = "15000";
        } else {
            VehicleWashPrice.value = "";
        }
    });
});