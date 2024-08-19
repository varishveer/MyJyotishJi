using ModelAccessLayer.Models;
using ModelAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Abstraction
{
    public interface IPendingJyotishServices
    {

        public  Task<bool> UploadDocumentAsync(DocumentViewModel model);
        public  Task<DocumentModel> Documents(string email);
        public  Task<PendingJyotishModel> Profile(string email);
    }
}
