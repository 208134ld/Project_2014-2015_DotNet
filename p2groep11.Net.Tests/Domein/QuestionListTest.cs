using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class QuestionListTest
    {
        [TestMethod]
        public void ConstructorMakesNewListParameters()
        {
            QuestionList questionList = new QuestionList();
            List<Parameter> lijst = new List<Parameter>();
            Assert.AreEqual(lijst, questionList.Parameters);

        }
    }
}
