using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoLogP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try //Fiz um tratamento de erros basico
            {
                Console.WriteLine("Digite o CPF (Com pontos e hifem)");
                string[] cpf_b = Console.ReadLine().Split('.', '-'); //Separei os caracteres especiais
                string cpf_concatenado = cpf_b[0] + cpf_b[1] + cpf_b[2] + cpf_b[3]; //Concatenei os strings gerados pelo .Split()

                bool cpf_valido = VerificadorCPF(cpf_concatenado);

                if (cpf_valido) //Se tudo estiver certo, o bool VerificadorCPF ira retornar True
                {
                    Console.WriteLine("CPF valido");
                }
                else            //Se algo ocorrer errado, o bool ira retornar False
                {
                    Console.WriteLine("CPF invalido");
                }
            } 
            catch 
            {
                Console.WriteLine("Digite valores validos");
            }
            Console.ReadKey();
        }

        static bool VerificadorCPF(string cpf)
        {
            if (cpf.Length != 11) //Verifiquei se o cpf(concatenado) tinha mais ou menos que 11 digitos
            {
                return false;
            }

            int soma = 0;
            //Criei um laco de repeticao para calcular a soma ponderada dos 9 primeiros dígitos do CPF multiplicados pelos pesos de 10 a 2
            for (int i = 0; i < 9; i++) 
            {
                soma += (int)Char.GetNumericValue(cpf[i]) * (10 - i);
            }

            int Primeiro = 0; //Criei uma variavel para guardar o primeiro numero do Digito verificador
            int resto = soma % 11;

            if (resto < 2)  //Verifiquei se o resto era igual a 0 ou 1, pois com essas condicoes o primeiro digito e igual a 0
            {
                Primeiro = 0;
            }
            else //Caso contrario, o irei subtrair o resto de 11
            {
                Primeiro = 11 - resto;
            }

            if (Primeiro != (int)Char.GetNumericValue(cpf[9]))
            {
                return false;
            }

            soma = 0;   //Voltei o valor da soma para 0 porque irei verificar os segundo numero

            /*Acrescentei o primeiro digito verificador ao cpf e calculei a soma ponderada desses 10 dígitos multiplicados
             pelos pesos de 11 a 2 */
            for (int i = 0; i < 10; i++)
            {
                soma += (int)Char.GetNumericValue(cpf[i]) * (11 - i);
            }

            //Fiz os mesmos procedimentos que havia descrito anteriormente (linha 50 ate 57)
            int Segundo = 0;
            resto = soma % 11;

            if (resto < 2)
            {
                Segundo = 0;
            }
            else
            {
                Segundo = 11 - resto;
            }

            if (Segundo != (int)Char.GetNumericValue(cpf[10]))
            {
                return false;
            }

            return true;
        }
    }
}