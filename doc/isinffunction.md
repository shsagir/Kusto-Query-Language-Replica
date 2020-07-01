# isinf()

Returns whether input is an infinite (positive or negative) value.  

**Syntax**

`isinf(`*x*`)`

**Arguments**

* *x*: A real number.

**Returns**

A non-zero value (true) if x is a positive or negative infinite; and zero (false) otherwise.

**See also**

* For checking if value is null, see [isnull()](isnullfunction.md).
* For checking if value is finite, see [isfinite()](isfinitefunction.md).
* For checking if value is NaN (Not-a-Number), see [isnan()](isnanfunction.md).

**Example**

<!-- csl -->
```
range x from -1 to 1 step 1
| extend y = 0.0
| extend div = 1.0*x/y
| extend isinf=isinf(div)
```

|x|y|div|isinf|
|---|---|---|---|
|-1|0|-âˆž|1|
|0|0|NaN|0|
|1|0|âˆž|1|

