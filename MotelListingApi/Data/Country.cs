using System.Collections.Generic;

namespace MotelListingApi.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual IList<Hotel> Hotels { get; set; } // This field need not to be in Database
    }
}
