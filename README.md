# Random values generating - Unit tests

###### The open source library to generate random values for string, float,date, double and decimal.
###### Very helpful in unit tests or random values to fill database tables.

#### Positive float
```cs
float floatValue = Some.PositiveFloat();
```
will generate random value from 0 to max float value. 

#### Negative float
```cs
float floatValue = Some.NegativeFloat();
```
will generate random float value from min float to 0.

#### Float with range
```cs
float floatValue = Some.Float(99.1f, 341.21f);
```

will generate float random value between **99.1f** and **341.21f**  

#### Future date 
```cs
float floatValue = Some.FutureDate();
```

#### Past date
```cs
float floatValue = Some.PastDate();
```
