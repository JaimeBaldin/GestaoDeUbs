using GestaoDeUbs.Domain.Entities;
using System.Linq.Expressions;

namespace GestaoDeUbs.Domain.Queries;

public class EncaminhamentoQueries
{
    public static Expression<Func<EncaminhamentoEntidade, bool>> BuscarPorId(int id)
    {
        return x => x.Id == id;
    }

    public static Expression<Func<EncaminhamentoEntidade, bool>> BuscarPorPaciente(int idPaciente)
    {
        return x => x.Paciente.Id == idPaciente;
    }


    public static Expression<Func<EncaminhamentoEntidade, bool>> BuscarPorHospital(int id)
    {
        return x => x.HospitalId == id;
    }
}
