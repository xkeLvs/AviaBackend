using AutoMapper;
using AviaBackend.Application.Interfaces;
using AviaBackend.Persistence.Repositories;
using System.Linq.Expressions;

namespace AviaBackend.Application.Services;
public class CrudAppService<TEntity, TGetDto, TCreateDto, TUpdateDto> : ICrudAppService<TEntity, TGetDto, TCreateDto, TUpdateDto>
    where TEntity : class, new()
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public CrudAppService(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TGetDto> GetAsync(Guid id, params Expression<Func<TEntity, object>>[] includes)
    {
        var entity = await _repository.GetByIdAsync(id, includes);
        return _mapper.Map<TGetDto>(entity);
    }

    public async Task<IEnumerable<TGetDto>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        var entities = await _repository.GetAllAsync(includes);
        return _mapper.Map<IEnumerable<TGetDto>>(entities);
    }

    public async Task<TGetDto> CreateAsync(TCreateDto input)
    {
        var entity = _mapper.Map<TEntity>(input);
        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return _mapper.Map<TGetDto>(entity);
    }

    public async Task UpdateAsync(Guid id, TUpdateDto input)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) throw new Exception($"{typeof(TEntity).Name} not found");

        _mapper.Map(input, entity);
        _repository.Update(entity);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) throw new Exception($"{typeof(TEntity).Name} not found");

        _repository.Delete(entity);
        await _repository.SaveChangesAsync();
    }
}


