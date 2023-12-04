namespace DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string CategoryName { get; set; }
        public string? Auther { get; set; }

        public int? NumOfPages { get; set; }

        public string? Image { get; set; }

        public double? Price { get; set; }

    }

}
