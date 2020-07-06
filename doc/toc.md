# Overview
## [Kusto query](./index.md)
## [Tutorial](tutorial.md)
## [Samples](samples.md) 
## [Best practices](best-practices.md)
## [Cross-database and cross-cluster queries](cross-cluster-or-database-queries.md)

# Entities
## [Entity types](./schema-entities/index.md)
## [Entity names](./schema-entities/entity-names.md)
<!-- Enable this section when the actual content is available, blank pages are confusing external customers.
## [Entity references](./schema-entities/entity-references.md)
## [Clusters](./schema-entities/clusters.md)
## [Databases](./schema-entities/databases.md)
-->
## [Tables](./schema-entities/tables.md)
## [Columns](./schema-entities/columns.md)
## [Stored functions](./schema-entities/stored-functions.md)
## [External tables](./schema-entities/externaltables.md)

# Data types
## [Scalar data types overview](./scalar-data-types/index.md)
## [bool](./scalar-data-types/bool.md)
## [datetime](./scalar-data-types/datetime.md)
## [decimal](./scalar-data-types/decimal.md)
## [dynamic](./scalar-data-types/dynamic.md)
## [guid](./scalar-data-types/guid.md)
## [int](./scalar-data-types/int.md)
## [long](./scalar-data-types/long.md)
## [real](./scalar-data-types/real.md)
## [string](./scalar-data-types/string.md)
## [timespan](./scalar-data-types/timespan.md)
## [Null values](./scalar-data-types/null-values.md)

# Functions
## [Function types](./functions/index.md)
## [User-defined functions](./functions/user-defined-functions.md)

# Query statements
## [Query statement types](statements.md)
## [Alias statement](aliasstatement.md)
## [Let statement](letstatement.md)
## [Pattern statement](patternstatement.md)
## [Query parameters statement](queryparametersstatement.md)
## [Restrict statement](restrictstatement.md)
## [Set statement](setstatement.md)
## [Tabular expression statements](tabularexpressionstatements.md)
## [Batches](batches.md)

# Tabular operators
## [tablular data](queries.md)
## [as operator](asoperator.md)
## [consume operator](consumeoperator.md)
## [count operator](countoperator.md)
## [datatable operator](datatableoperator.md)
## [distinct operator](distinctoperator.md)
## evaluate operator
### [evaluate plugin operator](evaluateoperator.md)
### [autocluster](autoclusterplugin.md)
### [bag_unpack](bag-unpackplugin.md)
### [basket](basketplugin.md)
<!--### [diagnose](diagnoseplugin.md)-->
### [dcount_intersect](dcount-intersect-plugin.md)
### [diffpatterns](diffpatternsplugin.md)
### [diffpatterns_text](diffpatterns-textplugin.md)
### [infer_storage_schema](inferstorageschemaplugin.md)
### [narrow](narrowplugin.md)
### [pivot](pivotplugin.md)
### [preview](previewplugin.md)
### [python](pythonplugin.md)
### [R](rplugin.md)
### [rolling_percentile](rolling-percentile-plugin.md)
### [schema_merge](schemamergeplugin.md)
### [sql_request](sqlrequestplugin.md)
### [sequence_detect](sequence-detect-plugin.md)
## [extend operator](extendoperator.md)
## [externaldata operator](externaldata-operator.md)
## [facet operator](facetoperator.md)
## [find operator](findoperator.md)
## [fork operator](forkoperator.md)
## [getschema operator](getschemaoperator.md)
## [invoke operator](invokeoperator.md)
## join operator
### [join operator overview](joinoperator.md)
### [shuffle](shufflequery.md)
### [Cross-cluster join](joincrosscluster.md)
### [Broadcast join](broadcastjoin.md)
### [Time window join](join-timewindow.md)
## [limit operator](limitoperator.md)
## [lookup operator](lookupoperator.md)
## [make-series operator](make-seriesoperator.md)
## [mv-apply operator](mv-applyoperator.md)
## [mv-expand operator](mvexpandoperator.md)
## [order operator](orderoperator.md)
## [project operator](projectoperator.md)
## [project-away operator](projectawayoperator.md)
## [project-rename operator](projectrenameoperator.md)
## [project-reorder operator](projectreorderoperator.md)
## [parse operator](parseoperator.md)
## [parse-where operator](parsewhereoperator.md)
## [partition operator](partitionoperator.md)
## [print operator](printoperator.md)
## [range operator](rangeoperator.md)
## [reduce operator](reduceoperator.md)
## [render operator](renderoperator.md)
## [sample operator](sampleoperator.md)
## [sample-distinct operator](sampledistinctoperator.md)
## [search operator](searchoperator.md)
## [serialize operator](serializeoperator.md)
## [sort operator](sortoperator.md)
## summarize operator
### [summarize operator overview](summarizeoperator.md)
### [Using hll() and tdigest()](usinghlltdigest.md)
### [shuffle](shufflequery.md)
## [take operator](takeoperator.md)
## [top operator](topoperator.md)
## [top-nested operator](topnestedoperator.md)
## [top-hitters operator](tophittersoperator.md)
## [union operator](unionoperator.md)
## [where operator](whereoperator.md)

