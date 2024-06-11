using OwnImplementationGetters.Services.ServicesSource;
using ZooLibrary.Getters.GettersSource;
using ZooLibrary.Models;

namespace OwnImplementationGetters.OwnGetters.OwnGettersSource;

public interface IOwnAnimalsGetter : IAnimalsGetter
{
    Task<IList<Animal>> GetAnimalsFromDb(IAnimalsService service);
}

