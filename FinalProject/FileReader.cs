using System;

public class FileReader
    {

    public static string[] Read(int lvl)
    {
        return File.ReadAllLines($"C:\\Users\\funny\\OneDrive\\שולחן העבודה\\Tiltan\\Final Project\\C# Code\\Final Project\\FinalProject\\levels\\Level{lvl}.txt");
    }
    

}
