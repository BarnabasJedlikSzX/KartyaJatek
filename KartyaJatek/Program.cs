namespace KartyaJatek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Blackjack!");
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            Table game = new Table(playerName);

            game.PlayRound();
        }
    }
}
