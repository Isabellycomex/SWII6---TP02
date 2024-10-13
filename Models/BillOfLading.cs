namespace CustomsSystem.Models
{
    public class BillOfLading
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Consignee { get; set; }

        public string Ship {  get; set; }

        public ICollection<Container> Containers { get; } = new List<Container>();
    }
}
