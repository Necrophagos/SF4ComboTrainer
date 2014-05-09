namespace SF4ComboTrainer.StreetFighterLibrary
{
    using System.Collections.Generic;
    using System.Reflection;

    using Caliburn.Micro;

    using SF4ComboTrainer.Input;
    using SF4ComboTrainer.StreetFighterLibrary.ViewModels;

    public class AppBootStrapper : Bootstrapper<MainViewModel>
    {
        /// <summary>
        /// Select the assemblies that contain model views.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            assemblies.Add(Assembly.GetExecutingAssembly()); 
            assemblies.Add(Assembly.Load("SF4ComboTrainer.Input"));  

            return assemblies;
        }
        
        public AppBootStrapper() : base() {
            Common.Utilities.Roadie.Instance.Dispose();
        }
    }
}
