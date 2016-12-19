using System;
using FranceVacances.Models;
using FranceVacances.ModelView;
using FranceVacances.Views;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Collections.Generic;

namespace FranceVacationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        User user;
        User userA;
        RentalModel offer;
        int customer;

        [TestMethod]
        public void TestMethod1()
        {


        }
        [TestInitialize]
        public void TestBefore()
        {
            offer = new RentalModel { id = 1, Name = "Palace NoName", Country = "Britain", Price = 100.42, Bookings = 32, Rooms = 32, Season = "Winter", Address = new List<string>() { "Denmark", "Susnet Boulevard", "Number96" }, Description = "Just testing", ImagePaths = new List<string>() { "http://www.w3schools.com/css/trolltunga.jpg" }, Tags = new List<string>() { "stone", "fireplace", "exotic" }, ThumbnailPath = "http://www.w3schools.com/css/trolltunga.jpg" };
            user = new User { Name = "adi97ida", Email = "adi97ida@gmail.com", Password = "test", PhoneNumber = "71619045", ToPay = 1232.323, DateOfBirth = new DateTime(1997,08,12),BoughtOffers=new ObservableCollection<RentalModel>() };
        }
        [TestMethod]
        public void TestOfferPrice()
        {
            try
            {
                Assert.ThrowsException<ArgumentException>(() => offer.Price = 100.42);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(100.42, offer.Price);
            }
        }

        [TestMethod]
        public void TestAddCustomerMethod()
        {
            try
            {
                Book bookingpage = new Book();
                int user_test = bookingpage.CreateAccount("usernametest", "passwordtest", "passwordtest", "test@testdomain.com", "71907323",new DateTime(1997,08,12));
            }
            catch (Exception ex)
            {
                Assert.AreEqual("test@testdomain.com", userA.Email);
            }
        }
        [TestMethod]
        public void TestAddCustomerMethodNullOrWhiteSpace()
        {
            string n = "username1";
            string s = "passwordcheck1";
            string s1 = "passwordcheck1";
            string e = "test@testin.test";
            string pb = "34234433";
            DateTime pm = new DateTime(2090,02,21);
            try
            {
                Book pagetest = new Book();
                if ((!string.IsNullOrWhiteSpace(n) && !string.IsNullOrWhiteSpace(s) &&
                !string.IsNullOrWhiteSpace(s1) && !string.IsNullOrWhiteSpace(e) && !string.IsNullOrWhiteSpace(pb) && (DateTime.Now < pm))==true)
                {
                    customer = pagetest.CreateAccount(n, s, s1, e, pb, pm);
                    Assert.Fail();
                }
            }
            catch (Exception ex)
            {
                Assert.AreEqual(null, customer);
            }
        }

    }
}