# Special functions
## [cluster()](clusterfunction.md)
## [database()](databasefunction.md)
## [external_table()](externaltablefunction.md)
## [materialize()](materializefunction.md)
## [table()](tablefunction.md)
## [toscalar()](toscalarfunction.md)

# Scalar operators
## [Bitwise (binary) operators](binoperators.md)
## [Datetime/timespan arithmetic](datetime-timespan-arithmetic.md)
## [Logical (binary) operators](logicaloperators.md)
## [Numerical operators](numoperators.md)
## [String operators](datatypes-string-operators.md)
## [between operator](betweenoperator.md)
## [not-between operator (!between)](notbetweenoperator.md)
## [in and !in operators](inoperator.md)
## [has_any operator](has-anyoperator.md)

# Scalar functions
## [Scalar function types](scalarfunctions.md)
## [abs()](abs-function.md)
## [acos()](acosfunction.md)
## [ago()](agofunction.md)
## [array_concat()](arrayconcatfunction.md)
## [array_iif()](arrayifffunction.md)
## [array_index_of()](arrayindexoffunction.md)
## [array_length()](arraylengthfunction.md)
## [array_rotate_left()](array_rotate_leftfunction.md)
## [array_rotate_right()](array_rotate_rightfunction.md)
## [array_shift_left()](array_shift_leftfunction.md)
## [array_shift_right()](array_shift_rightfunction.md)
## [array_slice()](arrayslicefunction.md)
## [array_split()](arraysplitfunction.md)
## [asin()](asinfunction.md)
## [assert()](assert-function.md)
## [atan()](atanfunction.md)
## [atan2()](atan2function.md)
## [bag_keys()](bagkeysfunction.md)
## [base64_decode_toarray()](base64_decode_toarrayfunction.md)
## [base64_decode_tostring()](base64_decode_tostringfunction.md)
## [base64_encode_fromarray()](base64_encode_fromarrayfunction.md)
## [base64_encode_tostring()](base64_encode_tostringfunction.md)
## [beta_cdf()](beta-cdffunction.md)
## [beta_inv()](beta-invfunction.md)
## [beta_pdf()](beta-pdffunction.md)
## [bin()](binfunction.md)
## [bin_at()](binatfunction.md)
## [bin_auto()](bin-autofunction.md)
## [binary_and()](binary-andfunction.md)
## [binary_not()](binary-notfunction.md)
## [binary_or()](binary-orfunction.md)
## [binary_shift_left()](binary-shift-leftfunction.md)
## [binary_shift_right()](binary-shift-rightfunction.md)
## [binary_xor()](binary-xorfunction.md)
## [bitset_count_ones()](bitset-count-onesfunction.md)
## [case()](casefunction.md)
## [ceiling()](ceilingfunction.md)
## [coalesce()](coalescefunction.md)
## [column_ifexists()](columnifexists.md)
## [cos()](cosfunction.md)
## [cot()](cotfunction.md)
## [countof()](countoffunction.md)
## [current_cluster_endpoint()](current-cluster-endpoint-function.md)
## [current_cursor()](cursorcurrent.md)
## [current_database()](current-database-function.md)
## [current_principal()](current-principalfunction.md)
## [current_principal_details()](current-principal-detailsfunction.md)
## [current_principal_is_member_of()](current-principal-ismemberoffunction.md)
## [cursor_after()](cursorafterfunction.md)
## [cursor_before_or_at()](cursorbeforeoratfunction.md)
## [cursor_current()](cursorcurrent.md)
## [datetime_add()](datetime-addfunction.md)
## [datetime_diff()](datetime-difffunction.md)
## [datetime_part()](datetime-partfunction.md)
## [dayofmonth()](dayofmonthfunction.md)
## [dayofweek()](dayofweekfunction.md)
## [dayofyear()](dayofyearfunction.md)
## [dcount_hll()](dcount-hllfunction.md)
## [degrees()](degreesfunction.md)
## [endofday()](endofdayfunction.md)
## [endofmonth()](endofmonthfunction.md)
## [endofweek()](endofweekfunction.md)
## [endofyear()](endofyearfunction.md)
## [estimate_data_size()](estimate-data-sizefunction.md)
## [exp()](exp-function.md)
## [exp10()](exp10-function.md)
## [exp2()](exp2-function.md)
## [extent_id()](extentidfunction.md)
## [extent_tags()](extenttagsfunction.md)
## [extract()](extractfunction.md)
## [extract_all()](extractallfunction.md)
## [extractjson()](extractjsonfunction.md)
## [floor()](floorfunction.md)
## [format_bytes()](format-bytesfunction.md)
## [format_datetime()](format-datetimefunction.md)
## [format_timespan()](format-timespanfunction.md)
## [gamma()](gammafunction.md)
## [getmonth()](getmonthfunction.md)
## [gettype()](gettypefunction.md)
## [getyear()](getyearfunction.md)
## [hash()](hashfunction.md)
## [hash_combine()](hash_combinefunction.md)
## [hash_many()](hash_manyfunction.md)
## [hash_sha256()](sha256hashfunction.md)
## [hll_merge()](hllmergefunction.md)
## [hourofday()](hourofdayfunction.md)
## [iif()](iiffunction.md)
## [indexof()](indexoffunction.md)
## [indexof_regex()](indexofregexfunction.md)
## [ingestion_time()](ingestiontimefunction.md)
## [ipv4_compare](ipv4-comparefunction.md)
## [ipv4_is_match](ipv4-is-matchfunction.md)
## [isascii()](isascii.md)
## [isempty()](isemptyfunction.md)
## [isfinite()](isfinitefunction.md)
## [isinf()](isinffunction.md)
## [isnan()](isnanfunction.md)
## [isnotempty(), notempty()](isnotemptyfunction.md)
## [isnotnull(), notempty()](isnotnullfunction.md)
## [isnull()](isnullfunction.md)
## [isutf8()](isutf8.md)
## [log()](log-function.md)
## [log10()](log10-function.md)
## [log2()](log2-function.md)
## [loggamma()](loggammafunction.md)
## [make_datetime()](make-datetimefunction.md)
## [make_string()](makestringfunction.md)
## [make_timespan()](make-timespanfunction.md)
## [max_of()](max-offunction.md)
## [min_of()](min-offunction.md)
## [monthofyear()](monthofyearfunction.md)
## [new_guid()](newguidfunction.md)
## [not()](notfunction.md)
## [now()](nowfunction.md)
## [pack()](packfunction.md)
## [pack_all()](packallfunction.md)
## [pack_array()](packarrayfunction.md)
## [pack_dictionary()](packdictionaryfunction.md)
## [parse_csv()](parsecsvfunction.md)
## [parse_ipv4()](parse-ipv4function.md)
## [parse_ipv4_mask()](parse-ipv4-maskfunction.md)
## [parse_json()](parsejsonfunction.md)
## [parse_path()](parsepathfunction.md)
## [parse_url()](parseurlfunction.md)
## [parse_urlquery()](parseurlqueryfunction.md)
## [parse_user_agent()](parse-useragentfunction.md)
## [parse_version()](parse-versionfunction.md)
## [parse_xml()](parse-xmlfunction.md)
## [percentile_tdigest()](percentile-tdigestfunction.md)
## [percentrank_tdigest()](percentrank-tdigestfunction.md)
## [pi()](pifunction.md)
## [pow()](powfunction.md)
## [radians()](radiansfunction.md)
## [rand()](randfunction.md)
## [range()](rangefunction.md)
## [rank_tdigest()](rank-tdigest.md)
## [repeat()](repeatfunction.md)
## [replace()](replacefunction.md)
## [reverse()](reversefunction.md)
## [round()](roundfunction.md)
## [set_difference()](setdifferencefunction.md)
## [set_has_element()](sethaselementfunction.md)
## [set_intersect()](setintersectfunction.md)
## [set_union()](setunionfunction.md)
## [sign()](signfunction.md)
## [sin()](sinfunction.md)
## [split()](splitfunction.md)
## [sqrt()](sqrtfunction.md)
## [startofday()](startofdayfunction.md)
## [startofmonth()](startofmonthfunction.md)
## [startofweek()](startofweekfunction.md)
## [startofyear()](startofyearfunction.md)
## [strcat()](strcatfunction.md)
## [strcat_array()](strcat-arrayfunction.md)
## [strcat_delim()](strcat-delimfunction.md)
## [strcmp()](strcmpfunction.md)
## [string_size()](stringsizefunction.md)
## [strlen()](strlenfunction.md)
## [strrep()](strrepfunction.md)
## [substring()](substringfunction.md)
## [tan()](tanfunction.md)
## [tdigest_merge()](tdigest-mergefunction.md)
## [to_utf8()](toutf8function.md)
## [tobool()](toboolfunction.md)
## [todatetime()](todatetimefunction.md)
## [todecimal()](todecimalfunction.md)
## [todouble()](todoublefunction.md)
## [todynamic()](todynamicfunction.md)
## [toguid()](toguidfunction.md)
## [tohex()](tohexfunction.md)
## [toint()](tointfunction.md)
## [tolong()](tolongfunction.md)
## [tolower()](tolowerfunction.md)
## [toreal()](todoublefunction.md)
## [tostring()](tostringfunction.md)
## [totimespan()](totimespanfunction.md)
## [toupper()](toupperfunction.md)
## [translate()](translatefunction.md)
## [treepath()](treepathfunction.md)
## [trim()](trimfunction.md)
## [trim_end()](trimendfunction.md)
## [trim_start()](trimstartfunction.md)
## [unixtime_microseconds_todatetime()](unixtime-microseconds-todatetimefunction.md)
## [unixtime_milliseconds_todatetime()](unixtime-milliseconds-todatetimefunction.md)
## [unixtime_nanoseconds_todatetime()](unixtime-nanoseconds-todatetimefunction.md)
## [unixtime_seconds_todatetime()](unixtime-seconds-todatetimefunction.md)
## [url_decode()](urldecodefunction.md)
## [url_encode()](urlencodefunction.md)
## [url_encode_component()](urlencodecomponentfunction.md)
## [weekofyear()](weekofyearfunction.md)
## [welch_test()](welch-testfunction.md)
## [zip()](zipfunction.md)

