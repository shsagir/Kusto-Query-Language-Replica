# where operator (has, contains, startswith, endswith, matches regex)

Filters a table to the subset of rows that satisfy a predicate.

<!-- csl -->
```
T | where fruit=="apple"
```

**Alias** `filter`

**Syntax**

*T* `| where` *Predicate*

**Arguments**

* *T*: The tabular input whose records are to be filtered.
* *Predicate*: A `boolean` [expression](./scalar-data-types/bool.md) over the columns of *T*. It is evaluated for each row in *T*.

**Returns**

Rows in *T* for which *Predicate* is `true`.

**Notes**
Null values: all filtering functions return false when compared with null values. 
You can use special null-aware functions to write queries that take null values into account:
[isnull()](./isnullfunction.md),
[isnotnull()](./isnotnullfunction.md),
[isempty()](./isemptyfunction.md),
[isnotempty()](./isnotemptyfunction.md). 

**Tips**

To get the fastest performance:

* **Use simple comparisons** between column names and constants. ('Constant' means constant over the table - so `now()` and `ago()` are OK, and so are scalar values assigned using a [`let` statement](./letstatement.md).)

    For example, prefer `where Timestamp >= ago(1d)` to `where floor(Timestamp, 1d) == ago(1d)`.

* **Simplest terms first**: If you have multiple clauses conjoined with `and`, put first the clauses that involve just one column. So `Timestamp > ago(1d) and OpId == EventId` is better than the other way around.

For more information, refer to the summary of [available String operators](./datatypes-string-operators.md) and the summary of [available Numerical operators](./numoperators.md).

**Example**

<!-- csl -->
```
Traces
| where Timestamp > ago(1h)
    and Source == "MyCluster"
    and ActivityId == SubActivityId 
```

Records that are no older than 1 hour,
and come from the Source called "MyCluster", and have two columns of the same value. 

Notice that we put the comparison between two columns last, as it can't utilize the index and forces a scan.

**Example**

<!-- csl -->
```
Traces | where * has "Kusto"
```

All the rows in which the word "Kusto" appears in any column.
