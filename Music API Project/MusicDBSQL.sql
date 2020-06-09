CREATE TABLE Favorites (
UserId NVARCHAR(100) NOT NULL, 
FavoriteID int Primary Key Identity (1,1) NOT NULL,
SongID int NOT NULL, 
SongTitle NVARCHAR(50) NOT NULL,
ArtistName  NVARCHAR(50) NOT NULL,
AlbumCover NVARCHAR(MAX) NOT NULL,
PreviewSong NVARCHAR(100) NOT NULL
)