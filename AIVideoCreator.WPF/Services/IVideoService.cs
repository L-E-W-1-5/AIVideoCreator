using System.Threading.Tasks;

namespace AIVideoCreator.WPF.Services
{
    public interface IVideoService
    {
        Task<string> GenerateVideo(string title);
    }
}
