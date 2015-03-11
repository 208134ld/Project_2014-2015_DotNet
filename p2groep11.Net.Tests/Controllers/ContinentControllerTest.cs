using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using p2groep11.Net.Controllers;
using p2groep11.Net.Models.DAL;

namespace p2groep11.Net.Tests.Controllers
{
    [TestClass]
    public class ContinentControllerTest
    {
        private ContinentController continentController;
        private Mock<IGradeRepository> gradeRepository;
        private DummyDataContext context;

        [TestInitialize]
        public void Initialize()
        {

        }
    }
}
