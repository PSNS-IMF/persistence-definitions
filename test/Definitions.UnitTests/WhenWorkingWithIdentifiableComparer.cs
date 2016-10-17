using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Psns.Common.Test.BehaviorDrivenDevelopment;
using Psns.Common.Persistence.Definitions;

namespace Definitions.UnitTests.IdentifiableComparerTests
{
    public class TestClass : IIdentifiable
    {
        public int Id { get; set; }
    }

    public class WhenWorkingWithIdentifiableComparer : BehaviorDrivenDevelopmentCaseTemplate
    {
        protected TestClass x;
        protected TestClass y;
        protected bool areEqual;

        public override void Arrange()
        {
            base.Arrange();

            x = new TestClass { Id = 1 };
            y = new TestClass { Id = 2 };
        }

        public override void Act()
        {
            base.Act();

            areEqual = new IdentifiableComparer().Equals(x, y);
        }
    }

    [TestClass]
    public class AndObjectsAreNotEqual : WhenWorkingWithIdentifiableComparer
    {
        public override void Act()
        {
            base.Act();

            areEqual = new IdentifiableComparer().Equals(x, y);
        }

        [TestMethod]
        public void ThenTheyShouldNotBeEqual()
        {
            Assert.IsFalse(areEqual);
        }
    }

    [TestClass]
    public class AndObjectsAreEqual : WhenWorkingWithIdentifiableComparer
    {
        public override void Arrange()
        {
            base.Arrange();

            y.Id = 1;
        }

        public override void Act()
        {
            base.Act();

            areEqual = new IdentifiableComparer().Equals(x, y);
        }

        [TestMethod]
        public void ThenTheyShouldBeEqual()
        {
            Assert.IsTrue(areEqual);
        }
    }

    [TestClass]
    public class AndTestingUnEqualCollections : WhenWorkingWithIdentifiableComparer
    {
        List<TestClass> _old;
        List<TestClass> _new;
        IEnumerable<IIdentifiable> _result;

        public override void Arrange()
        {
            base.Arrange();

            _old = new List<TestClass>
            {
                new TestClass { Id = 1 },
                new TestClass { Id = 2 }
            };

            _new = new List<TestClass>
            {
                new TestClass { Id = 1 },
                new TestClass { Id = 5 },
                new TestClass { Id = 6 }
            };
        }

        public override void Act()
        {
            base.Act();

            _result = _new.Except(_old, new IdentifiableComparer());
        }

        [TestMethod]
        public void ThenNewItemsShouldBeAddedAndOldItemRemoved()
        {
            Assert.AreEqual(2, _result.Count());
            Assert.AreEqual(5, _result.ElementAt(0).Id);
            Assert.AreEqual(6, _result.ElementAt(1).Id);
        }
    }
}
