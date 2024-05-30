using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace BankSystem.Tests.Models;

[TestFixture]
public class AccountOwnerTests : ModelTestBase<DAL.Entities.AccountOwner>
{
    [Test]
    public void IsPublicClass()
    {
        this.AssertThatClassIsPublic(false);
    }

    [Test]
    public void InheritsObject()
    {
        this.AssertThatClassInheritsObject();
    }

    [Test]
    public void HasRequiredMembers()
    {
        ClassicAssert.AreEqual(0, this.ClassType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length, "Checking fields number");
        ClassicAssert.AreEqual(0, this.ClassType.GetFields(BindingFlags.Instance | BindingFlags.Public).Length, "Checking fields number");
        ClassicAssert.AreEqual(5, this.ClassType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Length, "Checking fields number");

        ClassicAssert.AreEqual(0, this.ClassType.GetConstructors(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length, "Checking constructor number");
        ClassicAssert.AreEqual(1, this.ClassType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length, "Checking constructor number");
        ClassicAssert.AreEqual(0, this.ClassType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Length, "Checking constructor number");

        ClassicAssert.AreEqual(0, this.ClassType.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length, "Checking properties number");
        ClassicAssert.AreEqual(5, this.ClassType.GetProperties(BindingFlags.Instance | BindingFlags.Public).Length, "Checking properties number");
        ClassicAssert.AreEqual(0, this.ClassType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic).Length, "Checking properties number");

        ClassicAssert.AreEqual(0, this.ClassType.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly).Length, "Checking methods number");
        ClassicAssert.AreEqual(0, this.ClassType.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length, "Checking methods number");

        ClassicAssert.AreEqual(10, this.ClassType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Length, "Checking methods number");
        ClassicAssert.AreEqual(0, this.ClassType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length, "Checking methods number");

        ClassicAssert.AreEqual(0, this.ClassType.GetEvents(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Length, "Checking events number");
    }

    [TestCase("account_owner")]
    public void HasTableAttribute(string tableName)
    {
        this.AssertThatHasTableAttribute(tableName);
    }

    [TestCase("Id", typeof(int), "account_owner_id")]
    [TestCase("FirstName", typeof(string), "first_name")]
    [TestCase("LastName", typeof(string), "last_name")]
    [TestCase("Email", typeof(string), "email")]
    public void HasProperty(string propertyName, Type propertyType, string columnName)
    {
        _ = this.AssertThatClassHasProperty(propertyName, propertyType, columnName);
    }

    [TestCase("Id")]
    public void HasKeyAttribute(string propertyName)
    {
        this.AssertThatPropertyHasKeyAttribute(propertyName);
    }
}
