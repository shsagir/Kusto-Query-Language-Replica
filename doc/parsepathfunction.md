# parse_path()

Parses a file path `string` and returns a [`dynamic`](./scalar-data-types/dynamic.md) object that contains the following parts of the path: 
Scheme, RootPath, DirectoryPath, DirectoryName, FileName, Extension, AlternateDataStreamName.
In addition to the simple paths with both types of slashes, supports paths with schemas (e.g. "file://..."), shared paths (e.g. "\\shareddrive\users..."), long paths (e.g "\\?\C:...""), alternate data streams (e.g. "file1.exe:file2.exe")

**Syntax**

`parse_path(`*path*`)`

**Arguments**

* *path*: A string that represents a file path.

**Returns**

An object of type `dynamic` that inculded the path components as listed above.

**Example**

<!-- csl: https://help.kusto.windows.net/Samples -->
<!-- csl: http://localhost:80/db1 -->
```
datatable(p:string) 
[
    @"C:\temp\file.txt",
    @"temp\file.txt",
    "file://C:/temp/file.txt:some.exe",
    @"\\shared\users\temp\file.txt.gz",
    "/usr/lib/temp/file.txt"
]
| extend path_parts = parse_path(p)

```

|p|path_parts
|---|---
|C:\temp\file.txt|{"Scheme":"","RootPath":"C:","DirectoryPath":"C:\\temp","DirectoryName":"temp","Filename":"file.txt","Extension":"txt","AlternateDataStreamName":""}
|temp\file.txt|{"Scheme":"","RootPath":"","DirectoryPath":"temp","DirectoryName":"temp","Filename":"file.txt","Extension":"txt","AlternateDataStreamName":""}
|file://C:/temp/file.txt:some.exe|{"Scheme":"file","RootPath":"C:","DirectoryPath":"C:/temp","DirectoryName":"temp","Filename":"file.txt","Extension":"txt","AlternateDataStreamName":"some.exe"}
|\\shared\users\temp\file.txt.gz|{"Scheme":"","RootPath":"","DirectoryPath":"\\\\shared\\users\\temp","DirectoryName":"temp","Filename":"file.txt.gz","Extension":"gz","AlternateDataStreamName":""}
|/usr/lib/temp/file.txt|{"Scheme":"","RootPath":"","DirectoryPath":"/usr/lib/temp","DirectoryName":"temp","Filename":"file.txt","Extension":"txt","AlternateDataStreamName":""}

