using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record GameDto(
   
   int id,
   string Name,
   string Genre,
   decimal Price,
   DateTime ReleaseDate,
   string ImageURI
    
);

public record createGameDto(
  
  [Required][StringLength(50)] string Name,

   [Required][StringLength(20)]string Genre,
   [Range(1,100)]decimal Price,
   DateTime ReleaseDate,
   [Url]string ImageURI
);

public record updateGameDto(
  
  [Required][StringLength(50)] string Name,

   [Required][StringLength(20)]string Genre,
   [Range(1,100)]decimal Price,
   DateTime ReleaseDate,
   [Url]string ImageURI
);