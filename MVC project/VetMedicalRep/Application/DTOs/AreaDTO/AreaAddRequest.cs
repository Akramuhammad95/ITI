using Domain.Entities;
using System;

namespace Application.DTOs.AreaDTO
{
    public class AreaAddRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Area ToArea(AreaAddRequest request)
        {
            return new Area(request.Name, request.Description);
        }
    }
}