# Aggregation functions
## [any()](any-aggfunction.md)
## [anyif()](anyif-aggfunction.md)
## [arg_max()](arg-max-aggfunction.md)
## [arg_min()](arg-min-aggfunction.md)
## [avg()](avg-aggfunction.md)
## [avgif()](avgif-aggfunction.md)
## [binary_all_and](binary-all-and-aggfunction.md)
## [binary_all_or](binary-all-or-aggfunction.md)
## [binary_all_xor](binary-all-xor-aggfunction.md)
## [buildschema()](buildschema-aggfunction.md)
## [count()](count-aggfunction.md)
## [countif()](countif-aggfunction.md)
## [dcount()](dcount-aggfunction.md)
## [dcountif()](dcountif-aggfunction.md)
## [hll()](hll-aggfunction.md)
## [hll_merge()](hll-merge-aggfunction.md)
## [make_bag()](make-bag-aggfunction.md)
## [make_bag_if()](make-bag-if-aggfunction.md)
## [make_list()](makelist-aggfunction.md)
## [make_list_if()](makelistif-aggfunction.md)
## [make_list_with_nulls()](make-list-with-nulls-aggfunction.md)
## [make_set()](makeset-aggfunction.md)
## [make_set_if()](makesetif-aggfunction.md)
## [max()](max-aggfunction.md)
## [maxif()](maxif-aggfunction.md)
## [min()](min-aggfunction.md)
## [minif()](minif-aggfunction.md)
## [percentiles()](percentiles-aggfunction.md)
## [stdev()](stdev-aggfunction.md)
## [stdevif()](stdevif-aggfunction.md)
## [stdevp()](stdevp-aggfunction.md)
## [sum()](sum-aggfunction.md)
## [sumif()](sumif-aggfunction.md)
## [tdigest()](tdigest-aggfunction.md)
## [tdigest_merge()](tdigest-merge-aggfunction.md)
## [variance()](variance-aggfunction.md)
## [varianceif()](varianceif-aggfunction.md)
## [variancep()](variancep-aggfunction.md)

