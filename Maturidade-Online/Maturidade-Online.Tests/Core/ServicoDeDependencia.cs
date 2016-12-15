using Maturidade_Online.Dominio.Pilar;
using Maturidade_Online.Dominio.Subtopico;
using Maturidade_Online.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Tests.Core
{
    public class ServicoDeDependencia
    {

        public static PilarServico CriarPilarServico()
        {
            return new PilarServico(
                    new PilarRepositorioMock()
                );
        }

        public static SubtopicoServico CriarSubtopicoServico()
        {
            return new SubtopicoServico(
                    new SubtopicoRepositorioMock()
                );
        }
    }
}
