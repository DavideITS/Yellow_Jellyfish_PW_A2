# Protocol Documentation

## Byte send From PIC to Gateway

In the first table is shown the byte array that the pic send to the Gateway


|     0    |      1      | 2 |     3    | 4 |       5      | 6 | 7 |
|:--------:|:-----------:|:-:|:--------:|:-:|:------------:|:-:|:-:|
| Wagon ID | Temperature |   | Humidity |   | Smoke Sensor |   | * |
|          |     |       |   |          |                  |   |   |


In thisseond table is shown the organization of the 8th byte of the previous array with his specifics


| 7.7 | 7.6 | 7.5 |        7.4        |         7.3        |         7.2        |         7.1        |         7.0        |
|:---:|:---:|:---:|:-----------------:|:------------------:|:------------------:|:------------------:|:------------------:|
|     |     |     | Toilette door state | Wagon port state |  Wagon port state |  Wagon port state |  Wagon port state |
|     |     |     |                   |                    |                    |                    |                    |


## Menu button pin-out


|        RB0       |       RB1      |         RB2         |      RB3      |
|:----------------:|:--------------:|:-------------------:|:-------------:|
| Scroll down Menu | Scroll up Menu | Enter/Exit Sub-Menu | Select Option |
|                  |                |                     |               |