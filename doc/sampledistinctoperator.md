# sample-distinct operator

Returns a single column that contains up to the specified number of distinct values of the requested column. 

the default (and currently only) flavor of the operator tries to return an answer as quickly as possible (rather than trying to make a fair sample)

<!-- csl -->
```
T | sample-distinct 5 of DeviceId
```

**Syntax**

*T* `| sample-distinct` *NumberOfValues* `of` *ColumnName*

**Arguments**
* *NumberOfValues*: The number distinct values of *T* to return. You can specify any numeric expression.

**Tips**

 Can be handy to sample a population by putting `sample-distinct` in a let statement and later filter using the `in` operator (see example) 

 If you want the top values rather than just a sample, you can use the [top-hitters](tophittersoperator.md) operator 

 if you want to sample data rows (rather than values of a specific column), refer to the [sample operator](sampleoperator.md)

**Examples**  
Get 10 distinct values from a population
<!-- csl: https://help.kusto.windows.net:443/Samples -->
```
StormEvents | sample-distinct 10 of EpisodeId

```

Sample a population and do further computation knowing the summarize won't exceed query limits. 

<!-- csl: https://help.kusto.windows.net:443/Samples -->
```
let sampleEpisodes = StormEvents | sample-distinct 10 of EpisodeId;
StormEvents 
| where EpisodeId in (sampleEpisodes) 
| summarize totalInjuries=sum(InjuriesDirect) by EpisodeId
```
