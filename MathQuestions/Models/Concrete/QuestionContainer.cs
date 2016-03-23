using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MathQuestions.Models.Abstract;

namespace MathQuestions.Models.Concrete
{
    public class QuestionContainer : IQuestionContainer
    {
        /// <summary>
        /// Members for the types of questions and container.
        /// </summary>
        IArithmeticGenerator arithmeticGenerator;
        IAlgebraGenerator algebraGenerator;
        List<IMathQuestion> container = new List<IMathQuestion>();
        int size;
        int currentQuestion = 0;

        /// <summary>
        /// Property to hold number of questions in container.
        /// </summary>
        public int NumberOfQuestions
        {
            get { return size; }
            set
            {
                if (value > 0 && value != size) // If value is valid and not the same as size, resize and redo list.
                {
                    size = value;
                    GenerateList();
                }
            }
        }
        /// <summary>
        /// Constructor declares dependency on arithmetic and algebra generator interfaces.
        /// Initializes list of questions to size.
        /// </summary>
        /// <param name="arithmeticGenerator"></param>
        /// <param name="algebraGenerator"></param>
        public QuestionContainer(IArithmeticGenerator arithmeticGenerator, IAlgebraGenerator algebraGenerator, int size = 10)
        {
            this.arithmeticGenerator = arithmeticGenerator;
            this.algebraGenerator = algebraGenerator;
            NumberOfQuestions = size;
            currentQuestion = 0;

            // Initialize the list using random questions.
            GenerateList();
        }
        /// <summary>
        ///  Public method to get the next question.
        /// </summary>
        /// <returns></returns>
        public IMathQuestion GetNextQuestion()
        {
            ++currentQuestion;
            return container[currentQuestion - 1];
        }
        /// <summary>
        /// Helper function to generate a new list.
        /// </summary>
        private void GenerateList()
        {
            for (int i = 0; i < NumberOfQuestions; ++i)
            {
                if (i % 2 == 0) // If even, do arithmetic.
                    container.Insert(i, arithmeticGenerator.ArithmeticQuestion());
                else // Else do algebra question.
                    container.Insert(i, algebraGenerator.AlgebraQuestion());
            }
        }
    }
}