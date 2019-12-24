using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzCSharp
{
    class Réponse
    {
        public string Libellé { get; }
        public bool EstVrai { get; }

        public Réponse(string libellé, bool estVrai)
        {
            Libellé = libellé;
            EstVrai = estVrai;
        }
    }
}
