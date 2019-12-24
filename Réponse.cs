using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzCSharp
{
    class Réponse
    {
        /// <summary>
        /// Libellé de la réponse
        /// </summary>
        public string Libellé { get; }
        /// <summary>
        /// Booléen représentant si une réponse est bonne ou non
        /// </summary>
        public bool EstBonne { get; }

        /// <summary>
        /// Constructeur prenant une string et un booléen en paramètre
        /// </summary>
        /// <param name="libellé">Libellé de la réponse</param>
        /// <param name="estVrai">Booléen représentant si une réponse est bonne ou non</param>
        public Réponse(string libellé, bool estVrai)
        {
            Libellé = libellé;
            EstBonne = estVrai;
        }
    }
}
