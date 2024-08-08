int n = 1;
int somaPar = 0;


while (n <= 100)
{
   if (n % 2 ==0)
   {
    somaPar += n;
   }
   n++;
    Console.WriteLine($"{somaPar}");
}



