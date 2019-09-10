using System;
using Xunit;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using aggregate_gdp_population;

namespace XUnitTestGDP
{
    public class Class1
    {
        

        [Fact]
        public void Test1()
        {
            Program.GDP();

            bool right = false;
            if (File.Exists("../../../../expected-output.json"))
            {
                JObject xpctJSON = JObject.Parse(File.ReadAllText(@"../../../../expected-output.json"));
                JObject actJSON = JObject.Parse(File.ReadAllText(@"../../../../obtained_output.json"));
                right = JToken.DeepEquals(xpctJSON, actJSON);
                Assert.True(right);
            }
            else
            {
                throw new FileNotFoundException(string.Format("Cannot find the file expected-output.json"));
            }

        }
        
        [Fact]
        public void Test2()
        {
            if (!File.Exists("../../../../obtained_output.json"))
            {
                throw new FileNotFoundException(string.Format("Cannot find the file obtained-output.json"));
            }
            if (!File.Exists("../../../../expected-output.json"))
            {
                throw new FileNotFoundException(string.Format("Cannot find the file expected-output.json"));
            }
            if (!File.Exists("../../../../datafile.csv"))
            {
                throw new FileNotFoundException(string.Format("Cannot find the file datafile.csv"));
            }
        }
        [Fact]
        public void Test3()
        {
            bool flag = true;
            if (new FileInfo("../../../../obtained_output.json").Length == 0)
            {
                flag = false;
            }
            Assert.True(flag);
        }
    }
}