using System.Reflection;
using BankSystem.DAL.Entities;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace BankSystem.Tests.Models;

[TestFixture]
public class CurrencyCodeTests : ModelTestBase<CurrencyCode>
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
        ClassicAssert.AreEqual(3, this.ClassType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Length, "Checking fields number");

        ClassicAssert.AreEqual(0, this.ClassType.GetConstructors(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length, "Checking constructor number");
        ClassicAssert.AreEqual(1, this.ClassType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length, "Checking constructor number");
        ClassicAssert.AreEqual(0, this.ClassType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Length, "Checking constructor number");

        ClassicAssert.AreEqual(0, this.ClassType.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length, "Checking properties number");
        ClassicAssert.AreEqual(3, this.ClassType.GetProperties(BindingFlags.Instance | BindingFlags.Public).Length, "Checking properties number");
        ClassicAssert.AreEqual(0, this.ClassType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic).Length, "Checking properties number");

        ClassicAssert.AreEqual(0, this.ClassType.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly).Length, "Checking methods number");
        ClassicAssert.AreEqual(0, this.ClassType.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length, "Checking methods number");

        ClassicAssert.AreEqual(6, this.ClassType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Length, "Checking methods number");
        ClassicAssert.AreEqual(0, this.ClassType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length, "Checking methods number");

        ClassicAssert.AreEqual(0, this.ClassType.GetEvents(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Length, "Checking events number");
    }

    [TestCase("currency_code")]
    public void HasTableAttribute(string tableName)
    {
        this.AssertThatHasTableAttribute(tableName);
    }

    [TestCase("Id", typeof(int), "currency_code_id")]
    [TestCase("CurrenciesCode", typeof(string), "currency_code")]
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
