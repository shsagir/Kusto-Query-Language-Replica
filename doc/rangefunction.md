# range()

Generates a dynamic array holding a series of equally-spaced values.

**Syntax**

`range(`*start*`,` *stop*[`,` *step*]`)` 

**Arguments**

* *start*: The value of the first element in the resulting array. 
* *stop*: The value of the last element in the resulting array,
or the least value that is greater than the last element in the resulting
array and within an integer multiple of *step* from *start*.
* *step*: The difference between two consecutive elements of
the array. 
The default value for *step* is `1` for numeric and `1h` for `timespan` or `datetime`

**Examples**

The following example returns `[1, 4, 7]`:

<!-- csl -->
```
T | extend r = range(1, 8, 3)
```

The following example returns an array holding all days
in the year 2015:

<!-- csl -->
```
T | extend r = range(datetime(2015-01-01), datetime(2015-12-31), 1d)
```

The following example returns `[1,2,3]`:

```
range(1, 3)
```

The following example returns `["01:00:00","02:00:00","03:00:00","04:00:00","05:00:00"]`:
```
range(1h, 5h)
```
