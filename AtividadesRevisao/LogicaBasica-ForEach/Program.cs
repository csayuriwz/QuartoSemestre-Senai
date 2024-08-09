// Exercício:

// 5) Você vai criar um programa que armazena as notas de vários alunos em diferentes disciplinas. O programa deve calcular a média de cada aluno e determinar quais alunos têm médias acima de 7.0 (aprovados) e quais têm médias abaixo de 7.0 (reprovados). O programa deve usar foreach para iterar sobre as coleções de alunos e suas notas.

// Especificações:

// - Armazene as notas de 3 disciplinas para cada aluno.
// - Calcule a média de cada aluno.
// - Exiba a média e o status (aprovado/reprovado) de cada aluno.
// - Use foreach para iterar sobre os alunos e as disciplinas.

int[] notas = [1, 2, 3];

Console.WriteLine($"Digite o nome do aluno");
string nome = Console.ReadLine()!;

Console.WriteLine(@$"
-------------------------------------
| Escolha a Materia desejada para   |
| saber sua média                   |
|                                   | 
|                                   |
|    (1) matematica                 |
|    (2) quimica                    |
|    (3) fisica                     |
-------------------------------------
");
char materia = char.Parse(Console.ReadLine()!);

switch (materia)
{
    case '1':
        Console.WriteLine($"Digite a sua primeira nota de matematica ");
        int n1M = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"Digite a sua segunda nota de matematica ");
        int n2M = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"Digite a sua terceira nota de matematica ");
        int n3M = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"sua media em matematica é: {(n1M + n2M + n3M) / 3}");
        break;
    case '2':
        Console.WriteLine($"Digite a sua primeira nota de quimica ");
        int n1Q = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"Digite a sua segunda nota de quimica ");
        int n2Q = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"Digite a sua terceira nota de quimica ");
        int n3Q = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"sua media em quimica é: {(n1Q + n2Q + n3Q) / 3}");
        break;
    case '3':
        Console.WriteLine($"Digite a sua primeira nota de fisica ");
        int n1F = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"Digite a sua segunda nota de fisica ");
        int n2F = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"Digite a sua terceira nota de fisica ");
        int n3F = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"sua media em fisica é: {(n1F + n2F + n3F) / 3}");
        break;
    default:
        Console.WriteLine($"Materia invalida!");
        break;
}







