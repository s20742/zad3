using System.Collections.Generic;
using System.Threading.Tasks;
using zad3.Models;

namespace zad3.Services
{
    public interface IDbService
        {
            Task<IList<Animal>> GetAnimalListAsync();
            
        }
}