# Window functions
## [Window functions overview](windowsfunctions.md)
## [next()](nextfunction.md)
## [prev()](prevfunction.md)
## [row_cumsum()](rowcumsumfunction.md)
## [row_number()](rownumberfunction.md)
## [row_window_session()](row-window-session-function.md)

# Rolling window aggregations
## [rolling_percentile()](rolling-percentile-plugin.md)

# Time Series Analysis
## [make-series operator](make-seriesoperator.md)
## [series_add()](series-addfunction.md)
## [series_decompose()](series-decomposefunction.md)
## [series_decompose_anomalies()](series-decompose-anomaliesfunction.md)
## [series_decompose_forecast()](series-decompose-forecastfunction.md)
## [series_divide()](series-dividefunction.md)
## [series_equals()](series-equalsfunction.md)
## [series_fill_backward()](series-fill-backwardfunction.md)
## [series_fill_const()](series-fill-constfunction.md)
## [series_fill_forward()](series-fill-forwardfunction.md)
## [series_fill_linear()](series-fill-linearfunction.md)
## [series_fir()](series-firfunction.md)
## [series_fit_2lines()](series-fit-2linesfunction.md)
## [series_fit_2lines_dynamic()](series-fit-2lines-dynamicfunction.md)
## [series_fit_line()](series-fit-linefunction.md)
## [series_fit_line_dynamic()](series-fit-line-dynamicfunction.md)
## [series_greater()](series-greaterfunction.md)
## [series_greater_equals()](series-greater-equalsfunction.md)
## [series_iir()](series-iirfunction.md)
## [series_less()](series-lessfunction.md)
## [series_less_equals()](series-less-equalsfunction.md)
## [series_multiply()](series-multiplyfunction.md)
## [series_not_equals()](series-not-equalsfunction.md)
## [series_outliers()](series-outliersfunction.md)
## [series_pearson_correlation()](series-pearson-correlationfunction.md)
## [series_periods_detect()](series-periods-detectfunction.md)
## [series_periods_validate()](series-periods-validatefunction.md)
## [series_seasonal()](series-seasonalfunction.md)
## [series_stats()](series-statsfunction.md)
## [series_stats_dynamic()](series-stats-dynamicfunction.md)
## [series_subtract()](series-subtractfunction.md)
## [time series analysis overview](machine-learning-and-tsa.md)

