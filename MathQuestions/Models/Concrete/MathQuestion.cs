using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MathQuestions.Models.Abstract;

namespace MathQuestions.Models.Concrete
{
    public class MathQuestion : IMathQuestion, ICloneable
    {
        private string question;
        private double answer;

        public double QuestionAnswer
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
            }
        }
        public string QuestionText
        {
            get
            {
                return question;
            }

            set
            {
                question = value;
            }
        }

        public object Clone()
        {
            MathQuestion q = new MathQuestion();
            q.answer = answer;
            q.question = question;
            return q;
        }
    }
}