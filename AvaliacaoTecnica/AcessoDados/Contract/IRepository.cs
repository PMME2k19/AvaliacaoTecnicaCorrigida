using AvaliacaoTecninca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoTecninca.Data
{
    public interface IRepository<T>
    {
        IList<T> Listar();

        bool Inserir(T objecto);

        void Eliminar(T objecto);

        bool Actualizar(T objecto);

        T Buscar(Guid id);

    }
}