using System.Drawing;

namespace Tp2_BaseDonnes.ViewModels
{
    public class ImageUploadVM
    {
        public IFormFile? FormFile { get; set; }

        public Image image { get; set; } = null!;
    }
}

