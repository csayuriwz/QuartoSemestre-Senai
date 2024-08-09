// Crie uma função que recebe um número como parâmetro e retorna a tabuada desse
// número até o número 10. Utilize um laço for para gerar os múltiplos do número.

Console.WriteLine($"Bem vinda(o) ao gerador de tabuada!");

Console.WriteLine($"Digite o número para tabuada ser gerada.");
int n = int.Parse(Console.ReadLine()!);


void tabuada(int nmr){

for(int i = 0; i < 11; i++){
    Console.WriteLine($"{n} X {i} = {n * i} ");
}
}

tabuada(n);