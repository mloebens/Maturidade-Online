

 
        public ICollection<PilarPontuacao> ListarPontuacaoTotal()
        {
            contexto.Configuration.ProxyCreationEnabled = false;
            return contexto.Database.SqlQuery<PilarPontuacao>("SELECT p.id, p.titulo, SUM(s.Pontuacao) as PontuacaoTotal FROM Subtopico s INNER JOIN pilar p ON p.id = s.PilarId group by p.id, p.Titulo order by p.titulo").ToList();
        }
    }
}

        public override void Criar(Pilar pilar)
        {
            //base.Criar(entidade);
            contexto.Entry<Pilar>(pilar).State = EntityState.Added;
            contexto.SaveChanges();
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