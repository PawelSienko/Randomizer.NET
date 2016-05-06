# Some
###### The open source lightweight library to generate random values for string, float, date, double and decimal.
###### Very helpful in unit tests or random values to fill database tables.
###### 100% of code covered by UnitTests (NUnit)

![alt tag](https://travis-ci.org/PawelSienko/Some.svg?branch=master)

#### Initialize seed value
```cs
public static int Seed
       {
           get { return seed; }
           set
           {
               seed = value;
               randomizer = new Random(seed);
           }
       }
```

#### Positive float
```cs
float floatValue = Some.PositiveFloat();
```
will generate random value from 0 to [max float](https://msdn.microsoft.com/pl-pl/library/b1e65aza.aspx). 

#### Negative float
```cs
float floatValue = Some.NegativeFloat();
```
will generate random float value from [min float](https://msdn.microsoft.com/pl-pl/library/b1e65aza.aspx) to 0.

#### Float with range
```cs
float floatValue = Some.Float(99.1f, 341.21f);
```

will generate float random value between **99.1f** and **341.21f**.  

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

#### Date with range
```cs
DateTime date = Some.Date(DateTime.Now, DateTime.Now.AddDays(10));
```
will generate date withing specified range in input parameters of invoking method.

#### String (only letters)
```cs
string randomString = Some.String(20);
```
will generate string with 20 random characters.

#### Lowercase string (only letters)
```cs
string randomString = Some.StringLower(20);
```
will generate 20 lowercase characters as string.

#### Uppercase string (only letters)
```cs
string randomString = Some.StringUpper(20);
```
will generate 20 uppercase characters as string.

#### String with digits
```cs
string randomString = Some.DigitsAsString(20);
```
will generate 20 digits as string. 

#### Integer
```cs
int randomInteger = Some.Integer();
```
will return random [integer](https://msdn.microsoft.com/en-us/library/5kzh1b5w.aspx) value. 

#### Integer within range
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
will return random [double](https://msdn.microsoft.com/pl-pl/library/678hzkk9.aspx) value.

#### Double within range
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
double randomDouble = SomeItem.NegativeDouble();
```
will return only negative double value.

#### Decimal
```cs
decimal randomDecimal = SomeItem.Decimal();
```
will return radnom [decimal](https://msdn.microsoft.com/pl-pl/library/364x0z75.aspx) value.
