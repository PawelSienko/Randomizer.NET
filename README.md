# Some
# 100% percent covered by UnitTests (NUnit)
###### The open source library to generate random values for string, float, date, double and decimal.
###### Very helpful in unit tests or random values to fill database tables.

#### Positive float
```cs
float floatValue = Some.PositiveFloat();
```
will generate random value from 0 to max float. 

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

#### Future date and time
```cs
DateTime futureDate = Some.FutureDate();
```
will return newer date and time when invoked. 

#### Past date and time
```cs
DateTime pastDate = Some.PastDate();
```
will return older date and time when invoked.

#### String (only letters)
```cs
string randomString = Some.String(MaxRandom.Twenty);
```
will generate string with 20 random characters.

The same is for other values of **MaxRandom** enum.

#### MaxRandom
To avoid out of memory exception **MaxRandom** enum is defined.
```cs
public enum MaxRandom
    {
        Ten = 10,

        Twenty = 20,

        Hundred = 100,
    }
```
#### Lowercase string (only letters)
```cs
string randomString = Some.StringLower(MaxRandom.Twenty);
```
will generate 20 lowercase characters as string.

#### Uppercase string (only letters)
```cs
string randomString = Some.StringUpper(MaxRandom.Twenty);
```
will generate 20 uppercase characters as string.

#### String with digits
```cs
string randomString = Some.DigitsAsString(MaxRandom.Twenty);
```
will generate 20 digits as string. 

#### Integer
```cs
int randomInteger = Some.Integer();
```
will return random integer value. 

#### Integer with range
```cs
int randomInteger = Some.Integer(100, 456);
```
will return random integer value between **100** and ***456***;

#### Positive integer
```cs
int positiveInteger = Some.PositiveInteger();
```
will return random positive integer value.

#### Negative integer
```cs
int negativeInteger = Some.NegativeInteger();
```
will return random negative integer value.

#### Double
```cs
double randomDouble = Some.Double();
```
will return random double value.

#### Double with range
```cs
double randomDouble = SomeItem.Double(1.765d, 100.091892d);
```
will return random double value between **1.765d** and **100.091892d**. 

#### Positive double
```cs
double randomDouble = SomeItem.PositiveDouble();
```
will return only positive double value.

#### Negative double
```cs
double randomDouble = SomeItem.PositiveDouble();
```
will return only negative double value.

#### Decimal
```cs
decimal randomDecimal = SomeItem.Decimal();
```
will return radnom decimal value.

#### Single character
```cs
char randomChar = SomeItem.RandomCharacter('f', 'x');
```
will return random character between **f** and **x**.
