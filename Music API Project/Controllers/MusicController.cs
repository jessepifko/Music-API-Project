using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Music_API_Project.Data;
using Music_API_Project.Models;
using Music_API_Project.Models.AlbumModel;
using Artist = Music_API_Project.Models.Artist;

namespace Music_API_Project.Controllers
{
    public class MusicController : Controller
    {
        private readonly string _apiKey;
        private readonly SearchResultsDAL _srDAL;
        private readonly ArtistDetailsVM artistDetailsVM = new ArtistDetailsVM();
        private readonly MusicDBContext _context;
        

        public MusicController(IConfiguration iconfig, MusicDBContext context)
        {
            _apiKey = iconfig.GetSection("ApiKeys")["MusicAPI"];
            _srDAL = new SearchResultsDAL(_apiKey);
            _context = context;
        }

        public async Task<IActionResult> Index(string queryString)
        {
            SearchResults sr = await _srDAL.GetSearchResults(queryString);
            Array.Sort(sr.data);
            return View(sr);
        }

        public async Task<IActionResult> ViewAlbum(int albumID)
        {
            Music_API_Project.Models.AlbumModel.Album ab = await _srDAL.GetAlbum(albumID);            
            return View(ab);
        }

        public async Task<IActionResult> ArtistDetails(string artistID)
        {

            Artist artist = await _srDAL.GetArtist(artistID);
            TrackList trackList = await _srDAL.GetTrackList(artistID);

            artistDetailsVM.artist = artist;
            artistDetailsVM.trackList = trackList;

            return View(artistDetailsVM);
        }

        public async Task<IActionResult> GetTrackList(string artistID)
        {
            TrackList ar = await _srDAL.GetTrackList(artistID);
            return RedirectToAction("ArtistDetails");
        }
        [Authorize]
        public IActionResult ShowFavorites(int id, string title, string ArtistName, string album, string preview)
        {

            ViewBag.id = id;
            ViewBag.title = title;
            ViewBag.ArtistName = ArtistName;
            ViewBag.album = album;
            ViewBag.preview = preview;
            


            var favorites = new Favorites();
            string newId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            favorites.UserId = newId;
            // favorites.FavoriteId = 15;
            favorites.ArtistName = ArtistName;
            favorites.SongTitle = title;
            favorites.SongId = id;
            favorites.AlbumCover = album;
            favorites.PreviewSong = preview;
            //favorites.Album = ;
            _context.Favorites.Add(favorites);
            _context.SaveChanges();

            List<Favorites> favs = _context.Favorites.Where(x => x.UserId == newId).ToList();

            favs.ForEach(x => x.UserId = User.FindFirst(ClaimTypes.Name).Value);
            return View(favs);
        }
        [Authorize]
        public IActionResult ListFavorites()
        {
            string newId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Favorites> favs = _context.Favorites.Where(x => x.UserId == newId).ToList();

            favs.ForEach(x => x.UserId = User.FindFirst(ClaimTypes.Name).Value);

            return View("ShowFavorites", favs);

        }
        [Authorize]
        public async Task<IActionResult> DeleteFavorite(int? favoriteId)
        {
            if (favoriteId == null)
            {
                return NotFound();
            }
       
            var newFav = await _context.Favorites.FindAsync(favoriteId);

            _context.Favorites.Remove(newFav);
            _context.SaveChanges();
           
            return RedirectToAction("ListFavorites");
        }
    }
}