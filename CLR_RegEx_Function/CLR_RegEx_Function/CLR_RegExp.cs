using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;


namespace CLR_RegEx_Function
{
    public static class CLR_RegExp
    {
        [SqlProcedure]
        public static void IsMatch(SqlString value, SqlString pattern, out SqlBoolean strOutParam)
        {
            strOutParam =  Regex.IsMatch(value.Value, pattern.Value);
        }
    }
}
