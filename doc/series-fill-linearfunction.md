# series_fill_linear()

Performs linear interpolation of missing values in a series.

Takes an expression containing dynamic numerical array as input, performs linear interpolation for all instances of missing_value_placeholder and returns the resulting array. If the beginning and end of the array contains missing_value_placeholder, then it will be replaced with the nearest value other than missing_value_placeholder (can be turned off). If the whole array consists of the missing_value_placeholder then the array will be filled with constant_value or 0 if no specified.  

**Syntax**

`series_fill_linear(`*x*`[,` *missing_value_placeholder*` [,`*fill_edges*` [,`*constant_value*`]]]))`
* Will return series linear interpolation of *x* using specified parameters.
 

**Arguments**

* *x*: dynamic array scalar expression which is an array of numeric values.
* *missing_value_placeholder*: optional parameter which specifies a placeholder for the "missing values" to be replaced. Default value is `double`(*null*).
* *fill_edges*: Boolean value which indicates whether *missing_value_placeholder* at the start and end of the array should be replaced with nearest value. *True* by default. If set to *false* then *missing_value_placeholder* at the start and end of the array will be preserved.
* *constant_value*: optional parameter relevant only for arrays entirely consists of *null* values, which specifies constant value to fill the series with. Default value is *0*. Setting this parameter it to `double`(*null*) will effectively leave *null* values where they are.

**Notes**

* In order to apply any interpolation functions after [make-series](make-seriesoperator.md) it is recommended to specify *null* as a default value: 

<!-- csl: https://help.kusto.windows.net:443/Samples -->
```
make-series num=count() default=long(null) on TimeStamp in range(ago(1d), ago(1h), 1h) by Os, Browser
```

* The *missing_value_placeholder* can be of any type which will be converted to actual element types. Therefore either `double`(*null*), `long`(*null*) or `int`(*null*) have the same meaning.
* If *missing_value_placeholder* is `double`(*null*) (or just omitted which have the same meaning) then a result may contains *null* values. Use other interpolation functions in order to fill them. Currently only [series_outliers()](series-outliersfunction.md) support *null* values in input arrays.
* The function preserves original type of array elements. If *x* contains only *int* or *long* elements then the linear interpolation will return rounded interpolated values rather than exact ones.

**Example**

<!-- csl: https://help.kusto.windows.net:443/Samples -->
```
let data = datatable(arr: dynamic)
[
    dynamic([null, 111.0, null, 36.0, 41.0, null, null, 16.0, 61.0, 33.0, null, null]), // Array of double    
    dynamic([null, 111,   null, 36,   41,   null, null, 16,   61,   33,   null, null]), // Similar array of int
    dynamic([null, null, null, null])                                                   // Array with missing values only
];
data
| project arr, 
          without_args = series_fill_linear(arr),
          with_edges = series_fill_linear(arr, double(null), true),
          wo_edges = series_fill_linear(arr, double(null), false),
          with_const = series_fill_linear(arr, double(null), true, 3.14159)  

```

|arr|without_args|with_edges|wo_edges|with_const|
|---|---|---|---|---|
|[null,111.0,null,36.0,41.0,null,null,16.0,61.0,33.0,null,null]|[111.0,111.0,73.5,36.0,41.0,32.667,24.333,16.0,61.0,33.0,33.0,33.0]|[111.0,111.0,73.5,36.0,41.0,32.667,24.333,16.0,61.0,33.0,33.0,33.0]|[null,111.0,73.5,36.0,41.0,32.667,24.333,16.0,61.0,33.0,null,null]|[111.0,111.0,73.5,36.0,41.0,32.667,24.333,16.0,61.0,33.0,33.0,33.0]|
|[null,111,null,36,41,null,null,16,61,33,null,null]|[111,111,73,36,41,32,24,16,61,33,33,33]|[111,111,73,36,41,32,24,16,61,33,33,33]|[null,111,73,36,41,32,24,16,61,33,null,null]|[111,111,74,38,  41,32,24,16,61,33,33,33]|
|[null,null,null,null]|[0.0,0.0,0.0,0.0]|[0.0,0.0,0.0,0.0]|[0.0,0.0,0.0,0.0]|[3.14159,3.14159,3.14159,3.14159]|
