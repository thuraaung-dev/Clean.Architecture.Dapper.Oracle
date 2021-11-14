using ADAA.ADP.Application.Features.Categories.Queries.GetCategoriesExport;
using ADAA.ADP.Application.Features.Categories.Queries.GetCategoriesList;
using ADAA.ADP.Application.Features.SubCategories.Queries;
using ADAA.ADP.Domain.Entities.Task;
using ADP.ADAA.Application.Features.Categories.Commands.CreateCategory;
using ADP.ADAA.Application.Features.Categories.Commands.DeleteCategory;
using ADP.ADAA.Application.Features.Categories.Commands.UpdateCategory;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Category Module
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryListVm>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
            CreateMap<Category, CategoryExportDto>().ReverseMap();

        }
    }
}
