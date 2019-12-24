using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuizzCSharp
{
    class DAL
    {
        public const string Path = "..\\..\\..\\DonnéesMétéoParis.txt";

        static public List<Question> GetQuestions()
        {
            string[] file = File.ReadAllLines("..\\..\\..\\QCM.txt", Encoding.UTF8);
            var questions = new List<Question>();

            Question question = new Question("");
            Réponse réponse;

            foreach (var item in file)
            {
                if (item.ToLower().Contains("question"))
                {
                    question = new Question(item);
                }
                else if (item == "")
                {
                    questions.Add(question);
                }
                else if (item[0] >= 65 && item[0] <= 68)
                {
                    réponse = new Réponse(item, false);
                    question.Réponses.Add(réponse);
                }
                else if (item.StartsWith('*'))
                {
                    réponse = new Réponse(item.Remove(0, 1), true);
                    question.Réponses.Add(réponse);
                }

                if (item == file[file.Length - 1])
                {
                    questions.Add(question);
                }
                //else
                //{
                //    throw new FormatException($"Le format de la ligne \"{item}\" n'est pas pris en compte.");
                //}
            }

            return questions;
        }
    }
}
