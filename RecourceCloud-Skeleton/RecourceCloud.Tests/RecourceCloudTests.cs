using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RecourceCloud.Tests
{
    public class RecourceCloudTests
    {
        [SetUp]
        public void Setup()
        {

        }

        public static IEnumerable<string[]> StringArrayTestCases()
        {
            yield return new[] { "1", "a" };
            yield return new[] { "2", "a", "b", "c" };
            yield return new[] { "3" };
        }

        [TestCaseSource(nameof(StringArrayTestCases))]
        public void LogTask_ThrowsException_WhenArgumentsNot3(string[] inputArray)
        {
            DepartmentCloud cloud = new DepartmentCloud();

            Assert.That(
                () => cloud.LogTask(inputArray),
                Throws.ArgumentException
            );
        }


        [TestCase(null, "2", "3")]
        [TestCase("1", null, "3")]
        [TestCase("1", "2", null)]
        public void LogTask_ThrowsException_WhenArgumentNull(params string[] args)
        {
            DepartmentCloud cloud = new DepartmentCloud();

            Assert.That(
                () => cloud.LogTask(args),
                Throws.ArgumentException
            );
        }


        [TestCase("1", "a", "b")]
        public void LogTask_Duplicate_ReturnAppropriateMessage(params string[] args)
        {
            DepartmentCloud cloud = new DepartmentCloud();

            cloud.LogTask(args);

            string result = cloud.LogTask(args);

            Assert.AreEqual("b is already logged.", result);
            Assert.AreEqual(1, cloud.Tasks.Count);
        }

        [TestCase("1", "a", "b")]
        public void LogTask_Succeeds(params string[] args)
        {
            DepartmentCloud cloud = new DepartmentCloud();

            string result = cloud.LogTask(args);

            Assert.AreEqual("Task logged successfully.", result);
            Assert.AreEqual(1, cloud.Tasks.Count);
        }




        [Test]
        public void CreateResource_ReturnsFalse_WhenNoTask()
        {
            DepartmentCloud cloud = new DepartmentCloud();

            bool result = cloud.CreateResource();

            Assert.AreEqual(false, result);
            Assert.AreEqual(0, cloud.Tasks.Count);
        }

        [Test]
        public void CreateResource_ReturnsTrue_WhenResourceCreatedWithPriorityTask()
        {
            DepartmentCloud cloud = new DepartmentCloud();

            string[] args = new[] { "1", "a", "b" };

            cloud.LogTask(args);

            bool result = cloud.CreateResource();

            Assert.AreEqual(true, result);
            Assert.AreEqual(0, cloud.Tasks.Count);
            Assert.AreEqual(1, cloud.Resources.Count);
        }





        [Test]
        public void TestResource_ReturnsNull_WhenNoResourceWithName()
        {
            DepartmentCloud cloud = new DepartmentCloud();

            Resource? result = cloud.TestResource("res-name");

            Assert.AreEqual(null, result);
            Assert.AreEqual(0, cloud.Resources.Count);
        }

        [Test]
        public void TestResource_ReturnsResource_WhenResourceWithName()
        {
            DepartmentCloud cloud = new DepartmentCloud();

            string[] args = new[] { "1", "a", "res-name" };

            cloud.LogTask(args);

            cloud.CreateResource();

            Resource? result = cloud.TestResource("res-name");

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(0, cloud.Tasks.Count);
            Assert.AreEqual(1, cloud.Resources.Count);
        }





        [Test]
        public void Constructor_CreatesDepartmentCloudAndFields()
        {
            DepartmentCloud cloud = new DepartmentCloud();

            Assert.AreNotEqual(null, cloud);
            Assert.AreNotEqual(null, cloud.Tasks);
            Assert.AreNotEqual(null, cloud.Resources);
        }





        [Test]
        public void TasksField_Valid()
        {
            DepartmentCloud cloud = new DepartmentCloud();

            cloud.Tasks.

            Assert.AreNotEqual(null, cloud);
            Assert.AreNotEqual(null, cloud.Tasks);
            Assert.AreNotEqual(null, cloud.Resources);
        }





    }
}