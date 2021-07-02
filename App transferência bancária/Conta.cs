using System;
using System.Collections.Generic;
using System.Text;

namespace App_transferencia_bancaria {
    public class Conta {

        private TipoConta TipoConta { get; set; }

        private string Nome { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito) {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Credito = credito;
            this.Saldo = saldo;
        }

        public bool Sacar(double ValorSaque) {
            if (this.Saldo - ValorSaque < (this.Credito *-1)) {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= ValorSaque;
            Console.WriteLine($"Saldo atual da conta de  {this.Nome} é de: {this.Saldo}");
            return true;
        }

        public void Depositar(double ValorDeposito) {
            this.Saldo += ValorDeposito;
            Console.WriteLine($"O saldo atual de {this.Nome} é de {this.Saldo}");
        }

        public void Transferir(double ValorTransferencia, Conta ContaDestino) {
            if (this.Sacar(ValorTransferencia)) {
                ContaDestino.Depositar(ValorTransferencia);
            }
        }

        public override string ToString() {
            string retorno = " ";
            retorno += "tipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo" + this.Saldo + " | ";
            retorno += "Crédito" + this.Credito + " | ";
            return retorno;
        }
    }
}
