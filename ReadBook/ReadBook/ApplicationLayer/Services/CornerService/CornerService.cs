using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using AutoMapper;
using DomainLayer.Entities.Concrete;
using DomainLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.CornerService
{
    public class CornerService : ICornerService
    {

        private readonly ICornerRepository _cornerRepository;

        private readonly IMapper _mapper;

        public CornerService(ICornerRepository cornerRepository, IMapper mapper)
        {
            _cornerRepository = cornerRepository;
            _mapper = mapper;
        }

        public async Task AddBookCornerAsync(AddCornerDTO addCornerDTO)
        {
          Corner corner = new Corner();
            _mapper.Map(corner, addCornerDTO);

            await _cornerRepository.AddAsync(corner);
           
            
        }

        public Task DeleteBookCornerAsync(int id)
        {
            return _cornerRepository.DeleteAsync(id);
        }

        public IEnumerable<CornerVM> GetAllCornersAsync()
        {
            var allList = _cornerRepository.GetAllActiveInclude().Include(x => x.Book).ToList();

            List<CornerVM> cornerVM= new List<CornerVM>();

            _mapper.Map(allList, cornerVM);

            return cornerVM;
        }
    }
}
