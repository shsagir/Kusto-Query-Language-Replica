﻿using System.Collections.Generic;

namespace Kusto.Language
{
    using Syntax;
    using Symbols;
    using static FunctionHelpers;

    /// <summary>
    /// Well known aggregates
    /// </summary>
    public static class Aggregates
    {
        public static readonly FunctionSymbol Sum =
            new FunctionSymbol("sum", ReturnTypeKind.Parameter0,
                new Parameter("expr", ParameterTypeKind.Summable))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("sum");

        public static readonly FunctionSymbol SumIf =
            new FunctionSymbol("sumif", ReturnTypeKind.Parameter0,
                new Parameter("expr", ParameterTypeKind.Summable),
                new Parameter("predicate", ScalarTypes.Bool))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("sumif");

        public static readonly FunctionSymbol Cnt =
            new FunctionSymbol("cnt", ScalarTypes.Long)
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("cnt")
            .Hide(); // legacy

        public static readonly FunctionSymbol Count =
            new FunctionSymbol("count", ScalarTypes.Long)
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("count");

        public static readonly FunctionSymbol CountIf =
            new FunctionSymbol("countif", ScalarTypes.Long,
                new Parameter("predicate", ScalarTypes.Bool))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("countif");

        public static readonly FunctionSymbol DCount =
            new FunctionSymbol("dcount", ScalarTypes.Long,
                new Parameter("expr", ParameterTypeKind.Scalar),
                new Parameter("accuracy", ParameterTypeKind.NotDynamic, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("dcount");

        public static readonly FunctionSymbol DCountIf =
            new FunctionSymbol("dcountif", ScalarTypes.Long,
                new Parameter("expr", ParameterTypeKind.Scalar),
                new Parameter("predicate", ScalarTypes.Bool),
                new Parameter("accuracy", ParameterTypeKind.NotDynamic, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("dcountif");

        public static readonly FunctionSymbol TDigest =
            new FunctionSymbol("tdigest", ScalarTypes.Dynamic,
                new Parameter("expr", ParameterTypeKind.Summable),
                new Parameter("weight", ParameterTypeKind.Integer, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("tdigest");

        public static readonly FunctionSymbol TDigestMerge =
            new FunctionSymbol("tdigest_merge", ScalarTypes.Dynamic,
                new Parameter("tdigest", ScalarTypes.Dynamic))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("tdigest_merge");

        public static readonly FunctionSymbol MergeTDigests =
            new FunctionSymbol("merge_tdigests", ScalarTypes.Dynamic,
                new Parameter("tdigest", ScalarTypes.Dynamic))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("merge_tdigests");

        public static readonly FunctionSymbol Hll =
            new FunctionSymbol("hll", ScalarTypes.Dynamic,
                new Parameter("expr", ParameterTypeKind.NotRealOrBool),
                new Parameter("accuracy", ParameterTypeKind.Integer, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("hll");

        public static readonly FunctionSymbol HllMerge =
            new FunctionSymbol("hll_merge", ScalarTypes.Dynamic,
                new Parameter("hll", ScalarTypes.Dynamic))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("hll_merge");

        public static readonly FunctionSymbol Min =
            new FunctionSymbol("min",
                new Signature(ReturnTypeKind.Parameter0,
                    new Parameter("expr", ParameterTypeKind.Summable)),
                new Signature(ReturnTypeKind.Parameter0,
                    new Parameter("expr", ScalarTypes.String)))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("min");

        public static readonly FunctionSymbol MinIf =
            new FunctionSymbol("minif",
                new Signature(ReturnTypeKind.Parameter0,
                    new Parameter("expr", ParameterTypeKind.Summable),
                    new Parameter("predicate", ScalarTypes.Bool)),
                new Signature(ReturnTypeKind.Parameter0,
                    new Parameter("expr", ScalarTypes.String),
                    new Parameter("predicate", ScalarTypes.Bool)))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("minif");

        public static readonly FunctionSymbol Max =
            new FunctionSymbol("max",
                new Signature(ReturnTypeKind.Parameter0,
                    new Parameter("expr", ParameterTypeKind.Summable)),
                new Signature(ReturnTypeKind.Parameter0,
                    new Parameter("expr", ScalarTypes.String)))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("max");

        public static readonly FunctionSymbol MaxIf =
            new FunctionSymbol("maxif",
                new Signature(ReturnTypeKind.Parameter0,
                    new Parameter("expr", ParameterTypeKind.Summable),
                    new Parameter("predicate", ScalarTypes.Bool)),
                new Signature(ReturnTypeKind.Parameter0,
                    new Parameter("expr", ScalarTypes.String),
                    new Parameter("predicate", ScalarTypes.Bool)))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("maxif");

        public static readonly FunctionSymbol Avg =
            new FunctionSymbol("avg",
                new Signature(ScalarTypes.Real,
                    new Parameter("expr", ParameterTypeKind.Integer)),
                new Signature(ScalarTypes.Real,
                    new Parameter("expr", ScalarTypes.Real)),
                new Signature(ScalarTypes.Decimal,
                    new Parameter("expr", ScalarTypes.Decimal)),
                new Signature(ScalarTypes.TimeSpan,
                    new Parameter("expr", ScalarTypes.TimeSpan)),
                new Signature(ScalarTypes.DateTime,
                    new Parameter("expr", ScalarTypes.DateTime)))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("avg");

        public static readonly FunctionSymbol AvgIf =
            new FunctionSymbol("avgif",
                new Signature(ScalarTypes.Real,
                    new Parameter("expr", ParameterTypeKind.Integer),
                    new Parameter("predicate", ScalarTypes.Bool)),
                new Signature(ScalarTypes.Real,
                    new Parameter("expr", ScalarTypes.Real),
                    new Parameter("predicate", ScalarTypes.Bool)),
                new Signature(ScalarTypes.Decimal,
                    new Parameter("expr", ScalarTypes.Decimal),
                    new Parameter("predicate", ScalarTypes.Bool)),
                new Signature(ScalarTypes.TimeSpan,
                    new Parameter("expr", ScalarTypes.TimeSpan),
                    new Parameter("predicate", ScalarTypes.Bool)),
                new Signature(ScalarTypes.DateTime,
                    new Parameter("expr", ScalarTypes.DateTime),
                    new Parameter("predicate", ScalarTypes.Bool)))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("avgif");

        public static readonly FunctionSymbol MakeList_Depricated =
            new FunctionSymbol("makelist", ScalarTypes.Dynamic,
                new Parameter("expr", ParameterTypeKind.Scalar),
                new Parameter("maxSize", ParameterTypeKind.Integer, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("list")
            .Hide();

        public static readonly FunctionSymbol MakeList =
            new FunctionSymbol("make_list", ScalarTypes.Dynamic,
                new Parameter("expr", ParameterTypeKind.Scalar),
                new Parameter("maxSize", ParameterTypeKind.Integer, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("list");

        public static readonly FunctionSymbol MakeListIf =
            new FunctionSymbol("make_list_if", ScalarTypes.Dynamic,
                new Parameter("expr", ParameterTypeKind.Scalar),
                new Parameter("predicate", ScalarTypes.Bool),
                new Parameter("maxSize", ParameterTypeKind.Integer, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("list");

        public static readonly FunctionSymbol MakeListWithNulls =
            new FunctionSymbol("make_list_with_nulls", ScalarTypes.Dynamic,
                new Parameter("expr", ParameterTypeKind.Scalar))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("list");

        public static readonly FunctionSymbol MakeSet_Depricated =
            new FunctionSymbol("makeset", ScalarTypes.Dynamic,
                new Parameter("expr", ParameterTypeKind.Scalar),
                new Parameter("maxSize", ParameterTypeKind.Integer, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("set").Hide();

        public static readonly FunctionSymbol MakeSet =
            new FunctionSymbol("make_set", ScalarTypes.Dynamic,
                new Parameter("expr", ParameterTypeKind.Scalar),
                new Parameter("maxSize", ParameterTypeKind.Integer, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("set");

        public static readonly FunctionSymbol MakeSetIf =
            new FunctionSymbol("make_set_if", ScalarTypes.Dynamic,
                new Parameter("expr", ParameterTypeKind.Scalar),
                new Parameter("predicate", ScalarTypes.Bool),
                new Parameter("maxSize", ParameterTypeKind.Integer, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("set");

        public static readonly FunctionSymbol Passthrough =
           new FunctionSymbol("passthrough", ReturnTypeKind.Parameter0,
               new Parameter("expr", ParameterTypeKind.Scalar))
           .WithResultNameKind(ResultNameKind.FirstArgument)
           .Hide();

        public static readonly FunctionSymbol MakeDictionary =
            new FunctionSymbol("make_dictionary", ScalarTypes.Dynamic,
                new Parameter("expr", ScalarTypes.Dynamic),
                new Parameter("maxSize", ParameterTypeKind.Integer, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("dictionary")
            .Hide();

        public static readonly FunctionSymbol MakeBag =
            new FunctionSymbol("make_bag", ScalarTypes.Dynamic,
                new Parameter("expr", ScalarTypes.Dynamic),
                new Parameter("maxSize", ParameterTypeKind.Integer, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("bag");

        public static readonly FunctionSymbol MakeBagIf =
            new FunctionSymbol("make_bag_if", ScalarTypes.Dynamic,
                new Parameter("expr", ScalarTypes.Dynamic),
                new Parameter("predicate", ScalarTypes.Bool),
                new Parameter("maxSize", ParameterTypeKind.Integer, minOccurring: 0))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("bag");

        public static readonly FunctionSymbol BuildSchema =
            new FunctionSymbol("buildschema", ScalarTypes.Dynamic,
                new Parameter("expr", ScalarTypes.Dynamic))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("schema");

        public static readonly FunctionSymbol BinaryAllOr =
           new FunctionSymbol("binary_all_or",
               new Signature(ReturnTypeKind.Parameter0,
                   new Parameter("expr", ParameterTypeKind.Summable)))
            .WithResultNameKind(ResultNameKind.FirstArgument);

        public static readonly FunctionSymbol BinaryAllAnd =
          new FunctionSymbol("binary_all_and",
              new Signature(ReturnTypeKind.Parameter0,
                  new Parameter("expr", ParameterTypeKind.Summable)))
          .WithResultNameKind(ResultNameKind.FirstArgument);

        public static readonly FunctionSymbol BinaryAllXor =
          new FunctionSymbol("binary_all_xor",
              new Signature(ReturnTypeKind.Parameter0,
                  new Parameter("expr", ParameterTypeKind.Summable)))
          .WithResultNameKind(ResultNameKind.FirstArgument)
          .Hide(); // TODO: open in March 2020

        private static void AddPercentileColumns(List<ColumnSymbol> columns, Signature signature, string valueParameterName, string percentileParameterName, IReadOnlyList<Expression> args)
        {
            var valueArg = GetArgument(args, signature, valueParameterName);
            var valueArgName = GetExpressionResultName(valueArg);

            var percentileParameter = signature.GetParameter(percentileParameterName);
            var argumentParameters = signature.GetArgumentParameters(args);
            GetArgumentRange(argumentParameters, percentileParameter, out var start, out var length);

            var resultType = valueArg.ResultType;
            if (resultType == ScalarTypes.Int)
                resultType = ScalarTypes.Long;
            else if (resultType == ScalarTypes.Decimal)
                resultType = ScalarTypes.Real;

            for (int p = start; p < start + length; p++)
            {
                var percentileArg = args[p];
                var percentileFragment = MakeValidNameFragment(GetLiteralValue(percentileArg));
                var name = percentileParameterName + "_" + valueArgName + "_" + percentileFragment;

                columns.Add(new ColumnSymbol(name, resultType));
            }
        }

        private static CustomReturnType PercentileReturn = (table, args, signature) =>
        {
            var cols = new List<ColumnSymbol>();
            AddPercentileColumns(cols, signature, "expr", "percentile", args);
            return new TupleSymbol(cols);
        };

        private static CustomReturnType PercentileArrayReturn = (table, args, signature) =>
        {
            var cols = new List<ColumnSymbol>();
            var valueArg = GetArgument(args, signature, "expr");
            var valueArgName = GetExpressionResultName(valueArg);
            cols.Add(new ColumnSymbol("percentiles_" + valueArgName, ScalarTypes.Dynamic));
            return new TupleSymbol(cols);
        };

        public static readonly FunctionSymbol Percentile =
            new FunctionSymbol("percentile", PercentileReturn, Tabularity.Scalar,
                new Parameter("expr", ParameterTypeKind.Scalar),
                new Parameter("percentile", ParameterTypeKind.Number));

        public static readonly FunctionSymbol Percentiles =
            new FunctionSymbol("percentiles", PercentileReturn, Tabularity.Scalar,
                new Parameter("expr", ParameterTypeKind.Scalar),
                new Parameter("percentile", ParameterTypeKind.Number, minOccurring: 1, maxOccurring: MaxRepeat));

        public static readonly FunctionSymbol PercentilesArray =
            new FunctionSymbol("percentiles_array",
                new Signature(PercentileArrayReturn, Tabularity.Scalar,
                    new Parameter("expr", ParameterTypeKind.Scalar),
                    new Parameter("percentile", ParameterTypeKind.Number, minOccurring: 1, maxOccurring: MaxRepeat)),
                new Signature(PercentileArrayReturn, Tabularity.Scalar,
                    new Parameter("expr", ParameterTypeKind.Scalar),
                    new Parameter("percentiles", ScalarTypes.Dynamic)));

        public static readonly FunctionSymbol PercentileW =
            new FunctionSymbol("percentilew", PercentileReturn, Tabularity.Scalar,
                new Parameter("expr", ParameterTypeKind.Scalar),
                new Parameter("weight", ParameterTypeKind.Integer),
                new Parameter("percentile", ParameterTypeKind.Number));

        public static readonly FunctionSymbol PercentilesW =
            new FunctionSymbol("percentilesw", PercentileReturn, Tabularity.Scalar,
                new Parameter("expr", ParameterTypeKind.Scalar),
                new Parameter("weight", ParameterTypeKind.Integer),
                new Parameter("percentile", ParameterTypeKind.Number, minOccurring: 1, maxOccurring: MaxRepeat));

        public static readonly FunctionSymbol PercentilesWArray =
            new FunctionSymbol("percentilesw_array",
                new Signature(PercentileArrayReturn, Tabularity.Scalar,
                    new Parameter("expr", ParameterTypeKind.Scalar),
                    new Parameter("weight", ParameterTypeKind.Integer),
                    new Parameter("percentile", ParameterTypeKind.Number, minOccurring: 1, maxOccurring: MaxRepeat)),
                new Signature(PercentileArrayReturn, Tabularity.Scalar,
                    new Parameter("expr", ParameterTypeKind.Scalar),
                    new Parameter("weight", ParameterTypeKind.Integer),
                    new Parameter("percentiles", ScalarTypes.Dynamic)));

        public static readonly FunctionSymbol Stdev =
            new FunctionSymbol("stdev", ScalarTypes.Real,
                new Parameter("expr", ParameterTypeKind.Summable))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("stdev");

        public static readonly FunctionSymbol StdevIf =
            new FunctionSymbol("stdevif", ScalarTypes.Real,
                new Parameter("expr", ParameterTypeKind.Summable),
                new Parameter("predicate", ScalarTypes.Bool))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("stdevif");

        public static readonly FunctionSymbol Stdevp =
            new FunctionSymbol("stdevp", ScalarTypes.Real,
                new Parameter("expr", ParameterTypeKind.Summable))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("stdevp");

        public static readonly FunctionSymbol Variance =
            new FunctionSymbol("variance", ScalarTypes.Real,
                new Parameter("expr", ParameterTypeKind.Summable))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("variance");

        public static readonly FunctionSymbol VarianceIf =
            new FunctionSymbol("varianceif", ScalarTypes.Real,
                new Parameter("expr", ParameterTypeKind.Summable),
                new Parameter("predicate", ScalarTypes.Bool))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("varianceif");

        public static readonly FunctionSymbol Variancep =
            new FunctionSymbol("variancep", ScalarTypes.Real,
                new Parameter("expr", ParameterTypeKind.Summable))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("variancep");

        public static readonly FunctionSymbol Any =
            new FunctionSymbol("any",
                new Signature(
                    GetAnyResult,
                    Tabularity.Scalar,
                    new Parameter("expr", ParameterTypeKind.Scalar, minOccurring: 1, maxOccurring: MaxRepeat)),
                new Signature(
                    GetAnyResult,
                    Tabularity.Scalar,
                    new Parameter("expr", ParameterTypeKind.Scalar, ArgumentKind.Star)));

        public static readonly FunctionSymbol AnyIf =
            new FunctionSymbol("anyif",
                new Signature(
                    ReturnTypeKind.Parameter0,
                    new Parameter("expr", ParameterTypeKind.Scalar),
                    new Parameter("predicate", ScalarTypes.Bool)))
            .WithResultNameKind(ResultNameKind.PrefixAndFirstArgument)
            .WithResultNamePrefix("anyif");

        public static TypeSymbol GetAnyResult(TableSymbol table, IReadOnlyList<Expression> args)
        {
            var columns = new List<ColumnSymbol>();

            var doNotRepeat = new HashSet<ColumnSymbol>(GetSummarizeByColumns(args));

            for (int i = 0; i < args.Count; i++)
            {
                var arg = args[i];

                if (arg is StarExpression)
                {
                    foreach (var c in table.Columns)
                    {
                        if (!doNotRepeat.Contains(c))
                        {
                            columns.Add(c.WithName("any_" + c.Name));
                        }
                    }
                }
                else if (arg.ReferencedSymbol is ColumnSymbol c)
                {
                    columns.Add(c.WithName("any_" + c.Name));
                }
                else
                {
                    var col = new ColumnSymbol(Binding.Binder.GetExpressionResultName(arg, "column"), arg.ResultType);
                    columns.Add(col);
                }
            }

            return new TupleSymbol(columns);
        }

        public static readonly FunctionSymbol ArgMin =
            new FunctionSymbol("arg_min",
                new Signature(
                    GetArgMinMaxResult,
                    Tabularity.Scalar,
                    new Parameter("minimized", ParameterTypeKind.Summable),
                    new Parameter("returned", ParameterTypeKind.Scalar, minOccurring: 0, maxOccurring: MaxRepeat)),
                new Signature(
                    GetArgMinMaxResult,
                    Tabularity.Scalar,
                    new Parameter("minimized", ParameterTypeKind.Summable),
                    new Parameter("returned", ParameterTypeKind.Scalar, ArgumentKind.Star)));

        public static readonly FunctionSymbol ArgMax =
            new FunctionSymbol("arg_max",
                new Signature(
                    GetArgMinMaxResult,
                    Tabularity.Scalar,
                    new Parameter("maximized", ParameterTypeKind.Summable),
                    new Parameter("returned", ParameterTypeKind.Scalar, minOccurring: 0, maxOccurring: MaxRepeat)),
                new Signature(
                    GetArgMinMaxResult,
                    Tabularity.Scalar,
                    new Parameter("maximized", ParameterTypeKind.Summable),
                    new Parameter("returned", ParameterTypeKind.Scalar, ArgumentKind.Star)));

        private static TypeSymbol GetArgMinMaxResult(TableSymbol table, IReadOnlyList<Expression> args)
        {
            var columns = new List<ColumnSymbol>();
            var doNotRepeat = new HashSet<ColumnSymbol>(GetSummarizeByColumns(args));

            for (int i = 0; i < args.Count; i++)
            {
                var arg = args[i];

                if (arg is StarExpression)
                {
                    foreach (var c in table.Columns)
                    {
                        if (!doNotRepeat.Contains(c))
                        {
                            columns.Add(c);
                        }
                    }
                }
                else if (arg.ReferencedSymbol is ColumnSymbol c)
                {
                    // don't let * repeat this column
                    doNotRepeat.Add(c);

                    // change identity of explicitly referenced columns so won't match same columns already in projection list
                    columns.Add(new ColumnSymbol(c.Name, c.Type));
                }
                else
                {
                    var col = new ColumnSymbol(Binding.Binder.GetExpressionResultName(arg, "column"), arg.ResultType);
                    columns.Add(col);
                }
            }

            return new TupleSymbol(columns);
        }

        public static readonly FunctionSymbol ArgMin_Depricated =
            new FunctionSymbol("argmin",
                    new Signature(
                        GetArgMinMaxDepResult,
                        Tabularity.Scalar,
                        new Parameter("minimized", ParameterTypeKind.Summable),
                        new Parameter("returned", ParameterTypeKind.Scalar, minOccurring: 0, maxOccurring: MaxRepeat)),
                    new Signature(
                        GetArgMinMaxDepResult,
                        Tabularity.Scalar,
                        new Parameter("minimized", ParameterTypeKind.Summable),
                        new Parameter("returned", ParameterTypeKind.Scalar, ArgumentKind.Star)))
                    .WithResultNamePrefix("min")
                    .Hide();

        public static readonly FunctionSymbol ArgMax_Depricated =
            new FunctionSymbol("argmax",
                new Signature(
                    GetArgMinMaxDepResult,
                    Tabularity.Scalar,
                    new Parameter("maximized", ParameterTypeKind.Summable),
                    new Parameter("returned", ParameterTypeKind.Scalar, minOccurring: 0, maxOccurring: MaxRepeat)),
                new Signature(
                    GetArgMinMaxDepResult,
                    Tabularity.Scalar,
                    new Parameter("maximized", ParameterTypeKind.Summable),
                    new Parameter("returned", ParameterTypeKind.Scalar, ArgumentKind.Star)))
                .WithResultNamePrefix("max")
                .Hide();

        private static TypeSymbol GetArgMinMaxDepResult(TableSymbol table, IReadOnlyList<Expression> args)
        {
            var columns = new List<ColumnSymbol>();

            if (args.Count > 0)
            {
                var primaryArg = args[0];
                var primaryColName = Binding.Binder.GetExpressionResultName(primaryArg, "column");
                var primaryCol = new ColumnSymbol(primaryColName, primaryArg.ResultType);
                columns.Add(primaryCol);

                // determine columns in by expression
                var doNotRepeat = new HashSet<ColumnSymbol>(GetSummarizeByColumns(args));

                for (int i = 1; i < args.Count; i++)
                {
                    var arg = args[i];

                    if (arg is StarExpression)
                    {
                        foreach (var c in table.Columns)
                        {
                            if (c != primaryArg.ReferencedSymbol && !doNotRepeat.Contains(c))
                            {
                                columns.Add(c.WithName(primaryColName + "_" + c.Name));
                            }
                        }
                    }
                    else if (arg.ReferencedSymbol is ColumnSymbol c)
                    {
                        columns.Add(c.WithName(primaryColName + "_" + c.Name));
                    }
                    else
                    {
                        var col = new ColumnSymbol(primaryColName + "_" + Binding.Binder.GetExpressionResultName(arg, "column"), arg.ResultType);
                        columns.Add(col);
                    }
                }
            }

            return new TupleSymbol(columns);
        }


        public static IReadOnlyList<FunctionSymbol> All { get; } = new FunctionSymbol[]
        {
            Sum,
            SumIf,
            Cnt,
            Count,
            CountIf,
            DCount,
            DCountIf,
            TDigest,
            TDigestMerge,
            MergeTDigests,
            Hll,
            HllMerge,
            Min,
            MinIf,
            Max,
            MaxIf,
            Avg,
            AvgIf,
            MakeList_Depricated,
            MakeList,
            MakeListIf,
            MakeListWithNulls,
            MakeSet_Depricated,
            MakeSet,
            MakeSetIf,
            MakeDictionary,
            MakeBag,
            MakeBagIf,
            BuildSchema,
            Passthrough,
            Percentile,
            Percentiles,
            PercentilesArray,
            PercentileW,
            PercentilesW,
            PercentilesWArray,
            Stdev,
            StdevIf,
            Stdevp,
            Variance,
            VarianceIf,
            Variancep,
            Any,
            AnyIf,
            ArgMin,
            ArgMax,
            ArgMin_Depricated,
            ArgMax_Depricated,
            BinaryAllOr,
            BinaryAllAnd,
            BinaryAllXor,
        };
    }
}