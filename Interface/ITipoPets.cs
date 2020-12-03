using APIPETS.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPETS.Interface
{
    interface ITipoPets
    {
        List<TipoPets> LerTodos();
        TipoPets BuscarPorID(int id);
        TipoPets Cadastrar(TipoPets t);
        TipoPets Alterar(int id , TipoPets t);
        void Excluir(int id);
    }
}
