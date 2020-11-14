using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;

namespace RestSharpTest
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]

        ////setup url
        public void Setup()
        {
            client = new RestClient("http://localhost:3000"); ////Home URL
        }
        private IRestResponse getEmployeeList()
        {
            RestRequest request = new RestRequest("/employees", Method.GET); ////Appends to url.

            //act
            IRestResponse response = client.Execute(request);
            return response;
        }

        /// <summary>
        /// UC1: Retrieve data from JSON server
        /// </summary>
        [TestMethod]
        public void onCallingGETApi_ReturnEmployeeList()
        {
            IRestResponse response = getEmployeeList();

            //assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(10, dataResponse.Count);
            foreach (var item in dataResponse)
            {
                System.Console.WriteLine("id: " + item.id + "Name: " + item.name + "Salary: " + item.Salary);
            }
        }


        //[TestMethod]
        //public void givenEmployee_OnPost_ShouldReturnAddedEmployee()
        //{
        //    RestRequest request = new RestRequest("/employees", Method.POST);
        //    JObject jObjectbody = new JObject();
        //    jObjectbody.Add("name", "Clark");
        //    jObjectbody.Add("Salary", "15000");
        //    request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

        //    //act
        //    IRestResponse response = client.Execute(request);
        //    Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
        //    Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
        //    Assert.AreEqual("Clark", dataResponse.name);
        //    Assert.AreEqual(15000, dataResponse.Salary);

        //}


    
    } 
}
