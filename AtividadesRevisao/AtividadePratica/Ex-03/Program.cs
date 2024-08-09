// Crie um programa que calcule a soma dos números pares de um vetor de 10 elementos.
// Utilize um laço for para percorrer o vetor e uma estrutura condicional if para identificar
// os números pares.

float[] numeros = new float[10];

float somaP = 0;

Console.WriteLine($"Soma dos nú'meros pares dentro de um conjunto de 10");

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Digite um número para ser adicionado ao conjunto");
    numeros[i] = float.Parse(Console.ReadLine()!); 

    if (numeros[i] % 2 == 0)
    {
        somaP += numeros[i] ;
    }
}


Console.WriteLine($"Resultado dos números pares : {somaP}");




