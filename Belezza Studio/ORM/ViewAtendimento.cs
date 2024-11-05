using System;
using System.Collections.Generic;

namespace Belezza_Studio.ORM;

public partial class ViewAtendimento
{
    public int Id { get; set; }

    public DateOnly DataAtendimento { get; set; }

    public TimeOnly Horario { get; set; }

    public string? TipoServico { get; set; }

    public decimal? Valor { get; set; }

    public string? Nome { get; set; }

    public DateTime DtHoraAgendamento { get; set; }

    public string? Email { get; set; }

    public string? Telefone { get; set; }
}
