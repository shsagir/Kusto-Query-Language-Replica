# base64_decode_tostring()

Decodes a base64 string to a UTF-8 string

**Syntax**

`base64_decode_tostring(`*String*`)`

**Arguments**

* *String*: Input string to be decoded from base64 to UTF8-8 string.

**Returns**

Returns UTF-8 string decoded from base64 string.

* For decoding base64 strings to an array of long values see [base64_decode_toarray()](base64_decode_toarrayfunction.md)
* For encoding strings to base64 string see [base64_encode_tostring()](base64_encode_tostringfunction.md)

**Example**

<!-- csl: https://help.kusto.windows.net:443/Samples -->
```
print Quine=base64_decode_tostring("S3VzdG8=")
```

|Quine|
|-----|
|Kusto|

Trying to decode a base64 string which was generated from invalid UTF-8 encoding will return null:

<!-- csl: https://help.kusto.windows.net:443/Samples -->
```
print Empty=base64_decode_tostring("U3RyaW5n0KHR0tGA0L7Rh9C60LA=")
```

|Empty|
|-----|
||
