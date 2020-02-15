using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiQualifer.Common.Enums;
using TaxiQualifer.Web.Data.Entities;
using TaxiQualifer.Web.Helpers;

namespace TaxiQualifer.Web.Data
{
    public class SeedDB
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDB(DataContext dataContext, IUserHelper userHelper)
        {
            this._dataContext = dataContext;
            this._userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            var admin = await CheckUserAsync("1010", "Alexander", "Garcia", "yesidgarcialopez@gmail.com", "3043293582", "Calle Luna Calle Sol", UserType.Admin);
            var driver = await CheckUserAsync("2020", "Alexander", "Garcia", "yagarcia1402@gmail.com", "3043293582", "Calle Luna Calle Sol", UserType.Driver);
            var user1 = await CheckUserAsync("3030", "Alexander", "Garcia", "yesidgarcia229967@correo.itm.edu.co", "3043293582", "Calle Luna Calle Sol", UserType.User);
            var user2 = await CheckUserAsync("4040", "Carolina", "Munnoz", "caroml98@hotmail.com", "3043293582", "Calle Luna Calle Sol", UserType.User);
            await CheckTaxisAsync(driver, user1, user2);
        }

        private async Task<UserEntity> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Driver.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }


        private async Task CheckTaxisAsync(
            UserEntity driver,
            UserEntity user1,
            UserEntity user2)
        {
            if (!_dataContext.Taxis.Any())
            {
                _dataContext.Taxis.Add(new TaxiEntity
                {
                    User = driver,
                    Plaque = "TPQ123",
                    Trips = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.5f,
                            Source = "ITM Fraternidad",
                            Target = "ITM Robledo",
                            Remarks = "Muy buen servicio",
                            User = user1
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.8f,
                            Source = "ITM Robledo",
                            Target = "ITM Fraternidad",
                            Remarks = "Conductor muy amable",
                            User = user1
                        }
                    }
                });

                _dataContext.Taxis.Add(new TaxiEntity
                {
                    Plaque = "THW321",
                    User = driver,
                    Trips = new List<TripEntity>
                    {
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.5f,
                            Source = "ITM Fraternidad",
                            Target = "ITM Robledo",
                            Remarks = "Muy buen servicio",
                            User = user2
                        },
                        new TripEntity
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddMinutes(30),
                            Qualification = 4.8f,
                            Source = "ITM Robledo",
                            Target = "ITM Fraternidad",
                            Remarks = "Conductor muy amable",
                            User = user2
                        }
                    }
                });

                await _dataContext.SaveChangesAsync();
            }
        }
    }
}



