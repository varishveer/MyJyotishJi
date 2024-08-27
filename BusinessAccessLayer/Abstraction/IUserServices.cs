using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Abstraction
{
    public interface IUserServices
    {
        public List<string> HomaPageSlider();
        public List<string> BAPCategorySlider();
        public List<string> PoojaListSlider();
    }
}
