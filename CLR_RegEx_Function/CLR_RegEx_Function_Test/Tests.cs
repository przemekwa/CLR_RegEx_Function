using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CLR_RegEx_Function_Test
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            var input = "Przemek123";
            var pattern = "[0-9]{3}";

            CLR_RegEx_Function.CLR_RegExp.IsMatch(input, pattern, out SqlBoolean result);

            Assert.True(result.Value);

        }

        [Fact]
        public void Test2()
        {
            var input = "Przemek123";
            var pattern = "P.*123";

            CLR_RegEx_Function.CLR_RegExp.IsMatch(input, pattern, out SqlBoolean result);

            Assert.True(result.Value);

        }

        [Fact]
        public void Test3()
        {
            var input = "Przemek123";
            var pattern = "^[A-Za-z]*123$";

            CLR_RegEx_Function.CLR_RegExp.IsMatch(input, pattern, out SqlBoolean result);

            Assert.True(result.Value);

        }

        [Fact]
        public void Test4()
        {
            var input = "Przemek123";
            var pattern = "Rafał";

            CLR_RegEx_Function.CLR_RegExp.IsMatch(input, pattern, out SqlBoolean result);

            Assert.False(result.Value);

        }

        [Fact]
        public void Test5()
        {
            var input = "Przemek123";
            var pattern = "^[A-Za-z]*$";

            CLR_RegEx_Function.CLR_RegExp.IsMatch(input, pattern, out SqlBoolean result);

            Assert.False(result.Value);

        }
    }
}
