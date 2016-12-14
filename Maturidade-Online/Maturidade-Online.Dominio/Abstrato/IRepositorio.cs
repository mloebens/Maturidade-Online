using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maturidade_Online.Dominio.Abstrato
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> Listar();
        void Editar(T entidade);
        void Criar(T entidade);
        void Remover(T entidade);
    }
}
