namespace DesafioFundamentos.Models;

public class Estacionamento
{
    private decimal precoInicial;
    private decimal precoPorHora;
    private readonly List<string> veiculos = new();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
    }

    public int Asc(string letra)
    {
        return Convert.ToChar(letra);
    }

    public bool ValidaPlaca(string placaVeiculo)
    {
        bool retorno = false;

        if (placaVeiculo.Count() == 7)
        {
            // verifica as letras
            if (Asc(placaVeiculo[0].ToString()) >= Asc("A") && Asc(placaVeiculo[0].ToString()) <= Asc("Z") &&
                Asc(placaVeiculo[1].ToString()) >= Asc("A") && Asc(placaVeiculo[1].ToString()) <= Asc("Z") &&
                Asc(placaVeiculo[2].ToString()) >= Asc("A") && Asc(placaVeiculo[2].ToString()) <= Asc("Z"))
            {
                // verifica os numeros
                if (Asc(placaVeiculo[3].ToString()) >= Asc("0") && Asc(placaVeiculo[3].ToString()) <= Asc("9") &&
                    Asc(placaVeiculo[5].ToString()) >= Asc("0") && Asc(placaVeiculo[5].ToString()) <= Asc("9") &&
                    Asc(placaVeiculo[6].ToString()) >= Asc("0") && Asc(placaVeiculo[6].ToString()) <= Asc("9"))
                {
                    // mercosul ou nacional
                    if ((Asc(placaVeiculo[4].ToString()) >= Asc("A") && Asc(placaVeiculo[4].ToString()) <= Asc("Z")) ||
                        (Asc(placaVeiculo[6].ToString()) >= Asc("0") && Asc(placaVeiculo[6].ToString()) <= Asc("9")))
                    {
                        retorno = true;
                    }
                }
            }
        }
        return retorno;
    }

    public void AdicionarVeiculo()
    {
        // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
        // *IMPLEMENTE AQUI*
        Console.WriteLine("Digite a placa do veículo para estacionar:");
        var strPlaca = Console.ReadLine();
        strPlaca = strPlaca.ToUpper();

        // verifica se placa é valida
        if (ValidaPlaca(strPlaca))
        {
            // verifica se placa ja existe 
            var adicionaPlaca = true;

            foreach (var auxPlaca in veiculos)
                if (auxPlaca == strPlaca)
                    adicionaPlaca = false;

            if (adicionaPlaca)
            {
                veiculos.Add(strPlaca);
            }
            else
            {
                Console.WriteLine("Placa já cadastrada");
                Console.ReadLine();
            }
        }
        else
        {
            Console.WriteLine("Placa inválida");
            Console.WriteLine("Informe uma Placa no Formato:");
            Console.WriteLine("LLLNNNN ou LLLNLNN");
            Console.WriteLine("onde L = letra maiúscula de A a Z");
            Console.WriteLine("e    N = digito de 0 a 9");
            Console.WriteLine("Tecle Enter para continuar...");
            Console.ReadLine();
        }
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para remover:");

        // Pedir para o usuário digitar a placa e armazenar na variável placa
        // *IMPLEMENTE AQUI*
        var placa = Console.ReadLine();
        placa = placa.ToUpper();
        // Verifica se o veículo existe
        if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

            // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
            // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
            // *IMPLEMENTE AQUI*
            decimal horas = decimal.Parse(Console.ReadLine());
            decimal valorTotal = 0;
            valorTotal = precoInicial + (precoPorHora * horas);
            
            // TODO: Remover a placa digitada da lista de veículos
            // *IMPLEMENTE AQUI*
            foreach (var auxPlaca in veiculos)
            {
                if (auxPlaca == placa)
                {
                    veiculos.Remove(placa);
                    break;
                }
            }
                
            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
        }
        else
        {
            Console.WriteLine(
                "Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }
    }

    public void ListarVeiculos()
    {
        // Verifica se há veículos no estacionamento
        if (veiculos.Any())
            // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
            // *IMPLEMENTE AQUI*
        {
            Console.WriteLine("Os veículos estacionados são:");

            foreach (var auxPlaca in veiculos)
                Console.WriteLine(auxPlaca);
        }
        else
            Console.WriteLine("Não há veículos estacionados.");
    }
}