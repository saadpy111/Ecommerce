using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Application.Features.Brands.Commands.CreateBrand;
using Catalog.Application.Features.Products.Commands.CreateProduct;
using Catalog.Application.Features.Products.Commands.UpdateProduct;
using Catalog.Application.Features.Types.Commands.CreateType;
using Catalog.Core.Entities;
using Catalog.Core.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappers
{
    public class ProductMappingProfile :Profile
    {
        public ProductMappingProfile()
        {

            //brand
            CreateMap<ProductBrand, ProductBrandDto>().ReverseMap();
            CreateMap<ProductBrand, CreateBrandCommand>().ReverseMap();

            //type
            CreateMap<ProductType, ProductTypeDto>().ReverseMap();
            CreateMap<ProductType, CreateTypeCommand>().ReverseMap();

            //product
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Pagination<Product>, Pagination<ProductDto>>().ReverseMap();

            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
        }
    }
}
