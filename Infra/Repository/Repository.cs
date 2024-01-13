using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity , new()
    {
        protected ContextBase _context;
        protected DbSet<TEntity>? _dbSet;

        public Repository(ContextBase context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public async Task Adicionar(TEntity id)
        {
            _context.Add(id);
            await SaveChanges();
        }

        public async Task Remover(Guid id)
        {
            _context.Remove(id);
            await SaveChanges();
        }

        public async Task Atualizar(Entity entity)
        {
            _context.Update(entity);
            await SaveChanges();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            _context.Dispose();
        }
    }
}
