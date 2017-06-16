using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Net;

namespace SeleniumTestProject
{
    //Installation can be taken from http://www.c-sharpcorner.com/article/selenium-automation-test-cases-for-the-net-web-application/
    [TestClass]
    public class E2E_Test
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private string stringValueWhereShouldBeInt;
        private List<string> jsonIdsForWrongPage;
        private string nonExistantId;

        [TestInitialize]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost:14243";
            verificationErrors = new StringBuilder();
            nonExistantId = "999999999";
            stringValueWhereShouldBeInt = "stringValueWhereShouldBeInt";
            jsonIdsForWrongPage = new List<string>(new string[] {"$id", "message", "messageDetail" });
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        #region HelperMethods 
        public void CheckGetAllPage(string subPage, List<string> jsonIds)
        {
            driver.Navigate().GoToUrl(baseURL + subPage);
            for (int i = 0; i < jsonIds.Count; i++)
            {
                //Thread.Sleep(500);

                Assert.IsTrue(driver.PageSource.Contains(jsonIds[i]), "'{0}' should exist on the '{1}'", jsonIds[i], subPage);
            }
        }

        public void ShouldThrowA404(string subPage)
        {
            HttpWebRequest task; //For Calling the page
            HttpWebResponse taskresponse = null; //Response returned
            task = (HttpWebRequest)WebRequest.Create(baseURL + subPage);
            taskresponse = (HttpWebResponse)task.GetResponse();
        }
        #endregion

        #region Tests Error Handling Common
        [TestMethod]
        public void GetNotExistedPage()
        {
            string wrongPageName = "wrongPageName123";
            string subPage = "/api/" + wrongPageName;
            string pageToOpen = baseURL + subPage;
            List<string> jsonIds = new List<string>(
                new string[] {
                     "$id", "message", "messageDetail",
                    wrongPageName, pageToOpen });

            CheckGetAllPage(subPage, jsonIds);
        }
        #endregion

        #region Tests GetAll
        [TestMethod]
        public void GetAllProducts()
        {
            List<string> jsonIds = new List<string>(
                new string[] {
                    "$id", "productId", "productName",
                    "productCode", "productCategory" });

            CheckGetAllPage("/api/products", jsonIds);
        }

        [TestMethod]
        public void GetAllReplies()
        {
            List<string> jsonIds = new List<string>(
                new string[] {
                    "$id", "replyId", "replyDtime", "replyText",
                    "userId", "ticketId", "replyIdentifier" });

            CheckGetAllPage("/api/replies", jsonIds);
        }

        [TestMethod]
        public void GetAllRolePermitions()
        {
            List<string> jsonIds = new List<string>(
                new string[] {
                    "$id", "rolePermissionId", "userRole", "permission" });

            CheckGetAllPage("/api/rolepermissions", jsonIds);
        }

        [TestMethod]
        public void GetAllTicketHistory()
        {
            List<string> jsonIds = new List<string>(
                new string[] {
                    "$id", "ticketHistoryId", "ticketHisDtime", "ticketId",
                    "userId", "ticketStatusCode" });

            CheckGetAllPage("/api/tickethistory", jsonIds);
        }

        [TestMethod]
        public void GetAllTickets()
        {
            List<string> jsonIds = new List<string>(
                new string[] {
                    "$id", "ticketId", "reportedDtime", "description",
                    "userId", "agentId", "productId","ticketPriority" });

            CheckGetAllPage("/api/tickets", jsonIds);
        }

        [TestMethod]
        public void GetAllUsers()
        {
            List<string> jsonIds = new List<string>(
                new string[] {
                    "$id", "userId", "firstName", "lastName",
                    "userEmail", "userRole", "ticketsCreatedCount",
                    "ticketsAssignedCount" });

            CheckGetAllPage("/api/users", jsonIds);
        }
        #endregion

        #region Tests GetFirst
        [TestMethod]
        public void GetFirstFromProducts()
        {
            List<string> jsonIds = new List<string>(
                new string[] {
                    "$id", "productId", "productName",
                    "productCode", "productCategory" });

            CheckGetAllPage("/api/products/1", jsonIds);
        }

        [TestMethod]
        public void GetFirstFromReplies()
        {
            List<string> jsonIds = new List<string>(
                new string[] {
                    "$id", "replyId", "replyDtime", "replyText",
                    "userId", "ticketId", "replyIdentifier" });

            CheckGetAllPage("/api/replies/1", jsonIds);
        }

