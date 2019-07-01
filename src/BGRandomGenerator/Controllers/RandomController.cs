using System;
using System.IO;
using System.Linq;
using BGRandomGenerator.Models;
using BGRandomGenerator.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BGRandomGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]    
    public class RandomController : MainControllerBase
    {
        public RandomController(IHostingEnvironment environment) : base(environment)
        {
        }

        [HttpGet]
        public ActionResult<string> Names(string gender, int? number)
        {            
            if (!number.HasValue)
            {
                number = 1;
            }
            else if (number < 1 || number > 3)
            {
                return BadRequest($"Invalid number of names supplied: {number}");
            }

            var rootPath = Environment.ContentRootPath;
            var constantsPath = Path.Combine(rootPath, "Constants");
            var reader = new Reader(constantsPath);

            string[] names;
            string[] surnames;
            string[] familyNames;

            if ("F".Equals(gender) || "f".Equals(gender))
            {
                names = reader.GetFemaleNames();

                if (number == 1)
                {
                    return names.Random();
                }

                if (number == 2)
                {
                    familyNames = reader.GetFemaleFamilyNames();
                    return $"{names.Random()} {familyNames.Random()}";
                }

                if (number == 3)
                {
                    surnames = reader.GetFemaleSurnames();
                    familyNames = reader.GetFemaleFamilyNames();
                    return $"{names.Random()} {surnames.Random()} {familyNames.Random()}";
                }
            }
            else
            {
                names = reader.GetMaleNames();
                
                if (number == 1)
                {
                    return names.Random();
                }

                surnames = familyNames = reader.GetMaleFamilyNames();

                if (number == 2)
                {

                    return $"{names.Random()} {familyNames.Random()}";
                }

                if (number == 3)
                {
                    return $"{names.Random()} {surnames.Random()} {familyNames.Random()}";
                }
            }

            return BadRequest();
        }

        [HttpGet]
        public ActionResult<string> Street()
        {
            var rootPath = Environment.ContentRootPath;
            var constantsPath = Path.Combine(rootPath, "Constants");
            var reader = new Reader(constantsPath);
            return reader.GetStreets().Random();
        }

        [HttpGet]
        public ActionResult<Bank> Bank()
        {
            var rootPath = Environment.ContentRootPath;
            var constantsPath = Path.Combine(rootPath, "Constants");
            var reader = new Reader(constantsPath);
            return reader.GetBanks().Random();
        }

        [HttpGet]
        public ActionResult<string> BIC()
        {
            var rootPath = Environment.ContentRootPath;
            var constantsPath = Path.Combine(rootPath, "Constants");
            var reader = new Reader(constantsPath);
            return reader.GetBanks().Random().BussinessIdentifierCode;
        }

        [HttpGet]
        public ActionResult<string> BAE()
        {
            var rootPath = Environment.ContentRootPath;
            var constantsPath = Path.Combine(rootPath, "Constants");
            var reader = new Reader(constantsPath);
            return reader.GetBanks().Random().BankAddressingEntity;
        }

        [HttpGet]
        public ActionResult<string> EGN(DateTime? birthDay, string gender, string region)
        {
            int? regionCode = null;
            var r = Constants.Regions.SingleOrDefault(x => x.Key == region).Value;
            if (r != null)
            {
                regionCode = new Random().Next(r.MinCode, r.MaxCode + 1);
            }

            return Generator.EGN(birthDay, gender, regionCode);
        }

        [HttpGet]
        public ActionResult<string> ENCH(DateTime? birthDay, string gender, string region)
        {
            int? regionCode = null;
            var r = Constants.Regions.SingleOrDefault(x => x.Key == region).Value;
            if (r != null)
            {
                regionCode = new Random().Next(r.MinCode, r.MaxCode + 1);
            }

            return Generator.ENCH(birthDay, gender, regionCode);
        }

        [HttpGet]
        public ActionResult<string> LNCH()
        {
            return Generator.LNCH();
        }

        [HttpGet]
        public ActionResult<string> BULSTAT(int? length)
        {            
            if (!length.HasValue)
            {
                length = 9;
            }

            return Generator.BULSTAT(length.Value);
        }

        [HttpGet]
        public ActionResult<string> IBAN(string bae)
        {
            var rootPath = Environment.ContentRootPath;
            var constantsPath = Path.Combine(rootPath, "Constants");
            var reader = new Reader(constantsPath);

            return Generator.IBAN(reader.GetBanks().Random());
        }
    }
}