using System.Collections.Generic;
using TaxiQualifer.Common.Models;
using TaxiQualifer.Web.Data.Entities;

namespace TaxiQualifer.Web.Helpers
{
    public interface IConverterHelper
    {
        TaxiResponse ToTaxiResponse(TaxiEntity taxiEntity);

        TripResponse ToTripResponse(TripEntity tripEntity);

        UserResponse ToUserResponse(UserEntity user);

        List<TripResponseWithTaxi> ToTripResponse(List<TripEntity> tripEntities);

        List<UserGroupDetailResponse> ToUserGroupResponse(List<UserGroupDetailEntity> users);

    }
}