# Machine Learning
## [autocluster](autoclusterplugin.md)
## [basket](basketplugin.md)
## [diffpatterns](diffpatternsplugin.md)
## [diffpatterns_text](diffpatterns-textplugin.md)

# Geospatial
## [geo_distance_2points()](geo-distance-2points-function.md)
## [geo_distance_point_to_line()](geo-distance-point-to-line-function.md)
## [geo_geohash_to_central_point()](geo-geohash-to-central-point-function.md)
## [geo_point_in_circle()](geo-point-in-circle-function.md)
## [geo_point_in_polygon()](geo-point-in-polygon-function.md)
## [geo_point_to_geohash()](geo-point-to-geohash-function.md)
## [geo_point_to_s2cell()](geo-point-to-s2cell-function.md)
## [geo_s2cell_to_central_point()](geo-s2cell-to-central-point-function.md)

# User Analytics
## [User Analytics plugins](useranalytics.md)
## [Active Users Count](active-users-count-plugin.md)
## [Activity Counts Metrics (total values, distinct values, new values)](activity-counts-metrics-plugin.md)
## [Activity Engagement (DAU, WAU, MAU)](activity-engagement-plugin.md)
## [Activity Metrics (retention, churn, new values)](activity-metrics-plugin.md)
## [Activity Metrics - New (retention, churn, new values)](new-activity-metrics-plugin.md)
## [Funnel Sequence Completion](funnel-sequence-completion-plugin.md)
## [Funnel Sequence](funnel-sequence-plugin.md)
## [Session Count](session-count-plugin.md)
## [Sliding Window Counts](sliding-window-counts-plugin.md)

# Reference material for Kusto Query Language
## [RE2 syntax](re2.md)
## [SQL to Kusto Cheat Sheet](sqlcheatsheet.md)