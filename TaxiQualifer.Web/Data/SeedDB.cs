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
            _dataContext = dataContext;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            UserEntity admin = await CheckUserAsync("1010", "Alexander", "Garcia", "yesidgarcialopez@gmail.com", "3043293582", "Calle Luna Calle Sol", UserType.Admin);
            UserEntity driver = await CheckUserAsync("2020", "Alexander", "Garcia", "yagarcia1402@gmail.com", "3043293582", "Calle Luna Calle Sol", UserType.Driver);
            UserEntity user1 = await CheckUserAsync("3030", "Alexander", "Garcia", "yesidgarcia229967@correo.itm.edu.co", "3043293582", "Calle Luna Calle Sol", UserType.User);
            UserEntity user2 = await CheckUserAsync("4040", "Carolina", "Munnoz", "caroml98@hotmail.com", "3043293582", "Calle Luna Calle Sol", UserType.User);
            UserEntity user3 = await CheckUserAsync("6060", "Sandra", "Usuga", "sandra@yopmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);
            UserEntity user4 = await CheckUserAsync("7070", "Lisa", "Marin", "luisa@yopmail.com", "350 634 2747", "Calle Luna Calle Sol", UserType.User);

            await CheckTaxisAsync(driver, user1, user2);
            await CheckUserGroups(user1, user2,user3,user4);
        }

        private async Task CheckUserGroups(UserEntity user1, UserEntity user2, UserEntity user3, UserEntity user4)
        {
            if (!_dataContext.UserGroups.Any())
            {
                _dataContext.UserGroups.Add(new UserGroupEntity
                {
                    User = user1,
                    Users = new List<UserGroupDetailEntity>
                    {
                        new UserGroupDetailEntity { User = user2 },
                        new UserGroupDetailEntity { User = user3 },
                        new UserGroupDetailEntity { User = user4 }
                    }
                });

                _dataContext.UserGroups.Add(new UserGroupEntity
                {
                    User = user2,
                    Users = new List<UserGroupDetailEntity>
            {
                new UserGroupDetailEntity { User = user1 },
                new UserGroupDetailEntity { User = user3 },
                new UserGroupDetailEntity { User = user4 }
            }
                });

                await _dataContext.SaveChangesAsync();
            }
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
            UserEntity user = await _userHelper.GetUserAsync(email);
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
                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

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



