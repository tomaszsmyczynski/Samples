using Model;
using Ninject.Modules;

namespace Kernel {
    public class Module : NinjectModule {
        public override void Load() {
            Bind<INoteRepository>().To<NoteRepository>();
        }
    }
}