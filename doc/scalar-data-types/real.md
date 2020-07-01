# The real data type

The `real` data type represents a 64-bit wide, double-precision, floating-point number.

Literals of the `real` data type have the same representation
as .NET's `System.Double`. `1.0`, `0.1`, and `1e5` are all
literals of type `real`.

There are several special literal forms:
* `real(null)`: The is the [null value](null-values.md).
* `real(nan)`: Not-a-Number (NaN). For example, the result of dividing a `0.0` by another `0.0`.
* `real(+inf)`: Positive infinity. For example, the result of dividing `1.0` by `0.0`.
* `real(-inf)`: Negative infinity. For example, the result of dividing `-1.0` by `0.0`.
