using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class GenericRepository<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;


    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
		try
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
		}
		return null!;
    }

	public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
	{
		try
		{
			var entities = await _context.Set<TEntity>().ToListAsync();
			return entities;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
		}
		return null!;
	}

	public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
	{
		try
		{
			var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
			if (result != null)
				return result;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
		}
		return null!;
	}

    public virtual async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity updatedEntity)
    {
        try
        {
            var entityToUpdate = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (entityToUpdate != null)
            {
                _context.Entry(entityToUpdate).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
                return entityToUpdate;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return null!;
    }


    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
	{
		try
		{
			var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
			if (entity != null)
			{
				_context.Set<TEntity>().Remove(entity);
				await _context.SaveChangesAsync();
				return true;
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
		}
		return false;
	}

	public virtual async Task<bool> ExistingAsync(Expression<Func<TEntity, bool>> predicate)
	{
		try
		{
			var existingEntity = await _context.Set<TEntity>().AnyAsync(predicate);
			if (existingEntity)
				return true;

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
		}
		return false;
	}
}
