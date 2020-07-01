# hll_merge() (aggregation function)

Merges HLL results across the group into single HLL value.

* Can be used only in context of aggregation inside [summarize](summarizeoperator.md).

Read about the [underlying algorithm (*H*yper*L*og*L*og) and estimation accuracy](dcount-aggfunction.md#estimation-accuracy).

**Syntax**

`summarize` `hll_merge(`*Expr*`)`

**Arguments**

* *Expr*: Expression that will be used for aggregation calculation. 

**Returns**

The merged hll values of *Expr* across the group.
 
**Tips**

1) You may use the function [dcount_hll] (dcount-hllfunction.md) which will calculate the dcount from hll / hll-merge aggregation functions.
