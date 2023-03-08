using MarcaPlantao.Infra.Contexto;
using MarcaPlantao_Infraestrutura.ObjetoDominio;
using MarcaPlantao_Infraestrutura.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios
{
    public class Repository<TEntity> : IRepositorio<TEntity> where TEntity : Entidade, new()
    {
        protected readonly ContextoMarcaPlantao Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ContextoMarcaPlantao db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public IUnidadeTrabalho UnidadeTrabalho => Db;

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await Db.CompletarAsync();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await Db.CompletarAsync();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await Db.CompletarAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
