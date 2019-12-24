using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzCSharp
{
    class Question
    {
        /// <summary>
        /// Libellé de la question
        /// </summary>
        public string Libellé { get; }
        /// <summary>
        /// Liste de réponses associées à la question
        /// </summary>
        public List<Réponse> Réponses { get; set; }

        /// <summary>
        /// Constructeur prenant un libellé en paramètre
        /// </summary>
        /// <param name="libellé"></param>
        public Question(string libellé)
        {
            Libellé = libellé;
            Réponses = new List<Réponse>();
        }

        /// <summary>
        /// Récupère les bonnes réponses de la question
        /// </summary>
        /// <returns>Retourne une string avec les identifiants des bonnes réponses</returns>
        public string GetBonnesRéponses()
        {
            string bonnesRéponses = "";

            foreach (var r in Réponses)
            {
                if (r.EstBonne)
                {
                    bonnesRéponses += r.Libellé[0];
                }
            }

            return bonnesRéponses;
        }
    }
}
