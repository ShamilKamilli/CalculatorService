using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CalculationService.TESTs.Core
{
    public class RequestSender : IRequestSender
    {
        public async Task<string> GetAsync(string url)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                   return await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
