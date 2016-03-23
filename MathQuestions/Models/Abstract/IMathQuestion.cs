using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathQuestions.Models.Abstract
{
    public interface IMathQuestion : ICloneable
    {
        string QuestionText { get; set; }
        double QuestionAnswer { get; set; }
    }
}
