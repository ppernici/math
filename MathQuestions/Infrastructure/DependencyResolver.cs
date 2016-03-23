using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MathQuestions.Models.Abstract;
using MathQuestions.Models.Concrete;
using Ninject;

namespace MathQuestions.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public DependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IQuestionContainer>().To<QuestionContainer>();
            kernel.Bind<IAlgebraGenerator>().To<AlgebraGenerator>();
            kernel.Bind<IArithmeticGenerator>().To<ArithmeticGenerator>();
            kernel.Bind<IMathQuestion>().To<MathQuestion>();
        }
    }
}