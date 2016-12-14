using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Infraestrutura
{
    public interface IServicoDeCriptografia
    {

        string Criptografar(string texto);

    }
}
