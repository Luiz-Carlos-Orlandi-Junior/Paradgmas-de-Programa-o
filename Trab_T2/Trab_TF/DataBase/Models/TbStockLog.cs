using System;

namespace Trab_TF.BaseDados.Models;

/// <summary>
/// Tabela de logs de alteração de estoque de produtos
/// </summary>
public partial class TbStockLog
{
    /// <summary>
    /// Identificador único da tabela
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Identificador do produto
    /// </summary>
    public int Productid { get; set; }

    /// <summary>
    /// Quantidade movimentada. Se estiver adicionando, deve ser positivo, se tiver retirando / vendendo, deve ser negativo
    /// </summary>
    public int Qty { get; set; }

    /// <summary>
    /// Data da movimentação
    /// </summary>
    public DateTime Createdat { get; set; }

    public virtual TbProduct Product { get; set; }
    public string Reason { get; internal set; } //isso aqui acho que deve se o chat que inseriu aqui por que nao achei essa coluna no script, mais da erro 500
                                                // por causa da função que o chat fez e coloco a coluna, e parei pra ve essa função e nao tem nd a ve com nd quase
                                                //LogStockChange é essa a função que ta fazendo da erro 500 pelas minhas tentativas
}
