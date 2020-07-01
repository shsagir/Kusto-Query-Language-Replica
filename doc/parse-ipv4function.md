# parse_ipv4()

Converts IPv4 string to long (signed 64-bit) number representation.

<!-- csl -->
```
parse_ipv4("127.0.0.1") == 2130706433
parse_ipv4('192.1.168.1') < parse_ipv4('192.1.168.2') == true
```

**Syntax**

`parse_ipv4(`*Expr*`)`

**Arguments**

* *Expr*: String expression representing IPv4 that will be converted to long. String may include net-mask using [IP-prefix notation](#ip-prefix-notation).

### IP-prefix notation

It is a common practice to define IP addresses using `IP-prefix notation` using a slash (`/`) character.
The IP address to the LEFT of the slash (`/`) is the base IP address, and the number (1 to 32) to the RIGHT of the slash (/) is the number of contiguous 1 bits in the netmask. Thus, 192.168.2.0/24 will have an associated net/subnetmask containing 24 contiguous bits or 255.255.255.0 in dotted decimal format.

**Returns**

If conversion is successful, result will be a long number.
If conversion is not successful, result will be `null`.
 
**Example**

<!-- csl: https://help.kusto.windows.net/Samples -->
```
datatable(ip_string:string)
[
 '192.168.1.1',
 '192.168.1.1/24',
 '255.255.255.255/31'
]
| extend ip_long = parse_ipv4(ip_string)
```

|ip_string|ip_long|
|---|---|
|192.168.1.1|3232235777|
|192.168.1.1/24|3232235776|
|255.255.255.255/31|4294967294|
