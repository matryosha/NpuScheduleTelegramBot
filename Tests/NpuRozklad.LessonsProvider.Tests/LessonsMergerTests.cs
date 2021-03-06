using System.Collections.Generic;
using System.Linq;
using NpuRozklad.Core.Entities;
using NpuRozklad.LessonsProvider.Entities;
using NUnit.Framework;

namespace NpuRozklad.LessonsProvider.Tests
{
    public class LessonsMergerTests
    {
        [Test]
        public void ReplaceLessonTest()
        {
            var newLesson = new ExtendedLesson() { Subject = new Subject("new") };
            var oldLesson = new ExtendedLesson() { Subject = new Subject("old") };
            var list = new List<ExtendedLesson>();

            list.Add(oldLesson);
            LessonsMerger.ReplaceLesson(list, newLesson, oldLesson);

            Assert.AreEqual("new", list[0].Subject.Name);
        }

        [Test]
        public void MergeLessonsList_AllFractionTest()
        {
            //arrange
            var resultLessonsList = new List<ExtendedLesson>();
            var newLessonsList = new List<ExtendedLesson>();
            var oldLessonFractionNone = new ExtendedLesson()
            {
                Subject = new Subject("old"),
                Fraction = Fraction.None,
                LessonNumber = 1
            };
            var newLessonFractionNone = new ExtendedLesson()
            {
                Subject = new Subject("new"),
                Fraction = Fraction.None,
                LessonNumber = 1
            };

            resultLessonsList.Add(oldLessonFractionNone);
            newLessonsList.Add(newLessonFractionNone);

            //act
            LessonsMerger.MergeLessonsList(resultLessonsList, newLessonsList);

            //assert

            Assert.AreEqual("new", resultLessonsList[0].Subject.Name);
        }

        [Test]
        public void MergeLessonsList_OldDenominator_NewNoneTest()
        {
            //arrange
            var resultLessonsList = new List<ExtendedLesson>();
            var newLessonsList = new List<ExtendedLesson>();
            var oldLessonFractionDenominator = new ExtendedLesson()
            {
                Subject = new Subject("old"),
                Fraction = Fraction.Denominator,
                LessonNumber = 1
            };
            var newLessonFractionNone = new ExtendedLesson()
            {
                Subject = new Subject("new"),
                Fraction = Fraction.None,
                LessonNumber = 1
            };

            resultLessonsList.Add(oldLessonFractionDenominator);
            newLessonsList.Add(newLessonFractionNone);

            //act
            LessonsMerger.MergeLessonsList(resultLessonsList, newLessonsList);

            //assert

            Assert.AreEqual("new", resultLessonsList[0].Subject.Name);
        }

        [Test]
        public void MergeLessonsList_OldNumerator_NewNoneTest()
        {
            //arrange
            var resultLessonsList = new List<ExtendedLesson>();
            var newLessonsList = new List<ExtendedLesson>();
            var oldLessonFractionNumerator = new ExtendedLesson()
            {
                Subject = new Subject("old"),
                Fraction = Fraction.Numerator,
                LessonNumber = 1
            };
            var newLessonFractionNone = new ExtendedLesson()
            {
                Subject = new Subject("new"),
                Fraction = Fraction.None,
                LessonNumber = 1
            };

            resultLessonsList.Add(oldLessonFractionNumerator);
            newLessonsList.Add(newLessonFractionNone);

            //act
            LessonsMerger.MergeLessonsList(resultLessonsList, newLessonsList);

            //assert

            Assert.AreEqual("new", resultLessonsList[0].Subject.Name);
        }

        [Test]
        public void MergeLessonsList_OldSubGroup_NewNoneTest()
        {
            //arrange
            var resultLessonsList = new List<ExtendedLesson>();
            var newLessonsList = new List<ExtendedLesson>();
            var oldLessonFractionSubgroup = new ExtendedLesson()
            {
                Subject = new Subject("old"),
                SubGroup = SubGroup.First,
                LessonNumber = 1
            };
            var newLessonFractionNone = new ExtendedLesson()
            {
                Subject = new Subject("new"),
                SubGroup = SubGroup.None,
                LessonNumber = 1
            };

            resultLessonsList.Add(oldLessonFractionSubgroup);
            newLessonsList.Add(newLessonFractionNone);

            //act
            LessonsMerger.MergeLessonsList(resultLessonsList, newLessonsList);

            //assert

            Assert.AreEqual("new", resultLessonsList[0].Subject.Name);
        }

