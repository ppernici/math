using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathQuestions.Models.Abstract;

namespace MathQuestions.Models.Abstract
{
    public interface IArithmeticGenerator
    {
        IMathQuestion ArithmeticQuestion();
    }
}
