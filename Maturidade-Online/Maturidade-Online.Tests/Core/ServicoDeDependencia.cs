using Maturidade_Online.Dominio.Pilar;
using Maturidade_Online.Dominio.Usuario;
using Maturidade_Online.Infraestrutura;
using Maturidade_Online.Dominio.Caracteristica;
using Maturidade_Online.Dominio.Subtopico;
using Maturidade_Online.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maturidade_Online.Dominio.Projeto;

namespace Maturidade_Online.Tests.Core
{
    public class ServicoDeDependencia
    {

        public static CaracteristicaServico CriarCaracteristicaServico()
        {
            return new CaracteristicaServico(
                    new CaracteristicaRepositorioMock()
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
