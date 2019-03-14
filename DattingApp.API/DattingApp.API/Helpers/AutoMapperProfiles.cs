﻿using AutoMapper;
using DattingApp.API.Dto;
using DattingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DattingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                 .ForMember(dest => dest.Age, opt =>
                 {
                     opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                 });

            CreateMap<User, UserForDetailedDto>()
                 .ForMember(dest => dest.PhotoUrl, opt =>
                 {
                     opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                 })
                    .ForMember(dest => dest.Age, opt =>
                    {
                        opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                    });
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}