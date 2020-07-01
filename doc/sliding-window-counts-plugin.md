# sliding_window_counts plugin

Calculates counts and distinct count of values in a sliding window over a lookback period, 
using the technique described [here](samples.md#performing-aggregations-over-a-sliding-window).

For instance, for each *day*, calculate count and distinct count of users in previous *week*. 

<!-- csl -->
```
T | evaluate sliding_window_counts(id, datetime_column, startofday(ago(30d)), startofday(now()), 7d, 1d, dim1, dim2, dim3)
```

**Syntax**

*T* `| evaluate` `sliding_window_counts(`*IdColumn*`,` *TimelineColumn*`,` *Start*`,` *End*`,` *LookbackWindow*`,` *Bin* `,` [*dim1*`,` *dim2*`,` ...]`)`

**Arguments**

* *T*: The input tabular expression.
* *IdColumn*: The name of the column with ID values that represent user activity. 
* *TimelineColumn*: The name of the column that represent timeline.
* *Start*: Scalar with value of the analysis start period.
* *End*: Scalar with value of the analysis end period.
* *LookbackWindow*: Scalar constant value of the lookback period (e.g. for dcount users in past 7d: LookbackWindow = 7d)
* *Bin*: Scalar constanct  value of the analysis step period. Can be either a numeric/datetime/timestamp value, or a string which is one of `week`/`month`/`year`, in which case all periods will be [startofweek](startofweekfunction.md)/[startofmonth](startofmonthfunction.md)/[startofyear](startofyearfunction.md) accordingly. 
* *dim1*, *dim2*, ...: (optional) list of the dimensions columns that slice the activity metrics calculation.

**Returns**

Returns a table that has the count and distinct count values of Ids in the lookback period, for each timeline period (by bin) and for each existing dimensions combination.

Output table schema is:

|*TimelineColumn*|dim1|..|dim_n|Count|Dcount|
|---|---|---|---|---|---|
|type: as of *TimelineColumn*|..|..|..|long|long|


**Examples**

Calculate counts and dcounts for users in past week, for every day in the analysis period. 

<!-- csl -->
```
let start = datetime(2017 - 08 - 01);
let end = datetime(2017 - 08 - 07); 
let lookbackWindow = 3d;  
let bin = 1d;
let T = datatable(UserId:string, Timestamp:datetime)
[
'Bob',      datetime(2017 - 08 - 01), 
'David',    datetime(2017 - 08 - 01), 
'David',    datetime(2017 - 08 - 01), 
'John',     datetime(2017 - 08 - 01), 
'Bob',      datetime(2017 - 08 - 01), 
'Ananda',   datetime(2017 - 08 - 02),  
'Atul',     datetime(2017 - 08 - 02), 
'John',     datetime(2017 - 08 - 02), 
'Ananda',   datetime(2017 - 08 - 03), 
'Atul',     datetime(2017 - 08 - 03), 
'Atul',     datetime(2017 - 08 - 03), 
'John',     datetime(2017 - 08 - 03), 
'Bob',      datetime(2017 - 08 - 03), 
'Betsy',    datetime(2017 - 08 - 04), 
'Bob',      datetime(2017 - 08 - 05), 
];
T | evaluate sliding_window_counts(UserId, Timestamp, start, end, lookbackWindow, bin)


```

|Timestamp|Count|Dcount|
|---|---|---|
|2017-08-01 00:00:00.0000000|5|3|
|2017-08-02 00:00:00.0000000|8|5|
|2017-08-03 00:00:00.0000000|13|5|
|2017-08-04 00:00:00.0000000|9|5|
|2017-08-05 00:00:00.0000000|7|5|
|2017-08-06 00:00:00.0000000|2|2|
|2017-08-07 00:00:00.0000000|1|1|
