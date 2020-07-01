# variancep() (aggregation function)

Calculates the variance of *Expr* across the group, considering the group as a [population](https://en.wikipedia.org/wiki/Statistical_population). 

* Used formula:
![alt text](./images/aggregations/variance-population.png "variance-population")

* Can be used only in context of aggregation inside [summarize](summarizeoperator.md)

**Syntax**

summarize `variancep(`*Expr*`)`

**Arguments**

* *Expr*: Expression that will be used for aggregation calculation. 

**Returns**

The variance value of *Expr* across the group.
 
**Examples**

<!-- csl -->
```
range x from 1 to 5 step 1
| summarize make_list(x), variancep(x) 
```

|list_x|variance_x|
|---|---|
|[ 1, 2, 3, 4, 5]|2|
