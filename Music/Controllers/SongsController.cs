using Microsoft.AspNetCore.Mvc;
using Music.Models;
using System.Collections.Generic;

namespace Music.Controllers
{
  public class SongsController : Controller
  {

    [HttpGet("/artists/{artistId}/albums/{albumId}/songs/new")]//extended the route to add songs after the rest of the info
    public ActionResult New(int albumId)
    {
      Album album = Album.Find(albumId);
      return View(album);
    }

    [HttpGet("/artists/{artistId}/albums/{albumId}/songs/{songId}")]
    public ActionResult Show(int artistId, int albumId, int songId)
    {
      Song song = Song.Find(songId);
      Album album = Album.Find(albumId);
      Artist foundArtist = Artist.Find(artistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("songs", song);
      model.Add("album", album);
      model.Add("artist", foundArtist);
      return View(model);
    }

    [HttpPost("/songs/delete")]//delete still doesn;t exist
    public ActionResult DeleteAll()
    {
      Song.ClearAll();
      return View();
    }

  }
}