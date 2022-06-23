using DogGO.Models;
using System.Collections.Generic;

namespace DogGO.Repositories
{
    public interface INeighborhoodRepository
    {
        List<Neighborhood> GetAll();
    }
}