using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JobyProfiles.Model
{
    public class UserModel
    {
        public int ID {  get; set; }
        public string? USERID { get; set; }
        public string? FIRSTNAME { get; set; }
        public string? LASTNAME { get; set; }
        public string? MIDDLENAME { get; set; }
        public int AGE { get; set; }
        public string? EMAIL {  get; set; }
        public DateOnly BIRTHDAY { get; set; }
        public string? PROFILEPHOTO { get; set; }
        public DateTime REGISTERDATE { get; set; }
        public string? CONTACTNUM { get; set; }
    }
}
