using Maturidade_Online.Dominio;
using Maturidade_Online.Repositorio.Abstrato;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Repositorio
{
    public class PilarRepositorioEF : RepositorioAbstratoEF<Pilar>, IPilarRepositorio
    {
        public PilarRepositorioEF(ContextoDeDadosEF contexto) : base(contexto)
        {
        }

      

        public Pilar BuscarPorId(Pilar pilar)
        {
            return contexto.Pilar
             //.Include("caracteristicas")
             //.Include("subtopicos")
             .FirstOrDefault(p => p.Id == pilar.Id);
        }


        public ICollection<PilarPontuacao> ListarPontuacaoTotal()
        {
            contexto.Configuration.ProxyCreationEnabled = false;
            return contexto.Database.SqlQuery<PilarPontuacao>("SELECT p.id, p.titulo, SUM(s.Pontuacao) as PontuacaoTotal FROM Subtopico s INNER JOIN pilar p ON p.id = s.PilarId group by p.id, p.Titulo order by p.titulo").ToList();
        }
    }
}


