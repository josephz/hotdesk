using System.Collections.Generic;

namespace HotDesk.Models
{
    public class FloorModel
    {
        public FloorModel(int id)
        {
            this.Level = id;
        }

        public int Level { get; set; }

        public List<int> AvailableWP { get; set; }
    }
}