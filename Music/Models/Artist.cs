using System.Collections.Generic;

namespace Music.Models
{
  public class Artist
  {
    private static List<Artist> _instances = new List<Artist> {};
    public string Name { get; set; }
    public int Id { get; }
    public List<Album> Albums { get; set; }

    public Artist(string artistName)
    {
      Name = artistName;
      _instances.Add(this);
      Id = _instances.Count;
      Albums = new List<Album>{};
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public void AddAlbum(Album album)
  {
    Albums.Add(album);
  }

  }
}