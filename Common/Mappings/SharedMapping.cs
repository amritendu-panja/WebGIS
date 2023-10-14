﻿using Common.Dtos;
using Common.Entities;

namespace Common.Mappings
{
    public class SharedMapping
    {
        public SharedMapping() { }

        /// <summary>
        /// Maps ApplicationUser to CreateApplicationUserResponse
        /// </summary>
        /// <param name="user">Map From</param>
        /// <param name="response">Mapped To</param>
        public void Map(ApplicationUser user, ApplicationUserResponseDto response) 
        {
            if(user != null && response != null)
            {
                response.UserId = user.UserId;
                response.UserName = user.UserName;
                response.UserGuid = user.UserGuid;
                response.Email = user.Email;
                response.IsLocked = user.IsUserLocked;
                if(user.UserDetails != null)
                {
                    response.FirstName = user.UserDetails.FirstName;
                    response.LastName = user.UserDetails.LastName;
                    response.ImagePath = user.UserDetails.ImagePath;
                    response.AddressLine1 = user.UserDetails.AddressLine1;
                    response.AddressLine2 = user.UserDetails.AddressLine2;
                    response.AlternateEmail = user.UserDetails.AlternateEmail;
                    response.Mobile = user.UserDetails.Mobile;
                    response.AlternateMobile = user.UserDetails.AlternateMobile;
                    response.City = user.UserDetails.City;
                    response.StateCode = user.UserDetails.StateCode;
                    response.PostCode = user.UserDetails.PostCode;
                    response.CountryCode = user.UserDetails.CountryCode;
                }
            }
        }

        /// <summary>
        /// Maps ApplicationUser to ApplicationPartnerResponseDto
        /// </summary>
        /// <param name="user">Map From</param>
        /// <param name="response">Mapped To</param>
        public void Map(ApplicationUser user, ApplicationOrganizationResponseDto response)
        {
            if (user != null && response != null)
            {
                response.UserId = user.UserId;
                response.UserName = user.UserName;
                response.UserGuid = user.UserGuid;
                response.Email = user.Email;
                response.IsLocked = user.IsUserLocked;
                if (user.PartnerOrganization != null)
                {
                    response.OrganizationName = user.PartnerOrganization.OrganizationName;                    
                    response.Description = user.PartnerOrganization.Description;
                    response.LogoUrl = user.PartnerOrganization.LogoUrl;
                    response.Phone = user.PartnerOrganization.Phone;
                    response.AddressLine1 = user.PartnerOrganization.AddressLine1;
                    response.AddressLine2 = user.PartnerOrganization.AddressLine2;                    
                    response.City = user.PartnerOrganization.City;
                    response.StateCode = user.PartnerOrganization.StateCode;
                    response.PostCode = user.PartnerOrganization.PostCode;
                    response.CountryCode = user.PartnerOrganization.CountryCode;
                }
            }
        }

        public void Map(ApplicationLayer applicationLayer, ApplicationLayerResponseDto response)
        {
            if (applicationLayer != null && response != null)
            {
                response.LayerId = applicationLayer.LayerId;
                response.LayerName = applicationLayer.LayerName;
                response.OwerId = applicationLayer.OwnerId;
                response.FilePath = applicationLayer.FilePath;
                response.Created = applicationLayer.CreateDate;
                response.Updated = applicationLayer.ModifiedDate;
            }
        }

        public void Map(CountryLookup countryLookup, CountryLookupDto response)
        {
            if(countryLookup != null)
            {
                if(response == null) { response = new CountryLookupDto(); }
                response.CountryCode = countryLookup.ISO3Code;
                response.CountryName = countryLookup.CountryName;
                response.CallingCode = countryLookup.CallingCode;
                response.IsStateAvailable = countryLookup.HasLevel1;
                response.StateLevelName = countryLookup.Level1Name;
            }
        }

        public void Map(IEnumerable<CountryLookup> countryLookups, CountryLookupResponseDto response)
        {
            if (countryLookups != null)
            {
                if (response == null) { response = new CountryLookupResponseDto(); }
                if (response.Countries == null) { response.Countries = new List<CountryLookupDto>(); }
                foreach(var lookup in countryLookups.OrderBy(s => s.CountryName))
                {
                    var dto = new CountryLookupDto();
                    Map(lookup, dto);
                    response.Countries.Add(dto);
                }
            }
        }

