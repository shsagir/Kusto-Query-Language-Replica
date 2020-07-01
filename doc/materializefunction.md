---
title: materialize() - Azure Data Explorer
description: This article describes materialize() function in Azure Data Explorer.
services: data-explorer
author: orspod
ms.author: orspodek
ms.reviewer: alexans
ms.service: data-explorer
ms.topic: reference
ms.date: 06/06/2020
---
# materialize()

Allows caching a subquery result during the time of query execution in a way that other subqueries can reference the partial result.
 
**Syntax**

`materialize(`*expression*`)`

**Arguments**

* *expression*: Tabular expression to be evaluated and cached during query execution.

**Tips**

* Use materialize with join or union when their operands have mutual subqueries that can be executed once. See the examples below.

* Useful also in scenarios when we need to join/union fork legs.

* Materialize can only be used in let statements if you give the cached result a name.

**Note**

* Materialize has a cache size limit of **5 GB**. 
  This limit is per cluster node and is mutual for all queries running concurrently.
  If a query uses `materialize()` and the cache can't hold any more data,
  the query will abort with an error.

**Examples**

The following example shows how `materialize()` can be used to improve performance of the query.
The expression `_detailed_data` is defined using `materialize()` function and therefore it's calculated only once.

<!-- csl: https://help.kusto.windows.net/Samples -->
```kusto
let _detailed_data = materialize(StormEvents | summarize Events=count() by State, EventType);
_detailed_data
| summarize TotalStateEvents=sum(Events) by State
| join (_detailed_data) on State
| extend EventPercentage = Events*100.0 / TotalStateEvents
| project State, EventType, EventPercentage, Events
| top 10 by EventPercentage
```

|State|EventType|EventPercentage|Events|
|---|---|---|---|
|HAWAII WATERS|Waterspout|100|2|
|LAKE ONTARIO|Marine Thunderstorm Wind|100|8|
|GULF OF ALASKA|Waterspout|100|4|
|ATLANTIC NORTH|Marine Thunderstorm Wind|95.2127659574468|179|
|LAKE ERIE|Marine Thunderstorm Wind|92.5925925925926|25|
|E PACIFIC|Waterspout|90|9|
|LAKE MICHIGAN|Marine Thunderstorm Wind|85.1648351648352|155|
|LAKE HURON|Marine Thunderstorm Wind|79.3650793650794|50|
|GULF OF MEXICO|Marine Thunderstorm Wind|71.7504332755633|414|
|HAWAII|High Surf|70.0218818380744|320|


The following example generates a set of random numbers and calculates: 
* how many distinct values in the set (Dcount)
* the top three values in the set 
* the sum of all these values in the set 
 
This operation can be done using [batches](batches.md) and materialize:

<!-- csl: https://help.kusto.windows.net/Samples -->
```kusto
let randomSet = 
    materialize(
        range x from 1 to 3000000 step 1
        | project value = rand(10000000));
randomSet | summarize Dcount=dcount(value);
randomSet | top 3 by value;
randomSet | summarize Sum=sum(value)
```

Result set 1:  

|Dcount|
|---|
|2578351|

Result set 2: 

|value|
|---|
|9999998|
|9999998|
|9999997|

Result set 3: 

|Sum|
|---|
|15002960543563|
