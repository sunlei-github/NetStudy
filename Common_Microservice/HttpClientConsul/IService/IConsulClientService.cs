using Common_Microservice.HttpClientConsul.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common_Microservice.HttpClientConsul.IService
{
    public interface IConsulClientService
    {
        Task<HttpResponseMessage> GetAsync(GetConsulClientOption option);

        Task<HttpResponseMessage> PostAsync(PostConsulClientOption option);

        Task<HttpResponseMessage> PutAsync(PutConsulClientOption option);

        Task<HttpResponseMessage> DeleteAsync(DeleteConsulClientOption option);

    }
}