        [Test]
        public void MergeLessonsList_OldSubGroupFirst_NewSubgroupFirstTest()
        {
            //arrange
            var resultLessonsList = new List<ExtendedLesson>();
            var newLessonsList = new List<ExtendedLesson>();
            var oldLessonFractionSubgroup = new ExtendedLesson()
            {
                Subject = new Subject("old"),
                SubGroup = SubGroup.First,
                LessonNumber = 1
            };
            var newLessonFractionNone = new ExtendedLesson()
            {
                Subject = new Subject("new"),
                SubGroup = SubGroup.First,
                LessonNumber = 1
            };

            resultLessonsList.Add(oldLessonFractionSubgroup);
            newLessonsList.Add(newLessonFractionNone);

            //act
            LessonsMerger.MergeLessonsList(resultLessonsList, newLessonsList);

            //assert

            Assert.AreEqual("new", resultLessonsList[0].Subject.Name);
        }

        [Test]
        public void MergeLessonsList_OldSubGroupAndFractionSet_NewSubGroupAndFractionNoneTest()
        {
            //arrange
            var resultLessonsList = new List<ExtendedLesson>();
            var newLessonsList = new List<ExtendedLesson>();
            var oldLessonFractionSubgroup = new ExtendedLesson()
            {
                Subject = new Subject("old"),
                Fraction = Fraction.Numerator,
                SubGroup = SubGroup.First,
                LessonNumber = 1
            };
            var newLessonFractionNone = new ExtendedLesson()
            {
                Subject = new Subject("new"),
                Fraction = Fraction.None,
                SubGroup = SubGroup.None,
                LessonNumber = 1
            };

            resultLessonsList.Add(oldLessonFractionSubgroup);
            newLessonsList.Add(newLessonFractionNone);

            //act
            LessonsMerger.MergeLessonsList(resultLessonsList, newLessonsList);

            //assert

            Assert.AreEqual("new", resultLessonsList[0].Subject.Name);
        }

        [Test]
        public void MergeLessonsList_MultipleLessons_Test()
        {
            //arrange
            var resultLessonsList = new List<ExtendedLesson>();
            var newLessonsList = new List<ExtendedLesson>();
            var oldLesson1 = new ExtendedLesson()
            {
                Subject = new Subject("old1"),
                LessonNumber = 1
            };
            var oldLesson2 = new ExtendedLesson()
            {
                Subject = new Subject("old2"),
                LessonNumber = 2
            };
            var oldLesson3 = new ExtendedLesson()
            {
                Subject = new Subject("old3"),
                LessonNumber = 3
            };

            var newLesson1 = new ExtendedLesson()
            {
                Subject = new Subject("new1"),
                LessonNumber = 1
            };

            var newLesson3 = new ExtendedLesson()
            {
                Subject = new Subject("new3"),
                LessonNumber = 3
            };

            resultLessonsList.Add(oldLesson1);
            resultLessonsList.Add(oldLesson2);
            resultLessonsList.Add(oldLesson3);
            newLessonsList.Add(newLesson1);
            newLessonsList.Add(newLesson3);

            //act
            LessonsMerger.MergeLessonsList(resultLessonsList, newLessonsList);

            //assert
            var assert1 = resultLessonsList.Where(l => l.LessonNumber == 1).ToList();
            Assert.AreEqual(1, assert1.Count);
            Assert.AreEqual("new1", assert1[0].Subject.Name);

            var assert2 = resultLessonsList.Where(l => l.LessonNumber == 2).ToList();
            Assert.AreEqual(1, assert1.Count);
            Assert.AreEqual("old2", assert2[0].Subject.Name);

            var assert3 = resultLessonsList.Where(l => l.LessonNumber == 3).ToList();
            Assert.AreEqual(1, assert1.Count);
            Assert.AreEqual("new3", assert3[0].Subject.Name);

        }

