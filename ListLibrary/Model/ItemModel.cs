namespace ListLibrary.Model
{
    public class ItemModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string PictureUrl { get; set; }
        public int PicFormat { get; set; }
        public decimal Score { get; set; }
        public int Year { get; set; }
        public bool Favourite { get; set; }
        public string Notes { get; set; }
        public string ListGroup { get; set; }
        public virtual string PictureDir { get; set; }
    }
}
