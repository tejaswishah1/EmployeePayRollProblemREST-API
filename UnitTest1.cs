using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

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
        //[TestMethod]
        //public void onCallingGETApi_ReturnEmployeeList()
        //{
        //    IRestResponse response = getEmployeeList();

        //    //assert
        //    Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        //    List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
        //    Assert.AreEqual(10, dataResponse.Count);
        //    foreach (var item in dataResponse)
        //    {
        //        System.Console.WriteLine("id: " + item.id + "Name: " + item.name + "Salary: " + item.Salary);
        //    }
        //}


        ////UC2: Add data
        //[TestMethod]

        //public void givenEmployee_OnPost_ShouldReturnAddedEmployee()
        //{
        //    ////Arrange
        //    ///Request to add data using :POST
        //    RestRequest request = new RestRequest("/employees", Method.POST);

        //    ////Instantiate object to add data
        //    JObject jObjectbody = new JObject();
        //    jObjectbody.Add("name", "James");
        //    jObjectbody.Add("Salary", "15000");

        //    ////The request body is used to send and receive data via the REST API.
        //    request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

        //    //act
        //    ////Request will contain data for James Only, Data added to JSON.
        //    IRestResponse response = client.Execute(request);

        //    ///Assert
        //    Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
        //    ////Deserialization and checking test case
        //    Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
        //    ////Check if Name Matches
        //    Assert.AreEqual("James", dataResponse.name);
        //    ////Check if Salary Matches
        //    Assert.AreEqual(15000, dataResponse.Salary);
        //    Console.WriteLine(response.Content);

        //}


        /// <summary>
        /// UC3
        /// Tests the add multiple entries. POST
        /// </summary>
        //[TestMethod]
        //public void TestAddMultipleEntriesUsingPostOperation()
        //{
        //   ////Add multiple entries
        //   ////Created a list
        //    List<Employee> employeeList = new List<Employee>();
        //    employeeList.Add(new Employee { name = "Girish", Salary = "40000" });
        //    employeeList.Add(new Employee { name = "Harsh", Salary = "50000" });

        //    foreach (Employee employee in employeeList)
        //    {
        //        ////Used post method to add Data.
        //        ////"/employees" will append to the url
        //        RestRequest request = new RestRequest("/employees", Method.POST);
        //        JObject jObject = new JObject();
        //        jObject.Add("name", employee.name);
        //        jObject.Add("salary", employee.Salary);
        //        request.AddParameter("application/json", jObject, ParameterType.RequestBody);
        //        IRestResponse response = client.Execute(request);
        //        //Assert
        //        Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
        //        //derserializing object for assert and checking test case
        //        Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
        //        Assert.AreEqual(employee.name, dataResponse.name);
        //    }
        //}


        /// <summary>
        /// UC4
        ////Update salary using PUT operation
        /// </summary>
        //[TestMethod]
        //public void TestUpdateDataUsingPutOperation()
        //{
        //    ////Request to update data of an employee 3.
        //    ///ID 3: Tejaswi
        //    RestRequest request = new RestRequest("employees/3", Method.PUT);
        //   ////Creating object to update data
        //    JObject jobject = new JObject();
        //    ////Updating Salary
        //    jobject.Add("name", "Tejaswi");
        //    jobject.Add("salary", "300000");
        //    ////Adding parameters in request
        //    request.AddParameter("application/json", jobject, ParameterType.RequestBody);
        //    ////IRest response act as a container for the data sent back from api.
        //    ///Act
        //    IRestResponse response = client.Execute(request);
        //    ////Assert
        //    Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        //    //deserializing content added in json file
        //    Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
        //    //asserting for salary
        //    Assert.AreEqual(dataResponse.Salary, "300000");
        //}

        /// <summary>
        /// UC5
        /// Tests the delete operation.
        /// </summary>
        [TestMethod]
        public void TestDeleteDataUsingDeleteOperation()
        {
            ////Arrange
            ////Employee with ID 3 will be deleted
            ///Delete command used
            RestRequest request = new RestRequest("employees/3", Method.DELETE);
            //Act
            IRestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

    } 
}
