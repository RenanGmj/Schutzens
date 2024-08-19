using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSZ.Models
{
    public class Agendamento
    {
    public int AgendamentoID { get; set; }

    [Required]
    public DateTime Data { get; set; }

    // Chave estrangeira para Usuario
    [Required]
    public int UsuarioID { get; set; }

    // Propriedade de navegação
    [ForeignKey("UsuarioID")]
    public virtual Usuario Usuario { get; set; }

    // Chave estrangeira para Veiculo
    [Required]
    public int VeiculoID { get; set; }

    // Propriedade de navegação
    [ForeignKey("VeiculoID")]
    public virtual Veiculo Veiculo { get; set; }

    // Relacionamento com Servicos
    public virtual ICollection<Servico> Servicos { get; set; }

    public decimal CalcularPrecoTotal()
    {
        decimal precoTotal = 0.0m;

        foreach (var servico in Servicos)
        {
            var classeVeiculo = Veiculo.ClasseVeiculo;
            decimal precoAjustado = servico.PrecoBase;

            // Lógica para ajustar o preço baseado na classe do veículo
            // Por exemplo, você pode ter uma lógica de multiplicador baseado na classe do veículo
            if (classeVeiculo.Nome == "SUV")
            {
                precoAjustado *= 1.2m; // Ajuste de 20% para SUVs
            }
            else if (classeVeiculo.Nome == "Sedan")
            {
                precoAjustado *= 1.1m; // Ajuste de 10% para Sedans
            }

            precoTotal += precoAjustado;
        }

        return precoTotal;
    }
    }
}