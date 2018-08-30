using Dapper;
using Microsoft.EntityFrameworkCore;
using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Repository
{
    public class RepositoryProdutos : Repository<Produtos>, IRepositoryProdutos
    {
        public RepositoryProdutos(ContextEFPedidos context)
            : base(context)
        {

        }

        public override IEnumerable<Produtos> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produtos ORDER BY ID DESC");
            var produtos = Db.Database.GetDbConnection().Query<Produtos>(query.ToString());
            return produtos;
        }

        public override Produtos ObterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produtos WHERE id = @uID");
            var produtos = Db.Database.GetDbConnection().Query<Produtos>(query.ToString(), new { uID = id });
            return produtos.FirstOrDefault();
        }


        public Produtos ObterPorApelido(string apelido)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produtos WHERE apelido = @uAPELIDO
                          ");
            var produtos = Db.Database.GetDbConnection().Query<Produtos>(query.ToString(), new { uAPELIDO = apelido } );
            return produtos.FirstOrDefault();
        }

        public Produtos ObterPorNome(string nome)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produtos WHERE nome = @uNOME");
            var produtos = Db.Database.GetDbConnection().Query<Produtos>(query.ToString(), new { uNOME = nome });
            return produtos.FirstOrDefault();
        }

    }
}
