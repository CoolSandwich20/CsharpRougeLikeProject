
public class MenuEngine
{
    private int _selectedIndex;
    private string[] _options;
    private string _prompt;


    public MenuEngine(string[] Options, string prompt)
    {
        _prompt = prompt;
        _options = Options;
        _selectedIndex = 0;
    }

    private void DisplayOptions()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(_prompt);
        Console.ResetColor();
        for (int i = 0; i < _options.Length; i++)
        {
            Console.SetCursorPosition(120, 20+i);

            string CurrentOption = _options[i];
            if (_selectedIndex == i)
            {

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($" << {CurrentOption} >>");


        }
        Console.ResetColor();
    }
    public int Start()
    {
        Console.SetWindowSize(240, 40);
        Console.Clear();
        ConsoleKey Pressed;

        do
        {
            DisplayOptions();
            ConsoleKeyInfo Keys = Console.ReadKey(true);
            Console.SetCursorPosition(0, 0);

            Pressed = Keys.Key;
            

            if (ConsoleKey.UpArrow == Pressed)
            {
                _selectedIndex--;
                if (_selectedIndex == -1)
                {
                    _selectedIndex = _options.Length -1;
                }
            }
            if (ConsoleKey.DownArrow == Pressed)
            {
                _selectedIndex++;
                if (_selectedIndex == _options.Length)
                {
                    _selectedIndex = 0;
                }
            }

        } while (ConsoleKey.Enter != Pressed);
        return _selectedIndex;
    }
}
