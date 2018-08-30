using Dapper;
using Microsoft.EntityFrameworkCore;
using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository.AgregacaoPedidos;
using Projeto.Curso.Core.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Repository.AgregacaoPedidos
{
    public class RepositoryPedidos : Repository<Pedidos>, IRepositoryPedidos
    {
        public RepositoryPedidos(ContextEFPedidos context)
            : base(context)
        {

        }

        public override IEnumerable<Pedidos> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM pedidos ORDER BY Id DESC");
            var pedidos = Db.Database.GetDbConnection().Query<Pedidos>(query.ToString());
            return pedidos;
        }

        public override Pedidos ObterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM pedidos WHERE P.ID=@uID");
            var pedidos = Db.Database.GetDbConnection().Query<Pedidos>(query.ToString(), new { uID = id });
            return pedidos.FirstOrDefault();
        }

        public IEnumerable<ItensPedidos> ObterItensPedido(int idpedido)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM itenspedidos WHERE idpedido=@uIDPEDIDO ORDER BY id DESC"); 
            var itenspedidos = Db.Database.GetDbConnection().Query<ItensPedidos>(query.ToString(), new { @uIDPEDIDO = idpedido });
            return itenspedidos;
        }

        public ItensPedidos ObterItensPedidosPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM itenspedidos WHERE id=@uID");
            var itenspedidos = Db.Database.GetDbConnection().Query<ItensPedidos>(query.ToString(), new { @uID = id });
            return itenspedidos.FirstOrDefault();

        }

        public IEnumerable<ItensPedidos> ObterItensPedidoProdutoEspecifico(int idproduto)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine(@"SELECT * FROM itenspedidos WHERE IDPRODUTO.ID=@uIDPRODUTO");
            var itenspedidos = Db.Database.GetDbConnection().Query<ItensPedidos>(query.ToString(), new { @uIDPRODUTO = idproduto });
            return itenspedidos;
        }


        public void AdicionarItensPedidos(ItensPedidos item)
        {
            Db.ItensPedidos.Add(item);
        }

        public void AtulizarItensPedidos(ItensPedidos item)
        {
            Db.ItensPedidos.Update(item);
        }

        public void RemoverItensPedidos(ItensPedidos item)
        {
            Db.ItensPedidos.Remove(item);
        }

    }
}
