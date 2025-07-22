using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
  private List<Entry> _entries = new List<Entry>();

  public void AddEntry(Entry entry)
  {
    _entries.Add(entry);
  }

  public void DisplayAll()
  {
    foreach (Entry entry in _entries)
    {
      Console.WriteLine(entry);
    }
  }

  public void SaveToFile(string filename)
  {
    using (StreamWriter writer = new StreamWriter(filename))
    {
      foreach (Entry entry in _entries)
      {
        writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
      }
    }
    Console.WriteLine("Journal saved successfully.");
  }

  public void LoadFromFile(string filename)
  {
    _entries.Clear();

    if (!File.Exists(filename))
    {
      Console.WriteLine("File not found.");
      return;
    }

    string[] lines = System.IO.File.ReadAllLines(filename);

    foreach (string line in lines)
    {
        string[] parts = line.Split(",");

        string firstName = parts[0];
        string lastName = parts[1];
    }
  }

  public void SaveToJson(string filename)
  {
    string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(filename, json);
    Console.WriteLine("Journal saved to JSON successfully.");
  }

  public void LoadFromJson(string filename)
  {
    _entries.Clear();

    if (!File.Exists(filename))
    {
      Console.WriteLine("File not found.");
      return;
    }

    string json = File.ReadAllText(filename);
    try
    {
      _entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
      Console.WriteLine("Journal loaded from JSON successfully.");
    }
    catch (JsonException)
    {
      Console.WriteLine("Error: Could not read JSON file. Is the format correct?");
    }
  }
}
