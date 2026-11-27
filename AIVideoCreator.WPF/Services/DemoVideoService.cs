using System;
using System.Collections.Generic;
using System.Text;

namespace AIVideoCreator.WPF.Services
{
    internal class DemoVideoService : IVideoService
    {

        public async Task<string> GenerateVideo(string title)
        {
            return await Task.FromResult($"[DEMO MODE] Pretending to generate demo video about {title}");
        }
    }
}
