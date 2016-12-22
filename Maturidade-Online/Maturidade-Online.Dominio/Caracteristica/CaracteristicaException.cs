using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio
{
    public class CaracteristicaException : Exception
    {
        public CaracteristicaException(string mensagem) : base(mensagem)
        {
        }
    }
}
