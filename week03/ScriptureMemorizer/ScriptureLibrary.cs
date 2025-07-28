using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
  private List<Scripture> _scriptures = new List<Scripture>();

  public ScriptureLibrary()
  {
    _scriptures.Add(new Scripture(
      new Reference("John", 3, 16),
      "For God so loved the world that he gave his one and only Son"
    ));

    _scriptures.Add(new Scripture(
      new Reference("Proverbs", 3, 5, 6),
      "Trust in the Lord with all your heart and lean not on your own understanding"
    ));

    _scriptures.Add(new Scripture(
      new Reference("Alma", 32, 21),
      "And now as I said concerning faith — faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true."
    ));

    _scriptures.Add(new Scripture(
      new Reference("D & C", 6, 36),
      "Look unto me in every thought; doubt not, fear not."
    ));
    
    _scriptures.Add(new Scripture(
      new Reference("Moses", 1, 39),
      "For behold, this is my work and my glory — to bring to pass the immortality and eternal life of man."
    ));
  }

  public Scripture GetRandomScripture()
  {
    Random rnd = new Random();
    int index = rnd.Next(_scriptures.Count);
    return _scriptures[index];
  }
}