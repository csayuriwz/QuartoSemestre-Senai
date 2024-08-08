Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"Digite o numero para saber sua tabuada");
int n = int.Parse(Console.ReadLine());

for(int i = 0; i < 11; i++){
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine($"{n} X {i} = {n * i} ");
}




