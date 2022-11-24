using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using WePing.Girpe.Samples;

namespace WePing.Girpe.Clubs;

public interface IClubAppService :IApplicationService/*
    ICrudAppService< //Defines CRUD methods
            ClubDto, //Used to show Clubs
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateClubDto> //Used to create/update a book*/
{
    Task<List<ClubDto>> GetAllAsync();

    Task<ClubDto> GetAsync(Guid id);

    Task<ClubDto> GetByNumero(string numero);

    
}
