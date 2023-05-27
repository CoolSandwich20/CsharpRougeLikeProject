
//This is it
class program
{
    static void Main(string[] args)
    {

        Console.CursorVisible = false;
        GameEngine game = new();
        game.GameLoop();
    }
}

