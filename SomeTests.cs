using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace main_site
{
    public class SomeTests
    {
        [Theory]
        [ClassData(typeof(TestData))]
        public void Test(int a)
        {
            Assert.True(a >= 0);
        }
    }

    public class TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i < 118; i++)
            {
                yield return new object[] { i };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
