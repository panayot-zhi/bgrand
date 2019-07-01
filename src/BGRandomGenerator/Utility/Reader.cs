using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BGRandomGenerator.Models;
using Newtonsoft.Json;

namespace BGRandomGenerator.Utility
{
    /// <summary>
    /// Responsible for reading files containing random data and constructing models out of it.
    /// </summary>
    public class Reader
    {
        private string Root { get; }

        public Reader(string root)
        {
            Root = root;
        }

        public Bank[] GetBanks()
        {
            var banksJsonPath = Path.Combine(Root, "banks.json");
            using (var streamReader = File.OpenText(banksJsonPath))
            {
                return JsonConvert.DeserializeObject<Bank[]>(streamReader.ReadToEnd());
            }
        }

        public async Task<Bank[]> GetBanksAsync()
        {
            var banksJsonPath = Path.Combine(Root, "banks.json");
            using (var streamReader = File.OpenText(banksJsonPath))
            {
                return JsonConvert.DeserializeObject<Bank[]>(await streamReader.ReadToEndAsync());
            }
        }

        public string[] GetStrings(string filename)
        {
            var banksJsonPath = Path.Combine(Root, filename);
            using (var streamReader = File.OpenText(banksJsonPath))
            {
                return JsonConvert.DeserializeObject<string[]>(streamReader.ReadToEnd());
            }
        }

        public async Task<string[]> GetStringsAsync(string filename)
        {
            var banksJsonPath = Path.Combine(Root, filename);
            using (var streamReader = File.OpenText(banksJsonPath))
            {
                return JsonConvert.DeserializeObject<string[]>(await streamReader.ReadToEndAsync());
            }
        }

        public string[] GetMaleNames()
        {
            return GetStrings("maleNames.json");
        }

        public async Task<string[]> GetMaleNamesAsync()
        {
            return await GetStringsAsync("maleNames.json");
        }

        public string[] GetMaleFamilyNames()
        {
            return GetStrings("maleFamilyNames.json");
        }

        public async Task<string[]> GetMaleFamilyNamesAsync()
        {
            return await GetStringsAsync("maleFamilyNames.json");
        }

        public string[] GetFemaleSurnames()
        {
            return GetStrings("femaleSurnames.json");
        }

        public async Task<string[]> GetFemaleSurnamesAsync()
        {
            return await GetStringsAsync("femaleSurnames.json");
        }

        public string[] GetFemaleNames()
        {
            return GetStrings("femaleNames.json");
        }

        public async Task<string[]> GetFemaleNamesAsync()
        {
            return await GetStringsAsync("femaleNames.json");
        }

        public string[] GetFemaleFamilyNames()
        {
            return GetStrings("femaleFamilyNames.json");
        }

        public async Task<string[]> GetFemaleFamilyNamesAsync()
        {
            return await GetStringsAsync("maleNames.json");
        }

        public string[] GetStreets()
        {
            return GetStrings("streets.json");
        }

        public async Task<string[]> GetStreetsAsync()
        {
            return await GetStringsAsync("streets.json");
        }


    }
}
