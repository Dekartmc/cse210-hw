using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
  private Reference _reference;
  private List<Word> _words;

  public Scripture(Reference reference, string text)
  {
    _reference = reference;
    _words = text.Split(' ').Select(word => new Word(word)).ToList();
  }

  public void Display()
  {
    Console.Clear();
    Console.WriteLine(_reference.ToString());
    Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
  }

  public void HideRandomWords(int count = 3)
  {
    Random rnd = new Random();
    var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

    if (visibleWords.Count == 0) return;

    for (int i = 0; i < count && visibleWords.Count > 0; i++)
    {
        int index = rnd.Next(visibleWords.Count);
        visibleWords[index].Hide();
        visibleWords.RemoveAt(index);
    }
  }

  public bool AllWordsHidden()
  {
    return _words.All(w => w.IsHidden());
  }
}