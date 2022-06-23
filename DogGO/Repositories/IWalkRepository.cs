using DogGO.Models;
using System.Collections.Generic;

namespace DogGO.Repositories
{
    public interface IWalkRepository
    {
        List<Walk> GetAll();
        List<Walk> GetWalksByWalkerId(int walkerId);
    }
}
