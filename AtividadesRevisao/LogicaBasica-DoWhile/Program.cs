using System.Security.Cryptography;

int aleat = RandomNumberGenerator.GetInt32(1,100);
int tentativa = 0;
int chute = 0;

do
{
    Console.WriteLine($"Escolha um numero de 1 a 100!");
    chute = int.Parse(Console.ReadLine()!);
    tentativa++;
    if (chute != aleat)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine($"errou bb");

        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine(chute < aleat ? "o numero eh maior" : "o numero eh menor");  
    }
    
} while (chute != aleat);

Console.ForegroundColor = ConsoleColor.Green;

Console.WriteLine($"acertou bb!!");
Console.WriteLine($"tentativas : {tentativa}");



