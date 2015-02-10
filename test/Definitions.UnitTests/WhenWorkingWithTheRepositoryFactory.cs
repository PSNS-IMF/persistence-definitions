using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Psns.Common.Test.BehaviorDrivenDevelopment;

using Psns.Common.Persistence.Definitions;

using Moq;

using Ninject;

namespace Definitions.UnitTests
{
    public class TestClass : IIdentifiable
    {
        public int Id { get; set; }
    }

    [TestClass]
    public class WhenWorkingWithTheRepositoryFactory : BehaviorDrivenDevelopmentCaseTemplate
    {
        protected RepositoryFactory Factory;
        protected Mock<IKernel> MockKernel;
        protected IRepository<TestClass> Repository;

        public override void Arrange()
        {
            base.Arrange();

            MockKernel = new Mock<IKernel>();
            MockKernel.Setup(k => k.GetService(typeof(IRepository<TestClass>)))
                .Returns(new Mock<IRepository<TestClass>>().Object);

            Factory = new RepositoryFactory(MockKernel.Object);
        }

        public override void Act()
        {
            base.Act();

            Repository = Factory.Get<TestClass>();
        }

        [TestMethod]
        public void TheGetShouldReturnTheRepositoryTypeRequested()
        {
            MockKernel.Verify(k => k.GetService(typeof(IRepository<TestClass>)), Times.Once());
        }
    }
}
