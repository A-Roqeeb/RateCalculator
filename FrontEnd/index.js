let rate = 0;
const baseURL = `http://localhost:5019`;

async function init() {
    const getRateAPIResponse = await fetch(`${baseURL}/api/Rate/get-rate`);
    const rateResponse = await getRateAPIResponse.json();

    rate = rateResponse.rate;

    const exchangeRate = document.getElementById(`exchange-rate`);

    if (exchangeRate) {
        exchangeRate.innerHTML = `1 GBP = ${rate} NGN`;
    }

    const gbpInputs = document.getElementsByClassName(`from-currency`);
    const ngnInputs = document.getElementsByClassName(`to-currency`);

    if (gbpInputs.length && ngnInputs.length) {
        const gbpInput = gbpInputs[0];
        const ngnInput = ngnInputs[0];

        gbpInput.addEventListener(`input`, (event) => {
            const ngncalculatedValue = event.target.valueAsNumber * rate;
            ngnInput.value = ngncalculatedValue.toFixed(2);            
        });

        ngnInput.addEventListener(`input`, (event) => {
            const gbpcalculatedValue = event.target.valueAsNumber / rate;
            gbpInput.value = gbpcalculatedValue.toFixed(2);            
        });
    }
}

setTimeout(async () => {
    await init();
}, 1000)