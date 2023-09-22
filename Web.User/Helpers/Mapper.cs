﻿using Common.Dtos;
using Common.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.User.Models;

namespace Web.User.Helpers
{
    public class Mapper
    {
        public void Map(ApplicationUserResponseDto userResponseDto, ProfileModel profileModel)
        {
            if (userResponseDto == null) { return; }
            if (profileModel == null) { 
                profileModel = new ProfileModel();
            }
            profileModel.UserId = userResponseDto.UserId;
            profileModel.Email = userResponseDto.Email;
            profileModel.UserName = userResponseDto.UserName;
            profileModel.AddressLine1 = userResponseDto.AddressLine1;
            profileModel.AddressLine2 = userResponseDto.AddressLine2;
            profileModel.AlternateEmail = userResponseDto.AlternateEmail;
            profileModel.AlternateMobile = userResponseDto.AlternateMobile;
            profileModel.Mobile = userResponseDto.Mobile;
            profileModel.City = userResponseDto.City;
            profileModel.CountryCode = userResponseDto.CountryCode;
            profileModel.FirstName = userResponseDto.FirstName;
            profileModel.LastName = userResponseDto.LastName;
            profileModel.StateCode = userResponseDto.StateCode;
            profileModel.PostCode = userResponseDto.PostCode;
            profileModel.ImagePath = string.IsNullOrEmpty(userResponseDto.ImagePath) ? Constants.DefaultProfileImage : userResponseDto.ImagePath;            
        }

        public void Map(CountryLookupResponseDto countryLookupResponseDto, List<SelectListItem> listItems)
        {
            if (countryLookupResponseDto == null) { return; }; 
            if (listItems == null) {  listItems = new List<SelectListItem>(); }
            if (countryLookupResponseDto.Success)
            {
                foreach(var lookup in countryLookupResponseDto.Countries)
                {
                    SelectListItem item = new SelectListItem()
                    {
                         Value = lookup.CountryCode,
                         Text = lookup.CountryName
                    };
                    listItems.Add(item);
                }
            }
        }
    }
}
