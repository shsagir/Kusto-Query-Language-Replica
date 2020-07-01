# find operator

Finds rows that match a predicate across a set of tables.

::: zone pivot="azuredataexplorer"

The scope of the `find` can also be cross-database or cross-cluster.

<!-- csl -->
```
find in (Table1, Table2, Table3) where Fruit=="apple"

find in (database('*').*) where Fruit == "apple"

find in (cluster('cluster_name').database('MyDB*'.*)) where Fruit == "apple"
```

::: zone-end

::: zone pivot="azuremonitor"

<!-- csl -->
```
find in (Table1, Table2, Table3) where Fruit=="apple"
```

::: zone-end

## Syntax

* `find` [`withsource`=*ColumnName*] [`in` `(`*Table* [`,` *Table*, ...]`)`] `where` *Predicate* [`project-smart` | `project` *ColumnName* [`:`*ColumnType*] [`,` *ColumnName*[`:`*ColumnType*], ...][`,` `pack(*)`]] 

* `find` *Predicate* [`project-smart` | `project` *ColumnName*[`:`*ColumnType*] [`,` *ColumnName*[`:`*ColumnType*], ...] [`, pack(*)`]] 

## Arguments

::: zone pivot="azuredataexplorer"

* `withsource=`*ColumnName*: Optional. By default the output will include a column called *source_* whose values indicates which source table has contributed each row. If specified, *ColumnName* will be used instead of *source_* .
If the query effectively (after wildcard matching) references tables from more than one database (default database always counts) the value of this column will have a table name qualified with the database. Similarly __cluster and database__ qualifications will be present in the value if more than one cluster is referenced.
* *Predicate*: [see details](./findoperator.md#predicate-syntax). A `boolean` [expression](./scalar-data-types/bool.md) over the columns of the input tables *Table* [`,` *Table*, ...]. It is evaluated for each row in each input table. 
* `Table`: Optional. By default *find* will search in all tables in the current database
    *  The name of a table, such as `Events` or
    *  A query expression, such as `(Events | where id==42)`
    *  A set of tables specified with a wildcard. For example, `E*` would form the union of all the tables in the database whose names begin `E`.
* `project-smart` | `project`: [see details](./findoperator.md#output-schema) if not specified `project-smart` will be used by default

::: zone-end

::: zone pivot="azuremonitor"

* `withsource=`*ColumnName*: Optional. By default the output will include a column called *source_* whose values indicates which source table has contributed each row. If specified, *ColumnName* will be used instead of *source_* .
* *Predicate*: [see details](./findoperator.md#predicate-syntax). A `boolean` [expression](./scalar-data-types/bool.md) over the columns of the input tables *Table* [`,` *Table*, ...]. It is evaluated for each row in each input table. 
* `Table`: Optional. By default *find* will search in all tables
    *  The name of a table, such as `Events` or
    *  A query expression, such as `(Events | where id==42)`
    *  A set of tables specified with a wildcard. For example, `E*` would form the union of all the tables whose names begin `E`.
* `project-smart` | `project`: [see details](./findoperator.md#output-schema) if not specified `project-smart` will be used by default

::: zone-end

## Returns

Transformation of rows in *Table* [`,` *Table*, ...] for which *Predicate* is `true`. The rows are transformed
according to the output schema as described below.

## Output Schema

**source_ column**

The find operator output will always include a *source_* column with the source table name. The column can be renamed using the `withsource` parameter.

**results columns**

Source tables that do not contain any column used by the predicate evaluation will be be filtered out.

When using `project-smart`, the columns that will appear in the output will be:
1. Columns that appear explicitly in the predicate
2. Columns that are common to all the filtered tables
The rest of the columns will be packed into a property bag and will appear in an additional `pack_` column.
A column that is referenced explicitly by the predicate and appears in multiple tables with multiple types, will have a different column in the result schema for each such type. Each of the column names will be constructed from the original column name and the type, separated by an underscore.

When using `project` *ColumnName*[`:`*ColumnType*] [`,` *ColumnName*[`:`*ColumnType*], ...][`,` `pack(*)`]:
1. The result table will include the columns specified in the list. If a source table doesn't contain a certain column, the values in the corresponding rows will be null.
2. When specifying a *ColumnType* along with a *ColumnName*, this column in the **result** will have the given type, and the values will be casted to that type if needed. Note that this will not have an effect on the column type when evaluating the *Predicate*.
3. When `pack(*)` is used, the rest of the columns will be packed into a property bag and will appear in an additional `pack_` column

**pack_ column**

This column will contain a property bag with the data from all the columns that doesn't appear in the output schema. The source column name will serve as the property name and the column value will serve as the property value.

## Predicate Syntax

Please refer to the [where operator](./whereoperator.md) for some filtering functions summary.

find operator supports an alternative syntax for `* has` *term* , and using just *term* will search a term across all input columns

## Notes

* If the `project` clause references a column that appears in multiple tables and has multiple types, a type must follow this column reference in the project clause
* If a column appears in multiple tables and has multiple types and `project-smart` is in use, there will be a corresponding column for each type in the `find`'s result, as described in [union](./unionoperator.md)
* When using *project-smart*, changes in the predicate, in the source tables set or in the tables schema may result in a changes to the output schema. If a constant result schema is needed, use *project* instead
* `find` scope can not include [functions](../management/functions.md). To include a function in the find scope - define a [let statement](./letstatement.md) with [view keyword](./letstatement.md)

## Performance Tips

* Use [tables](../management/tables.md) as opposed to [tabular expressions](./tabularexpressionstatements.md)- in case of tabular expression the find operator falls back to a `union` query which can result in degraded performance
* If a column that appears in multiple tables and has multiple types is part of the project clause, prefer adding a *ColumnType* to the project clause over modifying the table before passing it to `find` (see previous tip)
* Add time based filters to the predicate (using a datetime column value or [ingestion_time()](./ingestiontimefunction.md))
* Prefer to search in specific columns over full text search 
* Prefer not to reference explicitly columns that appears in multiple tables and has multiple types. If the predicate is valid when resolving such columns type for more than one type, the query will fallback to union

[see examples](./findoperator.md#examples-of-cases-where-find-will-perform-as-union)

## Examples

::: zone pivot="azuredataexplorer"

###  Term lookup across all tables (in current database)

The next query finds all rows from all tables in the current database in which any column includes the word `Kusto`. 
The resulting records are transformed according to the [output schema](#output-schema). 

<!-- csl -->
```
find "Kusto"
```

## Term lookup across all tables matching a name pattern (in the current database)

The next query finds all rows from all tables in the current database whose name starts with `K`, and in which any column includes the word `Kusto`.
The resulting records are transformed according to the [output schema](#output-schema). 

<!-- csl -->
```
find in (K*) where * has "Kusto"
```

###  Term lookup across all tables in all databases (in the cluster)

The next query finds all rows from all tables in all databases in which any column includes the word `Kusto`. 
This is a [cross database query](./cross-cluster-or-database-queries.md) query. 
The resulting records are transformed according to the [output schema](#output-schema). 

<!-- csl -->
```
find in (database('*').*) "Kusto"
```

### Term lookup across all tables and databases matching a name pattern (in the cluster)

The next query finds all rows from all tables whose name starts with `K` in all databases whose name start with `B` and 
in which any column includes the word `Kusto`. 
The resulting records are transformed according to the [output schema](#output-schema). 

<!-- csl -->
```
find in (database("B*").K*) where * has "Kusto"
```

### Term lookup in several clusters

The next query finds all rows from all tables whose name starts with `K` in all databases whose name start with `B` and 
in which any column includes the word `Kusto`. 
The resulting records are transformed according to the [output schema](#output-schema). 

<!-- csl -->
```
find in (cluster("cluster1").database("B*").K*, cluster("cluster2").database("C*".*))
where * has "Kusto"
```

::: zone-end

::: zone pivot="azuremonitor"

###  Term lookup across all tables

The next query finds all rows from all tables in which any column includes the word `Kusto`. 
The resulting records are transformed according to the [output schema](#output-schema). 

<!-- csl -->
```
find "Kusto"
```

::: zone-end

## Examples of `find` output results  

The following examples show how `find` can be used over two tables: EventsTable1 and EventsTable2. 
Assume we have next content of these two tables: 

### EventsTable1

|Session_Id|Level|EventText|Version
|---|---|---|---|
|acbd207d-51aa-4df7-bfa7-be70eb68f04e|Information|Some Text1|v1.0.0
|acbd207d-51aa-4df7-bfa7-be70eb68f04e|Error|Some Text2|v1.0.0
|28b8e46e-3c31-43cf-83cb-48921c3986fc|Error|Some Text3|v1.0.1
|8f057b11-3281-45c3-a856-05ebb18a3c59|Information|Some Text4|v1.1.0

### EventsTable2

|Session_Id|Level|EventText|EventName
|---|---|---|---|
|f7d5f95f-f580-4ea6-830b-5776c8d64fdd|Information|Some Other Text1|Event1
|acbd207d-51aa-4df7-bfa7-be70eb68f04e|Information|Some Other Text2|Event2
|acbd207d-51aa-4df7-bfa7-be70eb68f04e|Error|Some Other Text3|Event3
|15eaeab5-8576-4b58-8fc6-478f75d8fee4|Error|Some Other Text4|Event4


### Search in common columns, project common and uncommon columns and pack the rest  

<!-- csl -->
```
find in (EventsTable1, EventsTable2) 
     where Session_Id == 'acbd207d-51aa-4df7-bfa7-be70eb68f04e' and Level == 'Error' 
     project EventText, Version, EventName, pack(*)
```

|source_|EventText|Version|EventName|pack_
|---|---|---|---|---|
|EventsTable1|Some Text2|v1.0.0||{"Session_Id":"acbd207d-51aa-4df7-bfa7-be70eb68f04e", "Level":"Error"}
|EventsTable2|Some Other Text3||Event3|{"Session_Id":"acbd207d-51aa-4df7-bfa7-be70eb68f04e", "Level":"Error"}


### Search in common and uncommon columns

<!-- csl -->
```
find Version == 'v1.0.0' or EventName == 'Event1' project Session_Id, EventText, Version, EventName
```

|source_|Session_Id|EventText|Version|EventName|
|---|---|---|---|---|
|EventsTable1|acbd207d-51aa-4df7-bfa7-be70eb68f04e|Some Text1|v1.0.0
|EventsTable1|acbd207d-51aa-4df7-bfa7-be70eb68f04e|Some Text2|v1.0.0
|EventsTable2|f7d5f95f-f580-4ea6-830b-5776c8d64fdd|Some Other Text1||Event1

Note: in practice, *EventsTable1* rows will be filtered with ```Version == 'v1.0.0'``` predicate and *EventsTable2* rows will be filtered with ```EventName == 'Event1'``` predicate.

### Use abbreviated notation to search across all tables in the current database

<!-- csl -->
```
find Session_Id == 'acbd207d-51aa-4df7-bfa7-be70eb68f04e'
```

|source_|Session_Id|Level|EventText|pack_|
|---|---|---|---|---|
|EventsTable1|acbd207d-51aa-4df7-bfa7-be70eb68f04e|Information|Some Text1|{"Version":"v1.0.0"}
|EventsTable1|acbd207d-51aa-4df7-bfa7-be70eb68f04e|Error|Some Text2|{"Version":"v1.0.0"}
|EventsTable2|acbd207d-51aa-4df7-bfa7-be70eb68f04e|Information|Some Other Text2|{"EventName":"Event2"}
|EventsTable2|acbd207d-51aa-4df7-bfa7-be70eb68f04e|Error|Some Other Text3|{"EventName":"Event3"}


### Return the results from each row as a property bag

<!-- csl -->
```
find Session_Id == 'acbd207d-51aa-4df7-bfa7-be70eb68f04e' project pack(*)
```

|source_|pack_|
|---|---|
|EventsTable1|{"Session_Id":"acbd207d-51aa-4df7-bfa7-be70eb68f04e", "Level":"Information", "EventText":"Some Text1", "Version":"v1.0.0"}
|EventsTable1|{"Session_Id":"acbd207d-51aa-4df7-bfa7-be70eb68f04e", "Level":"Error", "EventText":"Some Text2", "Version":"v1.0.0"}
|EventsTable2|{"Session_Id":"acbd207d-51aa-4df7-bfa7-be70eb68f04e", "Level":"Information", "EventText":"Some Other Text2", "EventName":"Event2"}
|EventsTable2|{"Session_Id":"acbd207d-51aa-4df7-bfa7-be70eb68f04e", "Level":"Error", "EventText":"Some Other Text3", "EventName":"Event3"}


## Examples of cases where `find` will perform as `union`

### Using a non tabular expression as find operand

<!-- csl -->
```
let PartialEventsTable1 = view() { EventsTable1 | where Level == 'Error' };
find in (PartialEventsTable1, EventsTable2) 
     where Session_Id == 'acbd207d-51aa-4df7-bfa7-be70eb68f04e'
```

### Referencing a column that appears in multiple tables and has multiple types

Assume we have created two tables by running: 

<!-- csl -->
```
.create tables 
  Table1 (Level:string, Timestamp:datetime, ProcessId:string),
  Table2 (Level:string, Timestamp:datetime, ProcessId:int64)
```

* The following query will be executed as `union`:
<!-- csl -->
```
find in (Table1, Table2) where ProcessId == 1001
```

And the output result schema will be __(Level:string, Timestamp, ProcessId_string, ProcessId_int)__

* The following query will, as well, be executed as `union` but will produce a different result schema:
<!-- csl -->
```
find in (Table1, Table2) where ProcessId == 1001 project Level, Timestamp, ProcessId:string 
```

And the output result schema will be __(Level:string, Timestamp, ProcessId_string)__
