# datatable operator

Returns a table whose schema and values are defined in the query itself.

Note that this operator does not have a pipeline input.

**Syntax**

`datatable` `(` *ColumnName* `:` *ColumnType* [`,` ...] `)` `[` *ScalarValue* [`,` *ScalarValue* ...] `]`

**Arguments**

::: zone pivot="azuredataexplorer"

* *ColumnName*, *ColumnType*: These define the schema of the table. The Syntax
  used is precisely the same as the syntax used when defining a table
  (see [.create table](../management/create-table-command.md)).
* *ScalarValue*: A constant scalar value to insert into the table. The number of values
  must be an integer multiple of the columns in the table, and the *n*'th value
  must have a type that corresponds to column *n* % *NumColumns*.

::: zone-end

::: zone pivot="azuremonitor"

* *ColumnName*, *ColumnType*: These define the schema of the table.
* *ScalarValue*: A constant scalar value to insert into the table. The number of values
  must be an integer multiple of the columns in the table, and the *n*'th value
  must have a type that corresponds to column *n* % *NumColumns*.

::: zone-end

**Returns**

This operator returns a data table of the given schema and data.

**Example**

<!-- csl -->
```
datatable (Date:datetime, Event:string)
    [datetime(1910-06-11), "Born",
     datetime(1930-01-01), "Enters Ecole Navale",
     datetime(1953-01-01), "Published first book",
     datetime(1997-06-25), "Died"]
| where strlen(Event) > 4
```
