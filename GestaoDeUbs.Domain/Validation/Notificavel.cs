namespace GestaoDeUbs.Domain.Validation;

public abstract class Notificavel
{
    private readonly List<string> _notificacoes;

    public Notificavel()
    {
        _notificacoes = new List<string>();
    }

    public void AdicionarNotificacao(string mensagem)
    {
        _notificacoes.Add(mensagem);
    }

    public IReadOnlyCollection<string> Notificacoes => _notificacoes;

    public bool IsInvalida => _notificacoes.Any();

    public bool IsValida => !IsInvalida;
}
