using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MathQuestions.Models.Abstract;

namespace MathQuestions.Models.Concrete
{
    public class ArithmeticGenerator : IArithmeticGenerator
    {
        private static Random r = new Random();
        private IMathQuestion question;

        /// <summary>
        /// Declares dependency on IMathQuestion type.
        /// </summary>
        /// <param name="question"></param>
        public ArithmeticGenerator(IMathQuestion question)
        {
            this.question = question;
        }

        /// <summary>
        /// Returns the question.
        /// </summary>
        /// <returns></returns>
        public IMathQuestion ArithmeticQuestion()
        {
            // Generate operands and decide on type of operation.
            int a = r.Next(1000);
            int b = r.Next(1000);
            int decision = r.Next(1, 4);
            string op;

            // Get and answer and operator symbol.
            if (decision == 1) // Add
            {
                question.QuestionAnswer = a + b;
                op = "+";
            }
            else if (decision == 2) // Subtract
            {
                question.QuestionAnswer = a - b;
                op = "-";
            }
            else if (decision == 3) // Multiply
            {
                question.QuestionAnswer = a * b;
                op = "x";
            }
            else // Divide
            {
                question.QuestionAnswer = Math.Round((double)a / b, 1);
                op = "//";
            }

            // Generate and return question.
            question.QuestionText = string.Format("Evaluate: {0} {1} {2}", a, op, b);

            return (IMathQuestion)question.Clone();
        }
    }
}