        [TestMethod]
        public void GetFirstFromRolePermitions()
        {
            List<string> jsonIds = new List<string>(
                new string[] {
                    "$id", "rolePermissionId", "userRole", "permission" });

            CheckGetAllPage("/api/rolepermissions/1", jsonIds);
        }

        [TestMethod]
        public void GetFirstFromTicketHistory()
        {
            List<string> jsonIds = new List<string>(
                new string[] {
                    "$id", "ticketHistoryId", "ticketHisDtime", "ticketId",
                    "userId", "ticketStatusCode" });

            CheckGetAllPage("/api/tickethistory/1", jsonIds);
        }

        [TestMethod]
        public void GetFirstFromTickets()
        {
            List<string> jsonIds = new List<string>(
                new string[] {
                    "$id", "ticketId", "reportedDtime", "description",
                    "userId", "agentId", "productId","ticketPriority" });

            CheckGetAllPage("/api/tickets/1", jsonIds);
        }

        [TestMethod]
        public void GetFirstFromUsers()
        {
            List<string> jsonIds = new List<string>(
                new string[] {
                    "$id", "userId", "firstName", "lastName",
                    "userEmail", "userRole", "ticketsCreatedCount",
                    "ticketsAssignedCount" });

            CheckGetAllPage("/api/users/1", jsonIds);
        }
        #endregion

        #region Tests Error Handling GetNonIntValue
        [TestMethod]
        public void GetNonIntValueFromProducts()
        {
            CheckGetAllPage("/api/products/" + stringValueWhereShouldBeInt, jsonIdsForWrongPage);
        }

        [TestMethod]
        public void GetNonIntValueFromReplies()
        {
            CheckGetAllPage("/api/replies/" + stringValueWhereShouldBeInt, jsonIdsForWrongPage);
        }

        [TestMethod]
        public void GetNonIntValueFromRolePermitions()
        {
            CheckGetAllPage("/api/rolepermissions/" + stringValueWhereShouldBeInt, jsonIdsForWrongPage);
        }

        [TestMethod]
        public void GetNonIntValueFromTicketHistory()
        {
            CheckGetAllPage("/api/tickethistory/" + stringValueWhereShouldBeInt, jsonIdsForWrongPage);
        }

        [TestMethod]
        public void GetNonIntValueFromTickets()
        {
            CheckGetAllPage("/api/tickets/" + stringValueWhereShouldBeInt, jsonIdsForWrongPage);
        }

        [TestMethod]
        public void GetNonIntValueFromUsers()
        {
            CheckGetAllPage("/api/users/" + stringValueWhereShouldBeInt, jsonIdsForWrongPage);
        }
        #endregion

        #region Tests Error Handling NonNonExistant
        [TestMethod]
        [ExpectedException(typeof(WebException), "The remote server returned an error: (404) Not Found")]
        public void GetNonNonExistantFromProducts()
        {
            ShouldThrowA404("/api/products/" + nonExistantId);
        }

        [TestMethod]
        [ExpectedException(typeof(WebException), "The remote server returned an error: (404) Not Found")]
        public void GetNonNonExistantFromReplies()
        {
            ShouldThrowA404("/api/replies/" + nonExistantId);
        }

        [TestMethod]
        [ExpectedException(typeof(WebException), "The remote server returned an error: (404) Not Found")]
        public void GetNonNonExistantFromRolePermitions()
        {
            ShouldThrowA404("/api/rolepermissions/" + nonExistantId);
        }

        [TestMethod]
        [ExpectedException(typeof(WebException), "The remote server returned an error: (404) Not Found")]
        public void GetNonNonExistantFromTicketHistory()
        {
            ShouldThrowA404("/api/tickethistory/" + nonExistantId);
        }

        [TestMethod]
        [ExpectedException(typeof(WebException), "The remote server returned an error: (404) Not Found")]
        public void GetNonNonExistantFromTickets()
        {
            ShouldThrowA404("/api/tickets/" + nonExistantId);
        }

        [TestMethod]
        [ExpectedException(typeof(WebException), "The remote server returned an error: (404) Not Found")]
        public void GetNonNonExistantFromUsers()
        {
            ShouldThrowA404("/api/users/" + nonExistantId);
        }
        #endregion
    }
}