        [Test]
        public void MergeLessonsList_MultipleLessonsFraction_Test()
        {
            //arrange
            var resultLessonsList = new List<ExtendedLesson>();
            var newLessonsList = new List<ExtendedLesson>();
            var oldLesson1 = new ExtendedLesson()
            {
                Subject = new Subject("old1_1"),
                Fraction = Fraction.Numerator,
                LessonNumber = 1
            };
            var oldLesson2 = new ExtendedLesson()
            {
                Subject = new Subject("old1_2"),
                Fraction = Fraction.Denominator,
                LessonNumber = 1
            };
            var oldLesson3 = new ExtendedLesson()
            {
                Subject = new Subject("old2_1_1"),
                SubGroup = SubGroup.First,
                Fraction = Fraction.Numerator,
                LessonNumber = 2
            };
            var oldLesson4 = new ExtendedLesson()
            {
                Subject = new Subject("old2_1_2"),
                Fraction = Fraction.Numerator,
                SubGroup = SubGroup.Second,
                LessonNumber = 2
            };
            var oldLesson5 = new ExtendedLesson()
            {
                Subject = new Subject("old3_1_2"),
                Fraction = Fraction.Numerator,
                SubGroup = SubGroup.Second,
                LessonNumber = 3
            };

            var oldLesson6 = new ExtendedLesson()
            {
                Subject = new Subject("old3_2_1"),
                Fraction = Fraction.Denominator,
                SubGroup = SubGroup.First,
                LessonNumber = 3
            };

            var newLesson1 = new ExtendedLesson()
            {
                Subject = new Subject("new1"),
                Fraction = Fraction.None,
                LessonNumber = 1
            };

            var newLesson2 = new ExtendedLesson()
            {
                Subject = new Subject("new2"),
                Fraction = Fraction.Numerator,
                LessonNumber = 2
            };

            var newLesson3 = new ExtendedLesson()
            {
                Subject = new Subject("new3"),
                Fraction = Fraction.None,
                LessonNumber = 3
            };

            resultLessonsList.Add(oldLesson1);
            resultLessonsList.Add(oldLesson2);
            resultLessonsList.Add(oldLesson3);
            resultLessonsList.Add(oldLesson4);
            resultLessonsList.Add(oldLesson5);
            resultLessonsList.Add(oldLesson6);
            newLessonsList.Add(newLesson1);
            newLessonsList.Add(newLesson2);
            newLessonsList.Add(newLesson3);

            //act
            LessonsMerger.MergeLessonsList(resultLessonsList, newLessonsList);

            //assert
            var assertList1 = resultLessonsList.Where(l => l.LessonNumber == 1).ToList();
            Assert.AreEqual(1, assertList1.Count);
            Assert.AreEqual("new1", assertList1[0].Subject.Name);

            var assertList2 = resultLessonsList.Where(l => l.LessonNumber == 2).ToList();
            Assert.AreEqual(1, assertList2.Count);
            Assert.AreEqual("new2", assertList2[0].Subject.Name);

            var assertList3 = resultLessonsList.Where(l => l.LessonNumber == 3).ToList();
            Assert.AreEqual(1, assertList3.Count);
            Assert.AreEqual("new3", assertList3[0].Subject.Name);
        }

        [Test]
        public void MergeLessonsList_AddLesson_Test()
        {
            //arrange
            var resultLessonsList = new List<ExtendedLesson>();
            var newLessonsList = new List<ExtendedLesson>();
            var oldLesson1 = new ExtendedLesson()
            {
                Subject = new Subject("old1"),
                LessonNumber = 1
            };
            var oldLesson2 = new ExtendedLesson()
            {
                Subject = new Subject("old2"),
                LessonNumber = 2
            };
            var oldLesson3 = new ExtendedLesson()
            {
                Subject = new Subject("old3"),
                LessonNumber = 3
            };
            var newLessonFractionNone = new ExtendedLesson()
            {
                Subject = new Subject("new4"),
                SubGroup = SubGroup.None,
                LessonNumber = 4
            };

            resultLessonsList.Add(oldLesson1);
            resultLessonsList.Add(oldLesson2);
            resultLessonsList.Add(oldLesson3);
            newLessonsList.Add(newLessonFractionNone);

            //act
            LessonsMerger.MergeLessonsList(resultLessonsList, newLessonsList);

            //assert

            var assertList = resultLessonsList.Where(l => l.LessonNumber == 4).ToList();
            Assert.AreEqual(1, assertList.Count);
            Assert.AreEqual("new4", assertList[0].Subject.Name);
        }

        /// <summary>
        /// Test case when trying to add 2 new lesson with the same lesson number but different group when early this lesson number was empty
        /// </summary>
        [Test]
        public void MergeLessonsList_NoOldLesson_2newSubGroupLessons_Test()
        {
            //arrange
            var resultLessonsList = new List<ExtendedLesson>();
            var newLessonsList = new List<ExtendedLesson>();
            var oldLesson1 = new ExtendedLesson()
            {
                Subject = new Subject("old1"),
                LessonNumber = 1
            };

            var newLesson1 = new ExtendedLesson()
            {
                Subject = new Subject("new2_0_1"),
                SubGroup = SubGroup.First,
                LessonNumber = 2
            };

            var newLesson2 = new ExtendedLesson()
            {
                Subject = new Subject("new2_0_2"),
                SubGroup = SubGroup.Second,
                LessonNumber = 2
            };

            resultLessonsList.Add(oldLesson1);
            newLessonsList.Add(newLesson1);
            newLessonsList.Add(newLesson2);

            //act
            LessonsMerger.MergeLessonsList(resultLessonsList, newLessonsList);

            //assert

            var assertList1 = resultLessonsList.Where(l => l.LessonNumber == 1).ToList();
            Assert.AreEqual(1, assertList1.Count);
            Assert.AreEqual("old1", assertList1[0].Subject.Name);

            var assertList = resultLessonsList.Where(l => l.LessonNumber == 2).ToList();
            Assert.AreEqual(2, assertList.Count);
            Assert.AreEqual("new2_0_1", assertList.FirstOrDefault(l => l.SubGroup == SubGroup.First).Subject.Name);
            Assert.AreEqual("new2_0_2", assertList.FirstOrDefault(l => l.SubGroup == SubGroup.Second).Subject.Name);
        }
    }
}