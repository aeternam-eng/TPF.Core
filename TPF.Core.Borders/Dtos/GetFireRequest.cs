#nullable disable

using Microsoft.AspNetCore.Http;

namespace TPF.Core.Borders.Dtos
{
    public class GetFireRequest
    {
        public IFormFile Img { get; set; }
    }
}
