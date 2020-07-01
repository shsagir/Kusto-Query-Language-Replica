# unixtime_seconds_todatetime()

Converts unix-epoch seconds to UTC datetime.

**Syntax**

`unixtime_seconds_todatetime(*seconds*)`

**Arguments**

* *seconds*: A real number represents epoch timestamp in seconds. `Datetime` that occurs before the epoch time (1970-01-01 00:00:00) has a negative timestamp value.

**Returns**

If the conversion is successful, the result will be a [datetime](./scalar-data-types/datetime.md) value. If conversion is not successful, result will be null.

**See also**

* Convert unix-epoch milliseconds to UTC datetime using [unixtime_milliseconds_todatetime()](unixtime-milliseconds-todatetimefunction.md).
* Convert unix-epoch microseconds to UTC datetime using [unixtime_microseconds_todatetime()](unixtime-microseconds-todatetimefunction.md).
* Convert unix-epoch nanoseconds to UTC datetime using [unixtime_nanoseconds_todatetime()](unixtime-nanoseconds-todatetimefunction.md).

**Example**

<!-- csl: https://help.kusto.windows.net/Samples  -->
```
print date_time = unixtime_seconds_todatetime(1546300800)
```

|date_time|
|---|
|2019-01-01 00:00:00.0000000|
