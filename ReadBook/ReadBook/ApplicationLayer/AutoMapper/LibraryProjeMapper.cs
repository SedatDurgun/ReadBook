using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using AutoMapper;
using DomainLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.AutoMapper
{
    public class LibraryProjeMapper :Profile
    {
        public LibraryProjeMapper()
        {
            //Book
            CreateMap<Book,AddBookDTO>().ReverseMap();
            CreateMap<Book,UpdateBookDTO>().ReverseMap();
            CreateMap<Book, BookVM>().ReverseMap();

            //User
            CreateMap<NewUserDTO,NewUserVM>().ReverseMap();

            //Category
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<Category,CategoryVM>().ReverseMap();
            CreateMap<Category,AddCategoryDTO>().ReverseMap();
            CreateMap<Category,UpdateCategoryDTO>().ReverseMap();
           
            //Corner
            CreateMap<Corner,CornerVM>().ForMember(x=>x.BookName,y=>y.MapFrom(y=>y.Book.BookName)).ReverseMap(); //Navigation Property üzerinden iki katman arasındaki bağlantıyı kuruyoruz
            CreateMap<Corner, AddCornerDTO>().ReverseMap();
            CreateMap<Corner, UpdateCornerDTO>().ReverseMap();




        }

    }
}
