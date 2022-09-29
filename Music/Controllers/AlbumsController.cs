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
      Album album = Album.Find(albumId);
      Artist artist = Artist.Find(artistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("album", album);
      model.Add("artist", artist);
      return View(model);
    }

    [HttpPost("/albums/delete")]
    public ActionResult DeleteAll()
    {
      Album.ClearAll();
      return View();
    }

  }
}