namespace MVCFifa.ViewModels
{
    public class PlayerImageViewModel
    {
        public int Id { get; set; }
        public string? ImageLink { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
