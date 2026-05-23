using Application.DTOs.AreaDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IAreaService
    {
        public Task<AreaResponse> AddAreaAsync(AreaAddRequest request);
    }
}