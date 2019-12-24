using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzCSharp
{
    class Question
    {
        public string Libellé { get; set; }
        public List<Réponse> Réponses { get; set; }

        public Question(string libellé)
        {
            Libellé = libellé;
            Réponses = new List<Réponse>();
        }

        public string GetBonnesRéponses()
        {
            string bonnesRéponses = "";

            foreach (var r in Réponses)
            {
                if (r.EstVrai)
                {
                    bonnesRéponses += r.Libellé[0];
                }
            }

            return bonnesRéponses;
        }
    }
}
