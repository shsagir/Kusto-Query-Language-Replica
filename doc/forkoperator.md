# fork operator

Runs multiple consumer operators in parallel.

**Syntax**

*T* `|` `fork` [*name*`=`]`(`*subquery*`)` [*name*`=`]`(`*subquery*`)` ...

**Arguments**

* *subquery* is a downstream pipeline of query operators
* *name* is a temporary name for the subquery result table

**Returns**

Multiple result tables, one for each of the subqueries.

**Supported Operators**

[`as`](asoperator.md), [`count`](countoperator.md), [`extend`](extendoperator.md), [`parse`](parseoperator.md), [`where`](whereoperator.md), [`take`](takeoperator.md), [`project`](projectoperator.md), [`project-away`](projectawayoperator.md), [`summarize`](summarizeoperator.md), [`top`](topoperator.md), [`top-nested`](topnestedoperator.md), [`sort`](sortoperator.md), [`mv-expand`](mvexpandoperator.md), [`reduce`](reduceoperator.md)

**Notes**

* [`materialize`](materializefunction.md) function can be used as a replacement for using [`join`](joinoperator.md) or [`union`](unionoperator.md) on fork legs.
The input stream will be cached by materialize and then the cached expression can be used in join/union legs.

* A name, given by the `name` argument or by using [`as`](asoperator.md) operator will be used as the to name the result tab in [`Kusto.Explorer`](../tools/kusto-explorer.md) tool.

* Avoid using `fork` with a single subquery.

* Prefer using [batch](batches.md) with [`materialize`](materializefunction.md) of tabular expression statements over `fork` operator.

**Examples**

<!-- csl -->
```
KustoLogs
| where Timestamp > ago(1h)
| fork
    ( where Level == "Error" | project EventText | limit 100 )
    ( project Timestamp, EventText | top 1000 by Timestamp desc)
    ( summarize min(Timestamp), max(Timestamp) by ActivityID )
 
// In the following examples the result tables will be named: Errors, EventsTexts and TimeRangePerActivityID
KustoLogs
| where Timestamp > ago(1h)
| fork
    ( where Level == "Error" | project EventText | limit 100 | as Errors )
    ( project Timestamp, EventText | top 1000 by Timestamp desc | as EventsTexts )
    ( summarize min(Timestamp), max(Timestamp) by ActivityID | as TimeRangePerActivityID )
    
 KustoLogs
| where Timestamp > ago(1h)
| fork
    Errors = ( where Level == "Error" | project EventText | limit 100 )
    EventsTexts = ( project Timestamp, EventText | top 1000 by Timestamp desc )
    TimeRangePerActivityID = ( summarize min(Timestamp), max(Timestamp) by ActivityID )
```
