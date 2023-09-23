using Newtonsoft.Json;
using System.Net;
using System.Text;
using WebApplication1.Models.DTOs;
using WebApplication1.Services.IServices;
using static WebApplication1.Utility.SD;

namespace WebApplication1.Services
{
    public class BaseService : IBaseService
    {
        private readonly HttpClient _httpClient;


        public BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                string baseUrl = "https://localhost:7270/";
                _httpClient.BaseAddress = new Uri(baseUrl);

                var message = new HttpRequestMessage();
                var acceptHeader = requestDto.ContentType == ContentType.MultipartFormData ?
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*") :
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
                message.Headers.Accept.Add(acceptHeader);

                if (requestDto.Url != null)
                {
                    message.RequestUri = new Uri(requestDto.Url);
                }
                if (requestDto.Data != null)
                {
                    var jsonContent = JsonConvert.SerializeObject(requestDto.Data);
                    message.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                }


                HttpResponseMessage? apiResponse = null;

                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await _httpClient.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new ResponseDto { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new ResponseDto { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new ResponseDto { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new ResponseDto { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var responseDto = new ResponseDto
                        {
                            IsSuccess = apiResponse.IsSuccessStatusCode,
                            Message = apiResponse.ReasonPhrase
                        };

                        if (apiResponse.IsSuccessStatusCode)
                        {
                            var apiContent = await apiResponse.Content.ReadAsStringAsync();
                            responseDto.Result = apiContent;
                        }
                        return responseDto;



                }



            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
                return dto;
            }
        }
    }
}
