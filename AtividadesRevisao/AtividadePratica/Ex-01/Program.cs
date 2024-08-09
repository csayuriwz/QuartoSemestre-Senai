// Escreva um programa que peça ao usuário para digitar um número inteiro e informe se o
// número é par ou ímpar. Utilize uma estrutura condicional if/else para realizar o teste.

Console.WriteLine($"Digite um número:");
int nmr = int.Parse(Console.ReadLine()!);

if (nmr % 2 == 0)
{
    Console.WriteLine($"O número é par!");
}else
{
    Console.WriteLine($"O número é ímpar!");
}

