using maga.Bussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maga.aplication.contract
{
    public interface IMediaFileService
    {
        Task<ResponseAddOrUpdate<string>> uploadImage(FileRequestDto requestFile);
        Task<ResponseAddOrUpdate<string>> uploadVideo(FileRequestDto requestFile);
    }
}
