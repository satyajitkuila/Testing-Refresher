using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSeleniumFramework.Utilities
{
    public class jsonReader
    {
        public jsonReader()
        {

        }

        public string extractData(String tokenName)
        {
            var myJsonString=File.ReadAllText("Utilities/TestData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<String>();

        }
        public string[] extractDataArray(String tokenName)
        {
            String myJsonString=File.ReadAllText("Utilities/TestData.json");
            var jsonObject = JToken.Parse(myJsonString);
            List<String> productList = jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return productList.ToArray();

        }
    }
}
