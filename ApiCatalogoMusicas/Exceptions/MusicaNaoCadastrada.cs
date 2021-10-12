using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoMusicas.Exceptions
{
    public class MusicaNaoCadastradaException : Exception
    {
      public     MusicaNaoCadastradaException()
        : base ("Esta musica não está cadastrada")
        { }
    }
}
