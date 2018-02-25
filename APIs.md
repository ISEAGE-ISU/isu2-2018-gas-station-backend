# Backend Server APIs
## Get gas prices
### Request
Verb: `GET`  
Path: `/getGasPrices`  
Body: N/A

### Response
Array of prices for regular, plus, and premium.
```
[
    3.51,
    3.61,
    3.71
]
```

## Set gas price
### Request
Verb: `POST`  
Path: `/setGasPrice`  
Body:  
Grade of gas, where regular => 0, plus => 1, and premium => 2.

```
{
  "grade": 1,
  "price": 3.80
}
```

### Response
```
true
```

## Authorize gas dispense
This is when the customer has prepaid for gas at the cashier.
### Request
Verb: `POST`  
Path: `/dispenseGas`  
Body:  
Pump is the pump number that will allow gas to be pumped.

```
{
  "pump": 1,
  "gallons": 2.1,
  "grade": 1
}
```

### Response
```
true
```

## Take gas preauth
This **consumes** an authorization for gas to be dispensed at a specific pump.
### Request
Verb: `GET`  
Path: `/getPrepayStatus?pump=0` (substitute any pump number)  

### Response
`prepay` is a boolean (0=false, 1=true) of if a prepay has been made for the
pump. `dollars` is the amount of gas that's been prepaid, rounded to the nearest
whole number (0 if `prepay==0`).

Note that calling this API will will reset `prepay` to 0 after returning the
response.
```
{
  "prepay": 1,
  "dollars": 1
}
```

## Process financial transaction
This processes a payment for one or more items.
### Request
Verb: `POST`  
Path: `/doTransaction`  
Body:  
The credit card number (or "cash" for cash). An array of items.
Gas should be described as its grade. i.e. "Premium" would be a
valid description.

```
{
  "cc": "1234123412341234",
  "items": [
    {
      "description": "rice",
      "price": 13.37
    },
    {
      "description": "soooooshiiiiiii",
      "price": 1.01
    }
  ]
}
```

### Response
```
true
```

## Get transaction log
### Request
Verb: `GET`  
Path: `/getTransactions`  

### Response
```
[
  {
    "txid": 0,
    "time": "2018-02-01T13:01:01Z",
    "cc": "1234123412341234",
    "total": 14.38
  },
  {
    "txid": 1,
    "time": "2018-02-02T13:01:01Z",
    "cc": "cash",
    "total": 5.01
  }
]
```