using GermanBash.Common.Data;
using GermanBash.App.ViewModels;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GermanBash.App.Data;

namespace GermanBash.App.Modules
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMainViewModel>().To<MainViewModel>().InSingletonScope();
            this.Bind<ICategoryViewModel>().To<CategoryViewModel>().InSingletonScope();

            this.Bind<IFullyCachedBashClient>().To<FullyCachedBashClient>().InSingletonScope();
            this.Bind<ICachedBashClient>().To<CachedBashClient>().InSingletonScope();
            this.Bind<IBashClient>().To<BashClient>().InSingletonScope();

            this.Bind<IFavoriteManager>().To<FavoriteManager>().InSingletonScope();
        }
    }
}
