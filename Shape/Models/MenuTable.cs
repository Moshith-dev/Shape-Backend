namespace Shape.Models
{
    public class MenuTable
    {
        public int ID { get; set; }
        public string Menu { get; set; }
        public int OrderNo { get; set; }
        public int ParentId { get; set; }
        public bool IsHeader { get; set; }
        public bool IsFooter { get; set; }

    }
}
