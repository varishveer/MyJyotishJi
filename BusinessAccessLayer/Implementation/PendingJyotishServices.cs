using BusinessAccessLayer.Abstraction;
using DataAccessLayer.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Implementation
{
    public class PendingJyotishServices:IPendingJyotishServices
    {
        private readonly ApplicationContext _context;
        public PendingJyotishServices(ApplicationContext context)
        {
            _context = context;
        }


    }
}
