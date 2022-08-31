using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassWork
{
    class FirstLesson
    {
        [Test]
        public static void TestIf4IsEven()
        {
            int leftOver = 4 % 2;
            Assert.AreEqual(0, leftOver, "4 is not even.");
            Assert.IsTrue(leftOver.Equals(0), "4 is not even.");
        }

        [Test]
        public static void TestNowIs19()
        {
            DateTime currentTime = DateTime.Now;
            Assert.AreEqual(19, currentTime.Hour, "Now is not 19");
        }

        [Test]
        public static void Test995DivideBy3()
        {
            double leftover = 995 % 3;
            Assert.AreEqual(0, leftover.Equals(0), "Divides by 3");
        }

        [Test]
        public static void TestIfTodayIsFriday()
        {
            DateTime currentTime = DateTime.Now;
            Assert.AreEqual(DayOfWeek.Friday, currentTime.DayOfWeek, "Today is not Friday.");
        }

        [Test]
        public static void TestWait()
        {
            Thread.Sleep(2000);
        }

            /*
            Testas 1 --> “žalias” jeigu 995 dalijasi iš 3 (be liekanos)
            Testas 2 --> “žalias” jeigu šiandien penktadienis(DayOfWeek.Friday)
            Testas 3 --> “žalias” po to kai “palaukia” 5 sekundes
            */

        }
    }
