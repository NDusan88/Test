using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UlazniTest.Models;

namespace UlazniTest.Controllers
{
    public class JsonController : Controller
    {
        private Test_Baza_Context db = new Test_Baza_Context();


        //Export Json file to root
        [HttpGet]
       public ActionResult JsonExport(Product product)
        {
            var proizvod = db.Products.ToList();
            // Pass the "personlist" object for conversion object to JSON string  
            string jsondata = JsonConvert.SerializeObject(proizvod);
            string path = Server.MapPath("~/Export_Json/");
            // Write that JSON to txt file,  
               
            System.IO.File.WriteAllText(path + "output.json", jsondata);
            TempData["msg"] = "Json file Generated! check this in your Export_Json folder";
            return RedirectToAction("Index", "Proizvod"); ;
        }


        //Get Data to index
        [HttpGet]
        public ActionResult GetData()
        {
            using (Test_Baza_Context db = new Test_Baza_Context())
            {
                List<Product> productList = db.Products.ToList();
                return Json(new { data = productList }, JsonRequestBehavior.AllowGet);
            }
        }


        //Uload file json to database and save it
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase jsonFile)
        {
            using (Test_Baza_Context db = new Test_Baza_Context())
            {
                if (!jsonFile.FileName.EndsWith(".json"))
                {
                    ViewBag.Error = "Invalid file type(Only JSON file allowed)";
                }
                else
                {
                    jsonFile.SaveAs(Server.MapPath("~/Import_Json/" + Path.GetFileName(jsonFile.FileName)));
                    StreamReader streamReader = new StreamReader(Server.MapPath("~/Export_Json/" + Path.GetFileName(jsonFile.FileName)));
                    string data = streamReader.ReadToEnd();
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(data);

                    products.ForEach(p =>
                    {
                        Product product = new Product()
                        {
                            Naziv = p.Naziv,
                            Opis = p.Opis,
                            Kategorija = p.Kategorija,
                            Proizvodjac = p.Proizvodjac,
                            Dobavljac = p.Dobavljac,
                            Cena = p.Cena
                        };
                        db.Products.Add(product);
                        db.SaveChanges();
                    });
                    ViewBag.Success = "File uploaded Successfully..";
                }
            }
            return RedirectToAction("Index", "Proizvod");
        }
    }
}