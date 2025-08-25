using AutoMapper;
using Plenumio.Application.DTOs;
using Plenumio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Mapping {
    public class PostProfile: Profile {

        public PostProfile() {
            CreateMap<CreatePostDto, Post>();

            CreateMap<Post, PostDto>();
                //.ForMember(dest => dest.PrivacyType, opt => opt.MapFrom(src => ((PrivacyType)src.PrivacyType).ToString()))
                //.ForMember(dest => dest.Author, opt => opt.MapFrom(src => new UserDto(src.User.Id, src.User.Username, src.User.ProfilePictureUrl)))
                //.ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.PostTags.Select(pt => new TagDto(pt.Tag.Id, pt.Tag.Name))))
                //.ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));
        }
        

    
    }
}
