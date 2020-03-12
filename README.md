
CLR User-Defined Functions
====================


## CLR_RegEx_Function

Funckja daje możliwośc operacji na wyrażeniach regularnych w MS SQL przy użyciu biblioteki C# w MS SQL

### .NET

Otwieramy i kompilujemy projekt lub bierzmy wersję z releases (https://github.com/przemekwa/CLR_RegEx_Function/releases)
Dll umieszczamy gdzieś. Ścieżkę do dll podamy podczas rejestracji biblioteki w MS SQL. 
Poniżej opis co zrobić w MS SQL.


### Enable CLR

```SQL

EXEC sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO
EXEC sp_configure 'clr enabled'
GO

```

### SQL

```SQL

	-- DROP ASSEMBLY CLR_REG_EX
CREATE ASSEMBLY CLR_REG_EX FROM 'D:\CLR_RegEx_Function.dll';  
GO  
  
	-- DROP PROCEDURE IsMatch
CREATE PROCEDURE IsMatch(@value nvarchar(1000),@pattern nvarchar(1000), @strOutParam bit OUTPUT)
    AS EXTERNAL NAME CLR_REG_EX.[CLR_RegEx_Function.CLR_RegExp].[IsMatch]
GO

DECLARE @res bit;
EXEC dbo.IsMatch @value = 'Przemek123', @pattern = '^[A-Za-z]*123$', @strOutParam = @res OUTPUT;
SELECT @res

  
GO  

```



## Some other info

## Links

https://docs.microsoft.com/en-us/sql/relational-databases/clr-integration-database-objects-user-defined-functions/clr-user-defined-functions?view=sql-server-ver15
https://stackoverflow.com/questions/25394448/how-are-parameters-passed-from-sql-server-to-a-clr-based-stored-procedure

## Compile:

`csc.exe /t:library /out:FirstUdf.dll FirstUdf.cs   `

## SQL CREATE ASSEMBLY

```SQL
CREATE ASSEMBLY FirstUdf FROM 'D:\\FirstUdf.dll';  
GO  
  
CREATE FUNCTION CountSalesOrderHeader() RETURNS INT   
AS EXTERNAL NAME FirstUdf.T.ReturnOrderCount;   
GO  
  
SELECT dbo.CountSalesOrderHeader();  
GO 
```


## SQL DROP ASSEMBLY

```SQL

DROP FUNCTION CountSalesOrderHeader
DROP ASSEMBLY FirstUdf
```


## SQL ASSEMBLY WITH PARAMS


https://stackoverflow.com/questions/25394448/how-are-parameters-passed-from-sql-server-to-a-clr-based-stored-procedure

File: clr_function_with_params.cs


```SQL
CREATE ASSEMBLY FirstUdf FROM 'D:\Projects\clr_ms_sql_study\FirstUdf.dll';  
GO  
  

  -- DROP PROCEDURE MyProcedure
CREATE PROCEDURE MyProcedure(@strInParam nvarchar(1000), @strOutParam nvarchar(1000) OUTPUT)
    AS EXTERNAL NAME FirstUdf.[MyNamespace.MyClass].[MyMethod]
GO



DECLARE @res NVARCHAR(1000);
EXEC dbo.MyProcedure @strInParam = 'Siya', @strOutParam = @res OUTPUT;

SELECT @res

```




