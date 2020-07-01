# arg_min() (aggregation function)

Finds a row in the group that minimizes *ExprToMinimize*, and returns the value of *ExprToReturn* (or `*` to return the entire row).

* Can be used only in context of aggregation inside [summarize](summarizeoperator.md)

**Syntax**

`summarize` [`(`*NameExprToMinimize* `,` *NameExprToReturn* [`,` ...] `)=`] `arg_min` `(`*ExprToMinimize*, `*` | *ExprToReturn*  [`,` ...]`)`

**Arguments**

* *ExprToMinimize*: Expression that will be used for aggregation calculation. 
* *ExprToReturn*: Expression that will be used for returning the value when *ExprToMinimize* is
  minimum. Expression to return may be a wildcard (*) to return all columns of the input table.
* *NameExprToMinimize*: An optional name for the result column representing *ExprToMinimize*.
* *NameExprToReturn*: Additional optional names for the result columns representing *ExprToReturn*.

**Returns**

Finds a row in the group that minimizes *ExprToMinimize*, and returns the value of *ExprToReturn* (or `*` to return the entire row).

**Examples**

Show cheapest supplier of each product:

<!--- csl --->
```
Supplies | summarize arg_min(Price, Supplier) by Product
```

Show all the details, not just the supplier name:

<!--- csl --->
```
Supplies | summarize arg_min(Price, *) by Product
```

Find the southernmost city in each continent, with its country:

<!--- csl --->
```
PageViewLog 
| summarize (latitude, min_lat_City, min_lat_country)=arg_min(latitude, City, country) 
    by continent
```

![alt text](./images/aggregations/arg-min.png "arg-min")