        public void Map(StateLookup stateLookup, StateLookupDto response)
        {
            if (stateLookup != null)
            {
                if (response == null) { response = new StateLookupDto(); }
                response.StateUniqueId = stateLookup.StateUniqueId;
                response.StateName = stateLookup.StateName;
                response.CountryCode = stateLookup.CountryCode;
            }
        }

        public void Map(IEnumerable<StateLookup> stateLookups, StateLookupResponseDto response)
        {
            if (stateLookups != null)
            {
                if (response == null) { response = new StateLookupResponseDto(); }
                if (response.States == null) { response.States = new List<StateLookupDto>(); }
                foreach (var lookup in stateLookups.OrderBy(s => s.StateName))
                {
                    var dto = new StateLookupDto();
                    Map(lookup, dto);
                    response.States.Add(dto);
                }
            }
        }

        public void Map(UpdateProfileCommand command, ApplicationUserDetails userDetails)
        {
            if (command != null)
            {
                if (userDetails == null)
                {
                    userDetails = new ApplicationUserDetails
                        (
                         command.UserId,
                         command.ImagePath,
                         command.FirstName,
                         command.LastName,
                         command.AddressLine1,
                         command.AddressLine2,
                         command.City,
                         command.StateCode,
                         command.PostCode,
                         command.Mobile,
                         command.AlternateEmail,
                         command.CountryCode,
                         command.AlternateMobile
                         );
                }
                else
                {
                    userDetails.Update(
                         command.ImagePath,
                         command.FirstName,
                         command.LastName,
                         command.AddressLine1,
                         command.AddressLine2,
                         command.City,
                         command.StateCode,
                         command.PostCode,
                         command.Mobile,
                         command.AlternateEmail,
                         command.CountryCode,
                         command.AlternateMobile
                         );
                }
            }
        }

        public void Map(ApplicationPartnerListItemBase entity, BaseApplicationOrganizationListItemDto dto)
        {
            if (entity != null)
            {
                if (dto == null) dto = new BaseApplicationOrganizationListItemDto();
                dto.OrganizationId = entity.OrganizationId;
                dto.OrganizationName = entity.OrganizationName;
                dto.LogoUrl = entity.LogoUrl;
                dto.CountryCode = entity.CountryCode;
            }
        }

        public void Map(IEnumerable<ApplicationPartnerListItemBase> applicationPartners, ApplicationOrganizationListResponseDto responseDto)
        {
            if (applicationPartners != null && applicationPartners.Any())
            {
                responseDto.Organizations = new List<BaseApplicationOrganizationListItemDto>();
                foreach (var partner in applicationPartners)
                {
                    BaseApplicationOrganizationListItemDto dto = new BaseApplicationOrganizationListItemDto();
                    Map(partner, dto);
                    responseDto.Organizations.Add(dto);
                }
            }
        }

        public void Map(ApplicationPartnerOrganization entity, ApplicationOrganizationResponseDto dto)
        {
            if (entity != null)
            {
                if (dto == null) dto = new ApplicationOrganizationResponseDto();

                dto.OrganizationId = entity.OrganizationId;
                dto.OrganizationName = entity.OrganizationName;
                dto.Description = entity.Description;
                dto.LogoUrl = entity.LogoUrl;
                dto.Phone = entity.Phone;
                dto.AddressLine1 = entity.AddressLine1;
                dto.AddressLine2 = entity.AddressLine2;
                dto.City = entity.City;
                dto.StateCode = entity.StateCode;
                dto.CountryCode = entity.CountryCode;
                dto.PostCode = entity.PostCode;
                if(entity.User != null)
                {
                    dto.UserId = entity.User.UserId;
                    dto.UserName = entity.User.UserName;
                    dto.Email = entity.User.Email;
                    dto.IsLocked = entity.User.IsUserLocked;
                    dto.UserGuid = entity.User.UserGuid;
                }
            }
        }
    }
}
