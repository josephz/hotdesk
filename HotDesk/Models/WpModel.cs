namespace HotDesk.Models
{
    public class WpModel
    {
        public WpModel(int level, int id)
        {
            this.Level = level;
            this.Id = id;
        }

        public int Id { get; set; }

        public int Level { get; set; }

        public bool Available { get; set; }
    }
}