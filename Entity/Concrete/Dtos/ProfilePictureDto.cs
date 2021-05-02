using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entity.Concrete.Dtos
{
    public class ProfilePictureDto:IDto
    {
        public IFormFile Image { get; set; }

        public int MemberId { get; set; }
    }
}