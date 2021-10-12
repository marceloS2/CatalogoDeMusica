using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoMusicas.Exceptions
{
    public class MusicaJaCadastradaException : Exception
    {
      public MusicaJaCadastradaException()
          :base("Esta musica Já está cadastrada")
        { }      
    }
}
