﻿using System.Threading.Tasks;
using TaxiQualifer.Common.Models;

namespace TaxiQualifer.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetTaxiAsync(string plaque, string urlBase, string servicePrefix, string controller);

        bool CheckConnection();

        Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, TokenRequest request);

        Task<Response> GetUserByEmail(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, EmailRequest request);

        Task<Response> RegisterUserAsync(string urlBase, string servicePrefix, string controller, UserRequest userRequest);

        Task<Response> RecoverPasswordAsync(string urlBase, string servicePrefix, string controller, EmailRequest emailRequest);

        Task<Response> PutAsync<T>(string urlBase, string servicePrefix, string controller, T model, string tokenType, string accessToken);

        Task<Response> ChangePasswordAsync(string urlBase, string servicePrefix, string controller, ChangePasswordRequest changePasswordRequest, string tokenType, string accessToken);

        Task<Response> NewTripAsync(string urlBase, string servicePrefix, string controller, TripRequest model, string tokenType, string accessToken);

        Task<Response> AddTripDetailsAsync(string urlBase, string servicePrefix, string controller, TripDetailsRequest model, string tokenType, string accessToken);

        Task<Response> GetTripAsync(string urlBase, string servicePrefix, string controller, int id, string tokenType, string accessToken);

        Task<Response> CompleteTripAsync(string urlBase, string servicePrefix, string controller, CompleteTripRequest model, string tokenType, string accessToken);

        Task<Response> DeleteAsync(string urlBase, string servicePrefix, string controller, int id, string tokenType, string accessToken);

        Task<Response> GetMyTrips(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, MyTripsRequest model);

    }
}
