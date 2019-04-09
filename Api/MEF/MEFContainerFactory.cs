using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;

namespace Api.MEF
{
    public static class MEFContainerFactory
    {
        public static CompositionContainer Create(string binPath)
        {
            var binDirectoryCatalog = new DirectoryCatalog(binPath);

            var aggregateCatalog = new AggregateCatalog();
            aggregateCatalog.Catalogs.Add(binDirectoryCatalog);

            var modulesDirectoryPath = Path.Combine(binPath, "Modules");

            if (Directory.Exists(modulesDirectoryPath))
            {
                var moduleDirectories = Directory
                    .GetDirectories(modulesDirectoryPath)
                    .ToList();

                foreach (var moduleDirectory in moduleDirectories)
                {
                    var directoryCatalog = new DirectoryCatalog(moduleDirectory);
                    aggregateCatalog.Catalogs.Add(directoryCatalog);

                }
            }
            
            var compositionContainer = new CompositionContainer(aggregateCatalog);
            compositionContainer.ComposeParts();

            return compositionContainer;
        }
    }
}