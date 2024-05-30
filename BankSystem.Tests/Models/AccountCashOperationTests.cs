using System.Reflection;
using BankSystem.DAL.Entities;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace BankSystem.Tests.Models;

[TestFixture]
public class AccountCashOperationTests : ModelTestBase<DAL.Entities.AccountCashOperation>
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

        Console.WriteLine(this.ClassType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic));

        ClassicAssert.AreEqual(0, this.ClassType.GetConstructors(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length, "Checking constructor number");
        ClassicAssert.AreEqual(1, this.ClassType.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length, "Checking constructor number");
        ClassicAssert.AreEqual(0, this.ClassType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).Length, "Checking constructor number");


        Console.WriteLine(this.ClassType.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic));
        ClassicAssert.AreEqual(0, this.ClassType.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Length, "Checking properties number");
        ClassicAssert.AreEqual(6, this.ClassType.GetProperties(BindingFlags.Instance | BindingFlags.Public).Length, "Checking properties number");
        ClassicAssert.AreEqual(0, this.ClassType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic).Length, "Checking properties number");

        ClassicAssert.AreEqual(0, this.ClassType.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly).Length, "Checking methods number");
        ClassicAssert.AreEqual(0, this.ClassType.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length, "Checking methods number");

        ClassicAssert.AreEqual(12, this.ClassType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly).Length, "Checking methods number");
        ClassicAssert.AreEqual(0, this.ClassType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).Length, "Checking methods number");

        ClassicAssert.AreEqual(0, this.ClassType.GetEvents(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Length, "Checking events number");
    }

    [TestCase("account_cash_operation")]
    public void HasTableAttribute(string tableName)
    {
        this.AssertThatHasTableAttribute(tableName);
    }

    [TestCase("Id", typeof(int), "account_cash_operation_id")]
    [TestCase("BankAccountId", typeof(int), "bank_account_id")]
    [TestCase("Amount", typeof(decimal), "amount")]
    [TestCase("OperationDateTime", typeof(string), "operation_date_time")]
    [TestCase("Note", typeof(string), "note")]
    [TestCase("BankAccount", typeof(BankAccount), null)]
    public void HasProperty(string propertyName, Type propertyType, string columnName)
    {
        _ = this.AssertThatClassHasProperty(propertyName, propertyType, columnName);
    }

    [TestCase("Id")]
    public void HasKeyAttribute(string propertyName)
    {
        this.AssertThatPropertyHasKeyAttribute(propertyName);
    }

    [TestCase("BankAccountId", "BankAccount")]
    public void HasForeignKeyAttribute(string propertyName, string navigationPropertyName)
    {
        this.AssertThatPropertyHasForeignKeyAttribute(propertyName, navigationPropertyName);
    }
}
