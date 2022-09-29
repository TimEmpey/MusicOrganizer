using Microsoft.AspNetCore.Mvc;
using Music.Models;
using System.Collections.Generic;

namespace Music.Controllers
{
  public class AlbumsController : Controller
  {

    [HttpGet("/artists/{artistId}/albums/new")]
    public ActionResult New(int artistId)
    {
      Artist artist = Artist.Find(artistId);
      return View(artist);
    }

    [HttpGet("/artists/{artistId}/albums/{albumId}")]
    public ActionResult Show(int artistId, int albumId)
    {
      Album foundAlbum = Album.Find(albumId);
      Artist foundArtist = Artist.Find(artistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Song> albumSongs = foundAlbum.Songs;
      model.Add("songs", albumSongs);
      model.Add("album", foundAlbum);
      model.Add("artist", foundArtist);
      return View(model);
    }

    [HttpPost("/artists/{artistId}/albums/{albumId}/songs")] // we'll need this for albums in almbumsController.cs for songs
    public ActionResult Create(int artistId, int albumId, string songName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Album foundAlbum = Album.Find(albumId);
      List<Song> albumSongs = foundAlbum.Songs;
      Song newSong = new Song(songName);
      foundAlbum.AddSong(newSong);
      model.Add("songs", albumSongs);
      model.Add("album", foundAlbum);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }

  }
}