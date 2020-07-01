# top operator

Returns the first *N* records sorted by the specified columns.

<!-- csl -->
```
T | top 5 by Name desc nulls last
```

**Syntax**

*T* `| top` *NumberOfRows* `by` *Expression* [`asc` | `desc`] [`nulls first` | `nulls last`]

**Arguments**

* *NumberOfRows*: The number of rows of *T* to return. You can specify any numeric expression.
* *Expression*: A scalar expression by which to sort. The type of the values must be numeric, date, time or string.
* `asc` or `desc` (the default) may appear to control whether selection is actually from the "bottom" or "top" of the range.
* `nulls first` (the default for `asc` order) or `nulls last` (the default for `desc` order) may appear to control whether null values will be at the beginning or the end of the range.


**Tips**

* `top 5 by name` is equivalent to the expression `sort by name | take 5` both from semantic and performance perspectives..
* Use [top-nested](topnestedoperator.md) operator to produce hierarchical (nested) top results.
