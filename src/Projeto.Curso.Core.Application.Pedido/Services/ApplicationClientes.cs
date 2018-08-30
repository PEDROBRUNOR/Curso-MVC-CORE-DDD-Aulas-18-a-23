using AutoMapper;
using Projeto.Curso.Core.Application.Pedido.Interfaces;
using Projeto.Curso.Core.Application.Pedido.ViewModels;
using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Services;
using Projeto.Curso.Core.Infra.CrossCutting.Extensions;
using System;
using System.Collections.Generic;

namespace Projeto.Curso.Core.Application.Pedido.Services
{
    public class ApplicationClientes : IApplicationClientes
    {
        private readonly IServiceClientes serviceclientes;
        private readonly IMapper mapper;

        public ApplicationClientes(IServiceClientes _serviceclientes,
                                   IMapper _mapper)
        {
            serviceclientes = _serviceclientes;
            mapper = _mapper;
        }

        public ClientesViewModel Adicionar(ClientesViewModel cliente)
        {
            return mapper.Map<ClientesViewModel>(serviceclientes.Adicionar(mapper.Map<Clientes>(cliente)));
        }

        public ClientesViewModel Atualizar(ClientesViewModel cliente)
        {
            return mapper.Map<ClientesViewModel>(serviceclientes.Atualizar(mapper.Map<Clientes>(cliente)));
        }

        public ClientesViewModel Remover(ClientesViewModel cliente)
        {
            return mapper.Map<ClientesViewModel>(serviceclientes.Remover(mapper.Map<Clientes>(cliente)));
        }
        public IEnumerable<ClientesViewModel> ObterTodos()
        {
            return mapper.Map<IEnumerable<ClientesViewModel>>(serviceclientes.ObterTodos());
        }

        public ClientesViewModel ObterPorId(int id)
        {
            return mapper.Map<ClientesViewModel>(serviceclientes.ObterPorId(id));
        }

        public ClientesViewModel ObterPorApelido(string apelido)
        {
            return mapper.Map<ClientesViewModel>(serviceclientes.ObterPorApelido(apelido));
        }

        public ClientesViewModel ObterPorCpfCnpj(string cpfcnpj)
        {
            return mapper.Map<ClientesViewModel>(serviceclientes.ObterPorCpfCnpj(cpfcnpj.SomenteNumeros()));
        }

        public void Dispose()
        {
            serviceclientes.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
