using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace ZoneControlPanel.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Assert.Pass();
        }

        [Test]
        public void AddEmployee_ReturnsAdding_WhenFullNameNew()
        {
            string[] zoneNames = new string[] { "zone_one" };

            ControlPanel controlPanel = new ControlPanel(zoneNames);

            Employee employee = new Employee("some name", "some position", 0);

            controlPanel.AddEmployee(employee);

            Assert.AreEqual(1, controlPanel.Employees.Count);
        }

        [Test]
        public void AddEmployee_ReturnsWithNoAdding_WhenFullNameExists()
        {
            string[] zoneNames = new string[] { "zone_one" };

            ControlPanel controlPanel = new ControlPanel(zoneNames);

            Employee employee = new Employee("some name", "some position", 0);

            controlPanel.AddEmployee(employee);
            controlPanel.AddEmployee(employee);

            Assert.AreEqual(1, controlPanel.Employees.Count);
        }




        [Test]
        public void AuthorizeEmployee_ReturnsFalse_WhenEmployeeNull()
        {
            string[] zoneNames = new string[] { "some zone" };

            ControlPanel controlPanel = new ControlPanel(zoneNames);

            Employee employee = new Employee("some name", "some position", 0);


            controlPanel.AddEmployee(employee);

            bool result = controlPanel.AuthorizeEmployee("someone else", zoneNames[0]);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void AuthorizeEmployee_ReturnsFalse_WhenZoneNull()
        {
            string[] zoneNames = new string[] { "some zone" };

            ControlPanel controlPanel = new ControlPanel(zoneNames);

            Employee employee = new Employee("some name", "some position", 0);


            controlPanel.AddEmployee(employee);

            bool result = controlPanel.AuthorizeEmployee("some name", "another zone");

            Assert.AreEqual(false, result);
        }

        [Test]
        public void AuthorizeEmployee_ThrowsInvalidOperationException_WhenStampExists()
        {
            string[] zoneNames = new string[] { "some zone" };
            ControlPanel controlPanel = new ControlPanel(zoneNames);

            Employee employee = new Employee("some name", "some position", 0);
            controlPanel.AddEmployee(employee);

            controlPanel.SecureZones.ElementAt(0).GrantAccess(employee);


            Assert.That(
                () => controlPanel.AuthorizeEmployee("some name", "some zone"),
                Throws.InvalidOperationException
            );

        }

        [Test]
        public void AuthorizeEmployee_Succeeds()
        {
            string[] zoneNames = new string[] { "some zone" };
            ControlPanel controlPanel = new ControlPanel(zoneNames);

            Employee employee = new Employee("some name", "some position", 0);
            controlPanel.AddEmployee(employee);

            bool result = controlPanel.AuthorizeEmployee("some name", "some zone");

            Assert.AreEqual(true, controlPanel.SecureZones.ElementAt(0).AccessLog.Contains(employee.AccessStamp));
            Assert.AreEqual(true, result);
        }





        [Test]
        public void SecureZonesStatus_ReturnsNotFound_WhenNull()
        {
            string[] zoneNames = new string[] { "some zone" };
            ControlPanel controlPanel = new ControlPanel(zoneNames);

            string result = controlPanel.SecureZonesStatus("some other zone");

            Assert.AreEqual("Secure zone not found", result);
        }

        [Test]
        public void SecureZonesStatus_EmployeeAddedToStatus_WhenEmployeeNotNull()
        {
            string[] zoneNames = new string[] { "some zone" };
            ControlPanel controlPanel = new ControlPanel(zoneNames);

            Employee employee = new Employee("some name", "some position", 0);
            controlPanel.AddEmployee(employee);

            controlPanel.SecureZones.ElementAt(0).GrantAccess(employee);


            string result = controlPanel.SecureZonesStatus("some zone");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Secure zone: some zone");
            sb.AppendLine("Access log:");
            sb.Append("0 - (some position: some name)");

            string expected = sb.ToString();

            Assert.AreNotEqual("Secure zone not found", result);
            Assert.AreEqual(expected, result);
        }









    }
}