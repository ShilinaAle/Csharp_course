using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        [TestCase("''", 0, "", 2)]
        [TestCase("'a'", 0, "a", 3)]
        [TestCase("\"\\\"ab\\\"c\"", 0, "\"ab\"c", 9)]
        [TestCase("'", 0, "", 1)]
        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        }
    }

    class QuotedFieldTask
    {
        public static Token ReadQuotedField(string line, int startIndex)
        {
            char open = line[startIndex];
            var counter = 0;
            int indOfLine = startIndex + 1;
            while (indOfLine < line.Length)
            {
                var currentChar = line[indOfLine];
                if (currentChar == '\\')
                {
                    line = line.Substring(startIndex, indOfLine - startIndex) +
                        line.Substring(indOfLine + 1, line.Length - indOfLine - 1);
                    indOfLine += 1;
                    counter++;
                    continue;
                }
                if (currentChar == open)
                {
                    line = line.Substring(startIndex + 1, indOfLine - startIndex - 1);
                    return new Token(line, startIndex, indOfLine - startIndex + 1 + counter);
                }
                indOfLine++;

            }
            line = line.Substring(startIndex + 1, line.Length - startIndex - 1);
            return new Token(line, startIndex, line.Length - startIndex + 1 + counter);
        }
    }
}
