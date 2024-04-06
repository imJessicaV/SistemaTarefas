using System.ComponentModel;

namespace SistemaTarefas.Enums;

public enum TasksStatus
{
    [Description("A Fazer")]
    AFazer = 1,

    [Description("Em Andamento")]
    EmAndamento = 2,

    [Description("Concluído")]
    Concluido = 3,
}
