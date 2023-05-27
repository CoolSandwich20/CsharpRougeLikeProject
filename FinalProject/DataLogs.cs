public class DataLogs<T>
{
    private int _maxSize;
    private Queue<T> _dataLogs;

    public DataLogs()
    {
        _maxSize = 3;
        _dataLogs = new Queue<T>();
    }
    public void AddItem(T Item)
    {
        _dataLogs.Enqueue(Item);
        if (_dataLogs.Count() >= _maxSize)
        {
            _dataLogs.Dequeue();
        }
    }
    public void printDataLog()
    {
        int position = 0;
        try
        {

            foreach (var item in _dataLogs)
            {
                Console.SetCursorPosition(0, 18 +position);
                Console.WriteLine(item);
                Console.WriteLine();
                position++;
            }
        }
        catch { }
    }
    public void Clear()
    {
        _dataLogs.Clear();
    }


}

