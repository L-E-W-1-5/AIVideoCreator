using System;
using System.Collections.Generic;
using System.Text;

namespace AIVideoCreator.WPF.Services
{
    public class VideoService : IVideoService
    {

        public async Task<string> GenerateVideo(string title)
        {
            return await Task.FromResult($"Generating video about {title}");
        }
    }
}
