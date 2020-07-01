# hash()

Returns a hash value for the input value.

**Syntax**

`hash(`*source* [`,` *mod*]`)`

**Arguments**

* *source*: The value to be hashed.
* *mod*: An optional module value to be applied to the hash result, so that
  the output value is between `0` and *mod* - 1

**Returns**

The hash value of the given scalar, modulo the given mod value (if specified).

> [!WARNING]
> The algorithm used to calculate the hash is xxhash.
> This algorithm might change in the future, and the only guarantee is that
> within a single query all invocations of this method use the same algorithm.
> Consequently, users are advised to not store the results of `hash()` in a
> table. If persisting hash values is required, consider using
> [hash_sha256()](./sha256hashfunction.md) instead (but note that
> it is far more complex to calculate than `hash()`).

**Examples**

<!-- csl -->
```
hash("World")                   // 1846988464401551951
hash("World", 100)              // 51 (1846988464401551951 % 100)
hash(datetime("2015-01-01"))    // 1380966698541616202
```

The following example uses the hash function to run a query on 10% of the data,
It is helpful to use the hash function for sampling the data when assuming the value is uniformly distributed (In this example StartTime value)

<!-- csl: https://help.kusto.windows.net:443/Samples -->
```
StormEvents 
| where hash(StartTime, 10) == 0
| summarize StormCount = count(), TypeOfStorms = dcount(EventType) by State 
| top 5 by StormCount desc
```
