using System.Linq.Expressions;

namespace AviaBackend.Application.Interfaces;

public interface ICrudAppService<TEntity, TGetDto, TCreateDto, TUpdateDto>where TEntity : class
{
    Task<TGetDto> GetAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);
    Task<IEnumerable<TGetDto>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
    Task<TGetDto> CreateAsync(TCreateDto input);
    Task UpdateAsync(Guid id, TUpdateDto input);
    Task DeleteAsync(Guid id);
}

