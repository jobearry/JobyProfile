using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raszventory.Model
{
    public class InventoryModel
    {
        public int id {  get; set; }
        public string? item_type { get; set; }
        public string? item_name { get; set; }
        public string? model_no { get; set; }
        public string? item_code { get; set; }
    }
}
