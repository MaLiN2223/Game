namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run(30,30);
            }
        }
    }
}
