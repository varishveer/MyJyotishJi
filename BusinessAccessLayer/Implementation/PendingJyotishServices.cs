using BusinessAccessLayer.Abstraction;
using DataAccessLayer.DbServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer.Models;
using ModelAccessLayer.ViewModels;
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
        private readonly string _uploadDirectory;
        public PendingJyotishServices(ApplicationContext context)
        {
            _context = context;
            // Set the directory where files will be saved
            _uploadDirectory = Directory.GetCurrentDirectory() ;

            // Ensure directory exists
            if (!Directory.Exists(_uploadDirectory))
            {
                Directory.CreateDirectory(_uploadDirectory);
            }
        }




        public async Task<bool> UploadDocumentAsync(DocumentViewModel model)
        {
            var isJyotishValid = _context.PendingJyotishRecords.Where(x=>x.Email == model.JyotishEmail).FirstOrDefault();
            if(isJyotishValid == null)
            { return false; }
            var document = new DocumentModel
            {
                JyotishId = isJyotishValid.Id
            };

            try
            {
                // Process IdProof file
                if (model.IdProof != null)
                {
                    var idProofGuid = Guid.NewGuid().ToString();
                    var SqlPath = "/Assets/PendingJyotish/Document/" + idProofGuid + model.IdProof.FileName;
                    var idProofPath = Path.Combine(_uploadDirectory,SqlPath );
                    using (var stream = new FileStream(idProofPath, FileMode.Create))
                    {
                        await model.IdProof.CopyToAsync(stream);
                    }
                    document.IdProof = SqlPath;
                }

                // Process AddressProof file
                if (model.AddressProof != null)
                {
                    var addressProofGuid = Guid.NewGuid().ToString();
                    var SqlPath = "/Assets/PendingJyotish/Document/" + addressProofGuid + model.AddressProof.FileName;
                    var addressProofPath = Path.Combine(_uploadDirectory, SqlPath);
                   
                    using (var stream = new FileStream(addressProofPath, FileMode.Create))
                    {
                        await model.AddressProof.CopyToAsync(stream);
                    }
                    document.AddressProof = SqlPath;
                }

                // Process TenthCertificate file
                if (model.TenthCertificate != null)
                {
                    var tenthCertificateGuid = Guid.NewGuid().ToString();
                    var SqlPath = "/Assets/PendingJyotish/Document/" + tenthCertificateGuid + model.TenthCertificate.FileName;
                    var tenthCertificatePath = Path.Combine(_uploadDirectory, SqlPath);

                  
                    using (var stream = new FileStream(tenthCertificatePath, FileMode.Create))
                    {
                        await model.TenthCertificate.CopyToAsync(stream);
                    }
                    document.TenthCertificate = SqlPath;
                }

                // Process TwelveCertificate file
                if (model.TwelveCertificate != null)
                {
                    var twelveCertificateGuid = Guid.NewGuid().ToString();
                    var SqlPath = "/Assets/PendingJyotish/Document/" + twelveCertificateGuid + model.TwelveCertificate.FileName;
                    var twelveCertificatePath = Path.Combine(_uploadDirectory, SqlPath);

                  
                    using (var stream = new FileStream(twelveCertificatePath, FileMode.Create))
                    {
                        await model.TwelveCertificate.CopyToAsync(stream);
                    }
                    document.TwelveCertificate = SqlPath;
                }

                // Process ProfessionalCertificate file
                if (model.ProfessionalCertificate != null)
                {
                    var professionalCertificateGuid = Guid.NewGuid().ToString();
                    var SqlPath = "/Assets/PendingJyotish/Document/" + professionalCertificateGuid + model.ProfessionalCertificate.FileName;
                    var professionalCertificatePath = Path.Combine(_uploadDirectory, SqlPath);


                   
                    using (var stream = new FileStream(professionalCertificatePath, FileMode.Create))
                    {
                        await model.ProfessionalCertificate.CopyToAsync(stream);
                    }
                    document.ProfessionalCertificate = SqlPath;
                }

                // Save document data to database

                var IsRecordExist = _context.Documents.Where(X => X.JyotishId == document.JyotishId).FirstOrDefault();
                if (IsRecordExist == null)
                { _context.Documents.Add(document); }
                else
                { _context.Documents.Update(document); }
                
                 var result = await _context.SaveChangesAsync();
                if(result> 0)
                { return true; }
                else { return false; }
                 
            }
            catch (Exception ex)
            {
                // Log the exception if necessary
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; // Failure in processing files or saving to the database
            }
        }

        public async Task<DocumentModel> Documents(string email)
        {
            var isEmailValid = await _context.PendingJyotishRecords.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (isEmailValid == null) { return null; }
            var isDocumentAvailable = await _context.Documents.Where(x=>x.JyotishId == isEmailValid.Id).FirstOrDefaultAsync();
            if (isDocumentAvailable == null) { return null; }
            else { return isDocumentAvailable; }
        }

        public async Task<PendingJyotishModel> Profile(string email)
        {
            if (email == null) { return null; }
            var result = await _context.PendingJyotishRecords.Where(x => x.Email == email).FirstOrDefaultAsync();
            if (result == null) { return null; }
            return result;
        }
    }
}
