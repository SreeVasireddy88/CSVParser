using CsvWebParser.Helper;
using CsvWebParser.Models;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsvWebParser.Controllers
{
    public class HomeController : Controller
    {
        private ProductsContext context = new ProductsContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FileUpload(FileViewModel model)
        {
            if (model.File == null)
            {
                model.Message = "Please go back and upload the sheet.";
                return View(model);
            }

            // Reading the excel file stream using Excel data reader.
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(model.File.InputStream);

            // Iterating through the excel rows.
            bool updated = false;
            int processedCount = 0;
            while (excelReader.Read())
            {
                string asin = Utils.ConvertToString(excelReader.GetValue(0));
                string title = Utils.ConvertToString(excelReader.GetValue(1));
                decimal price = Utils.ConvertToDecimal(excelReader.GetValue(2));
                double netMargin = Utils.ConvertToDouble(excelReader.GetValue(3));

                // Assuming if excel has more than 4 columns - Break the execution. Since the csv template and the uploaded csv are different
                if (excelReader.FieldCount > 4)
                {
                    model.Message = "There are more columns than expected. Please upload an excel sheet with Valid data.";
                    break;
                }

                if (!String.IsNullOrWhiteSpace(asin) && !asin.Equals("asin", StringComparison.OrdinalIgnoreCase))
                {
                    Product product = new Product()
                    {
                        AsIdn = asin,
                        Title = title,
                        Price = price,
                        NetMargin = netMargin,
                    };

                    // If Product already present in DB, Update the title, price and net margin.
                    if (context.Products.Any(p => p.AsIdn.Equals(product.AsIdn)))
                    {
                        var productDetails = context.Products.FirstOrDefault(p => p.AsIdn.Equals(product.AsIdn));
                        productDetails.Title = product.Title;
                        productDetails.Price = product.Price;
                        productDetails.NetMargin = product.NetMargin;
                        context.SaveChanges(); 

                        updated = true;
                        processedCount++;
                    }
                    // Insert into DB for new records
                    else
                    {
                        context.Products.Add(product);
                        context.SaveChanges();

                        updated = true;
                        processedCount++;
                    }
                }
            }

            // Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();

            if (updated)
            {
                model.Message = "Uploaded file has been successfully processed and " + processedCount + " records have been either added or updated to the Database.";
            }

            return View(model);
        }
    }
}