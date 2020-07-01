# Databases

Kusto follows a relation model of storing the data where upper-level entity is a `database`. 

Kusto cluster can host several databases, where each database will host its own  collection of [tables](tables.md), [stored functions](stored-functions.md), and [external tables](externaltables.md).
Each database has its own permissions set, based on [Role Based Access Control (RBAC) model](../../management/access-control/index.md)

**Notes**  

* Database names are case-insensitive.
* Database names must follow the rules for [entity names](./entity-names.md).
* Maximum limit of databases per cluster is 10,000.
