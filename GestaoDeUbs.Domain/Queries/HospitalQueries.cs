using GestaoDeUbs.Domain.Entities;
using System.Linq.Expressions;

namespace GestaoDeUbs.Domain.Queries;

public class HospitalQueries
{
    public static Expression<Func<HospitalEntidade, bool>> BuscarPorId(int id)
    {
        return x => x.Id == id;
    }
}
