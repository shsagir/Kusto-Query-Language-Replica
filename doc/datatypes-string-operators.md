# String operators

The following table summarizes operators on strings:

Operator        |Description                                                       |Case-Sensitive|Example (yields `true`)
----------------|------------------------------------------------------------------|--------------|-----------------------
`==`            |Equals                                                            |Yes           |`"aBc" == "aBc"`
`!=`            |Not equals                                                        |Yes           |`"abc" != "ABC"`
`=~`            |Equals                                                            |No            |`"abc" =~ "ABC"`
`!~`            |Not equals                                                        |No            |`"aBc" !~ "xyz"`
`has`           |Right-hand-side (RHS) is a whole term in left-hand-side (LHS)     |No            |`"North America" has "america"`
`!has`          |RHS is not a full term in LHS                                     |No            |`"North America" !has "amer"` 
`has_cs`        |Right-hand-side (RHS) is a whole term in left-hand-side (LHS)     |Yes           |`"North America" has_cs "America"`
`!has_cs`       |RHS is not a full term in LHS                                     |Yes           |`"North America" !has_cs "amer"` 
`hasprefix`     |RHS is a term prefix in LHS                                       |No            |`"North America" hasprefix "ame"`
`!hasprefix`    |RHS is not a term prefix in LHS                                   |No            |`"North America" !hasprefix "mer"` 
`hasprefix_cs`  |RHS is a term prefix in LHS                                       |Yes           |`"North America" hasprefix_cs "Ame"`
`!hasprefix_cs` |RHS is not a term prefix in LHS                                   |Yes           |`"North America" !hasprefix_cs "CA"` 
`hassuffix`     |RHS is a term suffix in LHS                                       |No            |`"North America" hassuffix "ica"`
`!hassuffix`    |RHS is not a term suffix in LHS                                   |No            |`"North America" !hassuffix "americ"`
`hassuffix_cs`  |RHS is a term suffix in LHS                                       |Yes           |`"North America" hassuffix_cs "ica"`
`!hassuffix_cs` |RHS is not a term suffix in LHS                                   |Yes           |`"North America" !hassuffix_cs "icA"`
`contains`      |RHS occurs as a subsequence of LHS                                |No            |`"FabriKam" contains "BRik"`
`!contains`     |RHS does not occur in LHS                                         |No            |`"Fabrikam" !contains "xyz"`
`contains_cs`   |RHS occurs as a subsequence of LHS                                |Yes           |`"FabriKam" contains_cs "Kam"`
`!contains_cs`  |RHS does not occur in LHS                                         |Yes           |`"Fabrikam" !contains_cs "Kam"`
`startswith`    |RHS is an initial subsequence of LHS                              |No            |`"Fabrikam" startswith "fab"`
`!startswith`   |RHS is not an initial subsequence of LHS                          |No            |`"Fabrikam" !startswith "kam"`
`startswith_cs` |RHS is an initial subsequence of LHS                              |Yes           |`"Fabrikam" startswith_cs "Fab"`
`!startswith_cs`|RHS is not an initial subsequence of LHS                          |Yes           |`"Fabrikam" !startswith_cs "fab"`
`endswith`      |RHS is a closing subsequence of LHS                               |No            |`"Fabrikam" endswith "Kam"`
`!endswith`     |RHS is not a closing subsequence of LHS                           |No            |`"Fabrikam" !endswith "brik"`
`endswith_cs`   |RHS is a closing subsequence of LHS                               |Yes           |`"Fabrikam" endswith "Kam"`
`!endswith_cs`  |RHS is not a closing subsequence of LHS                           |Yes           |`"Fabrikam" !endswith "brik"`
`matches regex` |LHS contains a match for RHS                                      |Yes           |`"Fabrikam" matches regex "b.*k"`
`in`            |Equals to one of the elements                                     |Yes           |`"abc" in ("123", "345", "abc")`
`!in`           |Not equals to any of the elements                                 |Yes           |`"bca" !in ("123", "345", "abc")`
`in~`           |Equals to one of the elements                                     |No            |`"abc" in~ ("123", "345", "ABC")`
`!in~`          |Not equals to any of the elements                                 |No            |`"bca" !in~ ("123", "345", "ABC")`
`has_any`       |Same as `has` but works on any of the elements                    |No            |`"North America" has_any("south", "north")`

## Performance tips

For better performance, when there are two operators that perform the same task, use the case-sensitive one.
For example:

* instead of `=~`, use `==`
* instead of `in~`, use `in`
* instead of `contains`, use `contains_cs`

For faster results, if you are testing for the presence of a symbol or alphanumeric word that is bound by non-alphanumeric characters (or the start or end of a field), use `has` or `in`. `has` performs faster than `contains`, `startswith`, or `endswith`.

For example, the first of these queries runs faster:

<!-- csl -->
```
EventLog | where continent has "North" | count;
EventLog | where continent contains "nor" | count
```

## Understanding string terms

By default, Kusto indexes all columns, including columns of type `string`.
In fact, multiple indexes are built for such columns, depending on the actual
data. To the user, these indexes are not directly exposed (other than their
positive effect on query performance of course) with the exception of the
`string` operators that have `has` as part of their name: `has`, `!has`,
`hasprefix`, `!hasprefix`, etc. Those operators are special in that their semantic
is dictated by the way the column is encoded; instead of doing a "plain"
substring match, these operators match **terms**.

To understand term-based match, one first needs to understand what is a
term. By default, Kusto breaks each `string` value into maximal sequences of
ASCII alphanumeric characters, and each of those is made into a term. For example,
in the following `string`, the terms are `Kusto`, `WilliamGates3rd`, and
the following substrings: `ad67d136`, `c1db`, `4f9f`, `88ef`, `d94f3b6b0b5a`:

```
Kusto:  ad67d136-c1db-4f9f-88ef-d94f3b6b0b5a;;WilliamGates3rd
```

By default, Kusto builds a term index consisting of all terms that are
four characters or more, and this index is used by `has`, `!has`, etc.
when looking up terms that are also four characters or more. (If the query
looks for a term that is smaller than four characters, or uses a `contains`
operator for example, Kusto will revert to scanning the values in the column
if it cannot determine a match, which is far slower than looking the term
up in the term index.)

