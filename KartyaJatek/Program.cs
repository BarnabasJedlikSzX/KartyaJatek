namespace KartyaJatek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Üdv a BlackJackben!");
            Console.Write("Add meg a felhasználóneved: ");
            string playerName = Console.ReadLine();
            Asztal game = new Asztal(playerName);

            game.PlayRound();
        }
    }
}
