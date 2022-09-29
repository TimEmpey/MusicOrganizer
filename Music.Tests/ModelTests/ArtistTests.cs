using Microsoft.VisualStudio.TestTools.UnitTesting;
using Music.Models;
using System.Collections.Generic;
using System;

namespace Music.Tests
{
  [TestClass]
  public class ArtistTests : IDisposable
  {

    public void Dispose()
    {
      Artist.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
    {
      Artist newArtist = new Artist("test artist");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
  public void GetName_ReturnsName_String()
  {
    //Arrange
    string name = "Test Artist";
    Artist newArtist = new Artist(name);

    //Act
    string result = newArtist.Name;

    //Assert
    Assert.AreEqual(name, result);
  }

    [TestMethod]
  public void GetId_ReturnsArtistId_Int()
  {
    //Arrange
    string name = "Test Artist";
    Artist newArtist = new Artist(name);

    //Act
    int result = newArtist.Id;

    //Assert
    Assert.AreEqual(1, result);
  }

    [TestMethod]
  public void AddAlbum_AssociatesAlbumWithArtist_AlbumList()
  {
    //Arrange
    string description = "Walk the dog.";
    Album newAlbum = new Album(description);
    List<Album> newList = new List<Album> { newAlbum };
    string name = "Work";
    Artist newArtist = new Artist(name);
    newArtist.AddAlbum(newAlbum);

    //Act
    List<Album> result = newArtist.Albums;

    //Assert
    CollectionAssert.AreEqual(newList, result);
  }


  }
}