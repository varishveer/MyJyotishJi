using BusinessAccessLayer.Abstraction;
using DataAccessLayer.DbServices;
using ModelAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Implementation
{
    public class UserServices:IUserServices
    {
        private readonly ApplicationContext _context;
        public UserServices(ApplicationContext context)
        {
            _context = context;
        }
        public List<string> HomaPageSlider()
        {
            var record = _context.Sliders.Select(x => x.HomePage).ToList();
            return record;
        }

        public List<string> BAPCategorySlider()
        {
            var record = _context.Sliders.Select(x => x.BookPoojaCategory).ToList();
            return record;
        }
        public List<string> PoojaListSlider()
        {
            var record = _context.Sliders.Select(x => x.PoojaList).ToList();
            return record;
        }

    }
}
