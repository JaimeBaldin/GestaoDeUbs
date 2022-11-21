using GestaoDeUbs.Domain.Entities;
using System.Linq.Expressions;

namespace GestaoDeUbs.Domain.Queries;

public class PacienteQueries
{
    public static Expression<Func<PacienteEntidade, bool>> BuscarPorId(int id)
    {
        return x => x.Id == id;

    }
}
