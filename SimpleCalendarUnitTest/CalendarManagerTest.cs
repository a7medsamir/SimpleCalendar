using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalendarDataAccess;
namespace SimpleCalendarUnitTest
{
    [TestClass]
    public class CalendarManagerTest
    {
        [TestMethod]
        public void TestGetAppointments()
        {
            CalendarManager calendarManager = new CalendarManager();
            var actualListAppointments = calendarManager.GetAppointments();
            int expectesAppointmentsCount = 3;
            Assert.AreEqual(expectesAppointmentsCount, actualListAppointments.Count);
        }

        [TestMethod]
        public void TestGetAppointment()
        {
            string expectedDescription = "Team Meeting";
            string expectedOrganizer = "Team Leader";

            CalendarManager calendarManager = new CalendarManager();
            int validId = 1;
            var actualAppointment = calendarManager.GetAppointment(validId);
           
            Assert.AreEqual(expectedDescription, actualAppointment.Description);
            Assert.AreEqual(expectedOrganizer, actualAppointment.Organizer);
        }

        [TestMethod]
        public void TestGetInvalidAppointment()
        {
            CalendarManager calendarManager = new CalendarManager();
            int invaldId = 100;
            var actualAppointment = calendarManager.GetAppointment(invaldId);
            Assert.IsNull(actualAppointment);
        }
        [TestMethod]
        public void TestGetMonthAppointments()
        {
            CalendarManager calendarManager = new CalendarManager();
            int validMonthHaveData = 2;
            var actualListAppointments = calendarManager.GetMonthAppointments(validMonthHaveData);
            int expectesAppointments = 3;
            Assert.AreEqual(expectesAppointments, actualListAppointments.Count);

        }
        [TestMethod]
        public void TestGetEmptyMonthAppointments()
        {
            CalendarManager calendarManager = new CalendarManager();
            int invalidMonthNotHaveData = 1;
            var actualListAppointments = calendarManager.GetMonthAppointments(1);
            int expectesAppointments = 0;
            Assert.AreEqual(expectesAppointments, actualListAppointments.Count);

        }
    }
}
