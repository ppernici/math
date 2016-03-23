using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MathQuestions.Models.Abstract;
using MathQuestions.Models.Concrete;

namespace MathQuestions.Models.Concrete
{
    public class AlgebraGenerator : IAlgebraGenerator
    {
        private static Random r = new Random();
        private IMathQuestion question;

        public AlgebraGenerator(IMathQuestion question)
        {
            this.question = question;
        }

        public IMathQuestion AlgebraQuestion()
        {
            // Randomly select an equation type.
            int decision = r.Next(3);

            // Return result of method call.
            if (decision == 0)
                return Linear1();
            else if (decision == 1)
                return Linear2();
            else
                return DepressedQuadratic();
        }

        /// <summary>
        /// Added functionality: get linear as y = mx
        /// </summary>
        /// <returns></returns>
        private IMathQuestion Linear1()
        {
            /// Generate a simple y = mx + b question.
            double y = r.NextDouble() * (r.Next(1000) - 500);
            double m = r.NextDouble() * (r.Next(1000) - 500);

            // Get question and answer.
            question.QuestionAnswer = Math.Round(y / m, 1);
            question.QuestionText = string.Format("Solve: {0:} = {1}x", Math.Round(y, 1), Math.Round(m, 1));

            return (IMathQuestion)question.Clone();
        }
        /// <summary>
        /// Added functionality: get linear as y = mx + b
        /// </summary>
        /// <returns></returns>
        private IMathQuestion Linear2()
        {
            /// Generate a simple y = mx + b question.
            double y = r.NextDouble() * (r.Next(1000) - 500);
            double m = r.NextDouble() * (r.Next(1000) - 500);
            double b = r.NextDouble() * r.Next(500);

            // Get question and answer.
            question.QuestionAnswer = Math.Round((y - b) / m, 1);
            question.QuestionText = string.Format("Solve: {0:} = {1}x + {2}", Math.Round(y, 1), Math.Round(m, 1), Math.Round(b, 1));

            return (IMathQuestion)question.Clone();
        }
        /// <summary>
        /// Added functionality: get quadratic as ax^2 + c = 0.
        /// </summary>
        /// <returns></returns>
        private IMathQuestion DepressedQuadratic()
        {
            // Get a and c.
            double a = r.NextDouble() * r.Next(1, 500);
            double c = r.NextDouble() * r.Next(500);

            // Ensure that a != 0
            while (a == 0)
                a = r.NextDouble() * r.Next(1, 500);

            question.QuestionAnswer = Math.Round(Math.Sqrt(c / a), 1);
            question.QuestionText = string.Format("Solve: {0}x^2 = {1}", Math.Round(a, 1), Math.Round(c, 1));

            return (IMathQuestion)question.Clone();
        }
    }
}