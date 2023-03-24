namespace JogoForca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                string[] palavra = { "ABACATE", "ABACAXI", "ACEROLA", "ACAI", "ARACA", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJA", "CAJU",
                "CARAMBOLA", "CUPUACU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MACA", "MANGABA", "MANGA", "MARACUJA", "MURICI",
                "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA"};

                Random random = new Random();
                int n = random.Next(palavra.Length);
                string palavraEscolhida = palavra[n];
                int tent = 5, acertos = 0;
                string head = "", body = "", lArm = "", rArm = "", legs = "";
                char[] palavraEscondida = new char[palavraEscolhida.Length];
                Array.Fill<char>(palavraEscondida, '_');
                while (tent > 0)
                {

                    Console.Write("Escolha uma letra: ");
                    char letra = Convert.ToChar(Console.ReadLine().ToUpper());
                    
                    if (!palavraEscolhida.Contains(letra))
                    {
                        tent--;
                        if (tent == 4)
                            head = "O";
                        else if (tent == 3)
                            body = " |";
                        else if (tent == 2)
                            rArm = "\\";
                        else if (tent == 1)
                        {
                            lArm = "/";
                            body = "|";
                        }
                        else if (tent == 0)
                            legs = "/ \\";
                    }
                    {
                        Console.WriteLine(" ----------");
                        Console.WriteLine(" |/       |");
                        Console.WriteLine($" |        {head}");
                        Console.WriteLine($" |       {lArm}{body}{rArm}");
                        Console.WriteLine($" |       {legs}");
                        Console.WriteLine(" |");
                        Console.WriteLine(" |");
                        Console.WriteLine(" |");
                        Console.WriteLine(" |");
                        Console.WriteLine("_|_____\n");
                    }
                    if (palavraEscondida[0] == ' ')
                    {
                        for (int i = 0; i < palavraEscolhida.Length; i++)
                        {
                            if (letra == palavraEscolhida[i])
                            {
                                
                                palavraEscondida[i] = palavraEscolhida[i];
                            }
                            else
                            {
                                palavraEscondida[i] = '_';
                            }

                        }
                    }
                    else if (palavraEscolhida.Contains(letra))
                    {
                        for (int i = 0; i < palavraEscolhida.Length; i++)
                        {
                            if (letra == palavraEscolhida[i] && palavraEscondida[i] != palavraEscolhida.ToCharArray()[i])
                            {
                                acertos++;
                                palavraEscondida[i] = letra;
                                
                            }
                        }
                    }

                    Console.WriteLine(palavraEscondida);

                    if (acertos == palavraEscondida.Length)
                    {
                        Console.WriteLine("\nParabéns, você adivinhou!");
                        break;
                    }
                    else if (!palavraEscolhida.Equals(palavraEscondida) && tent == 0)
                        Console.WriteLine("Você matou aquele homem >:)");
                }
            }
        }
    }
}