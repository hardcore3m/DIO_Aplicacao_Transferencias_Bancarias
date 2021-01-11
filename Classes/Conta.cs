using System;

namespace DIO.Bank
{
    //Criacao da classe conta
    public class Conta
    {
        //Encapsulamento. Todos são privados
        private TipoConta Tipoconta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        //Construtor - Metodo chamado no momento que é criado o Objeto
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.Tipoconta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        //Método sacar Recebe o saldo do Cheque especial, não pode ser negativo
        public bool Sacar(double valorSaque)
        {
            //Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente");
                //Para a execução e retorna para o método que chamou
                return false;
            }
            //Subtrai o saque do saldo
            this.Saldo -= valorSaque;
            //Imprime o saldo após a operação
            Console.WriteLine("{0}, seu saldo atual é de {1}", this.Nome, this.Saldo);
            //Confirma a transação
            return true;
        }

        //Metodo depositar. Nao necessita verificar nada
        public void Depositar(double valorDeposito)
        {
            //Adiciona o deposito ao saldo
            this.Saldo += valorDeposito;
            Console.WriteLine("{0}, seu saldo atual é de {1}", this.Nome, this.Saldo);
        }

        //Transferir. Valor da trasferência + qual valor transferir
        public void Transferir(double valorTansferencia, Conta contaDestino)
        {
            //Aproveita os métodos, sacando de uma conta e depositando na outra. 
            //1 transferencia = 1 saque + 1 deposito com um valor em comum
            if (this.Sacar(valorTansferencia))
            {
                contaDestino.Depositar(valorTansferencia);
            }
        }
        //Sobrescrever a saida da classe mae no console imprimindo o nome da classe
        public override string ToString()
        {
            string retorno ="";
            retorno+="TipoConta " + this.Tipoconta + " | ";
            retorno+="Nome " + this.Nome + " | ";
            retorno+="Saldo " +this.Saldo + " | ";
            retorno+="Credito " +this.Credito + " | ";
            return retorno;
        }
        //Geralmente usado para registro de log.
    }
}